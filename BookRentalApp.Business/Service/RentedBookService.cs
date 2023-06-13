using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Dto.BookRental;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using BookRentalApp.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookRentalApp.Business.Service
{
    public class RentedBookService : IRentedBookService
    {
        private readonly IRentedBookRepository _repository;        
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<RentedBookService> _logger;
        private readonly IBookRepository _bookRepository;


        public RentedBookService(IRentedBookRepository repository, IMapper mapper, IBookService bookService, ILogger<RentedBookService> logger, ICustomerService customerService, IBookRepository bookRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _bookService = bookService;
            _logger = logger;
            _customerService = customerService;
            _bookRepository = bookRepository;
        }

        public ServiceResult<GetRentedBookByIdDto> Add(CreateRentedBookDto rentedBookDto)
        {
            var book = _bookService.GetById(rentedBookDto.BookId).Result;
            
            if (book == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Book not found", (int)HttpStatusCode.NotFound, _logger);
            }

            var customer = _customerService.GetById(rentedBookDto.CustomerId).Result;
            
            if (customer == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Customer not found", (int)HttpStatusCode.NotFound, _logger);
            }

            var rentedBook = _mapper.Map<RentedBook>(rentedBookDto);

            if (rentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Failed to map rented book", (int)HttpStatusCode.BadRequest, _logger); 
            }

            
            if (book.IsAvailable == false)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Book is not available", (int)HttpStatusCode.NotAcceptable, _logger); 
            }
                        
            _bookService.SetAvailability(book.Id, false);

            _repository.Add(rentedBook);
            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book added successfully", (int)HttpStatusCode.Created);
        }


        public ServiceResult<GetRentedBookByIdDto> Delete(int id)
        {
            var rentedBook = _repository.GetById(id);

            if (rentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Rented book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            //var book = rentedBook.Book;
            _bookService.SetAvailability(rentedBook.BookId, true);

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            _repository.Delete(id);
            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book deleted successfully", (int)HttpStatusCode.OK);

        }


        public ServiceResult<List<GetAllRentedBooksDto>> GetAll(int page = 0, int pageSize = 5)
        {
            var rentedBooks = _repository.GetAll(page, pageSize);

            if (rentedBooks == null)
            {
                return ServiceResultLogger.Failed<List<GetAllRentedBooksDto>>(null, "Failed to retrieve rented books", (int)HttpStatusCode.NotFound, _logger); 
            }

            var rentedBookDtosResult = _mapper.Map<List<GetAllRentedBooksDto>>(rentedBooks);

            return ServiceResult<List<GetAllRentedBooksDto>>.Succeeded(rentedBookDtosResult, "Rented books retrieved successfully", (int)HttpStatusCode.OK);
        }


        public ServiceResult<GetRentedBookByIdDto> GetById(int id, bool withCustomer = false, bool withBook = false)
        {
            var rentedBook = _repository.GetById(id, withCustomer, withBook);

            if (rentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Rented book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            //rentedBookDtoResult.RentalDate = rentedBook.RentalDate.ToString("yyyy-MM-dd");
            //rentedBookDtoResult.ReturnDate = rentedBook.ReturnDate.ToString("yyyy-MM-dd");
            //rentedBookDtoResult.MustReturnDate = rentedBook.MustReturnDate.ToString("yyyy-MM-dd");

            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book retrieved successfully", (int)HttpStatusCode.OK);
        }


        public ServiceResult<GetRentedBookByIdDto> GetByBookId(int id)
        {
            var rentedBook = _repository.GetByBookId(id);

            if (rentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Rented book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book retrieved successfully", (int)HttpStatusCode.OK);
        }


        public ServiceResult<GetRentedBookByIdDto> GetByCustomerId(int id)
        {
            var rentedBook = _repository.GetByCustomerId(id);

            if (rentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Rented book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book retrieved successfully", (int)HttpStatusCode.OK);
        }


        public ServiceResult<List<GetRentedBookByIdDto>> GetCurrentRentals()
        {
            var currentRentals = _repository.GetCurrentRentals();

            if (currentRentals == null)
            {
                return ServiceResultLogger.Failed<List<GetRentedBookByIdDto>>(null, "The currently rented books were not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var currentRentalsDtoResult = _mapper.Map<List<GetRentedBookByIdDto>>(currentRentals);
            return ServiceResult<List<GetRentedBookByIdDto>>.Succeeded(currentRentalsDtoResult, "The currently rented books retrieved successfully", (int)HttpStatusCode.OK);
        }


        public ServiceResult<List<GetRentedBookByIdDto>> GetOverdueRentals()
        {
            var previousRentals = _repository.GetOverdueRentals();

            if (previousRentals == null)
            {
                return ServiceResultLogger.Failed<List<GetRentedBookByIdDto>>(null, "Previously rented books were not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var previousRentalsDtoResult = _mapper.Map<List<GetRentedBookByIdDto>>(previousRentals);
            return ServiceResult<List<GetRentedBookByIdDto>>.Succeeded(previousRentalsDtoResult, "The previously rented books retrieved successfully", (int)HttpStatusCode.OK);
        }

        public ServiceResult<GetRentedBookByIdDto> Update(int id, UpdateRentedBookDto rentedBookDto)
        {
            var rentedBook = _repository.GetById(id);

            if (rentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Rented book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            //var book = rentedBook.Book;
            if (_bookService.SetAvailability(rentedBook.BookId, true).Success == false)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "The book you want to replace is not available", (int)HttpStatusCode.NotFound, _logger);
            }
            
            var updatedRentedBook = _repository.Update(id, _mapper.Map<RentedBook>(rentedBookDto));

            if (updatedRentedBook == null)
            {
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Failed to update the rented book", (int)HttpStatusCode.BadRequest, _logger); 
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(updatedRentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book updated successfully", (int)HttpStatusCode.OK);
        }

        public ServiceResult<List<GetRentedBookByIdDto>> Search(int? customerId, int? bookId, DateTime? rentalDate, byte? howManyDaysToRent, DateTime? returnDate)
        {
            var rentedBooks = _repository.Search(customerId, bookId, rentalDate, howManyDaysToRent, returnDate);

            if (rentedBooks == null)
            {
                return ServiceResultLogger.Failed<List<GetRentedBookByIdDto>>(null, "Failed to retrieve rented books", (int)HttpStatusCode.NotFound, _logger); 
            }

            var rentedBookDtosResult = _mapper.Map<List<GetRentedBookByIdDto>>(rentedBooks);
            return ServiceResult<List<GetRentedBookByIdDto>>.Succeeded(rentedBookDtosResult, "Rented books retrieved successfully", (int)HttpStatusCode.Found);
        }

        
        public ServiceResult<GetRentedBookByIdDto> DeliverBook(int id)
        {
            var rentedBook = _repository.GetById(id);
            if(rentedBook == null)
            {
                return  ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "Rented book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            //var book = rentedBook.Book;

            if(_bookService.SetAvailability(rentedBook.BookId, true).Success == false) 
            { 
                return ServiceResultLogger.Failed<GetRentedBookByIdDto>(null, "The book couldn't delivered", (int)HttpStatusCode.NotFound, _logger);
            }

            _repository.DeliverBook(id);
            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Succeeded(rentedBookDtoResult, "Rented book delivered successfully", (int)HttpStatusCode.OK);

        }
        
    }
}
