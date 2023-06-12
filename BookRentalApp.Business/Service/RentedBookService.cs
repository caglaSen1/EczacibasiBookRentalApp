using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Dto.BookRental;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Business.Service
{
    public class RentedBookService : IRentedBookService
    {
        private readonly IRentedBookRepository _repository;
        private readonly IMapper _mapper;

        public RentedBookService(IRentedBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ServiceResult<GetRentedBookByIdDto> Add(CreateRentedBookDto rentedBookDto)
        {
            var rentedBook = _mapper.Map<RentedBook>(rentedBookDto);

            if (rentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Failed to map rented book", 400); // 400 - Bad Request
            }

            _repository.Add(rentedBook);
            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Success(rentedBookDtoResult, "Rented book added successfully");
        }

        public ServiceResult<GetRentedBookByIdDto> Delete(int id)
        {
            var rentedBook = _repository.GetById(id);

            if (rentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Rented book not found", 404); //404 - Not Found
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            _repository.Delete(id);
            return ServiceResult<GetRentedBookByIdDto>.Success(rentedBookDtoResult, "Rented book deleted successfully");

        }

        public ServiceResult<List<GetAllRentedBooksDto>> GetAll(int page, int pageSize)
        {
            var rentedBooks = _repository.GetAll(page, pageSize);

            if (rentedBooks == null)
            {
                return ServiceResult<List<GetAllRentedBooksDto>>.Failed(null, "Failed to retrieve rented books", 500); //500 - Internal Server Error
            }

            var rentedBookDtosResult = _mapper.Map<List<GetAllRentedBooksDto>>(rentedBooks);
            return ServiceResult<List<GetAllRentedBooksDto>>.Success(rentedBookDtosResult, "Rented books retrieved successfully");
        }

        public ServiceResult<GetRentedBookByIdDto> GetById(int id, bool withCustomer = false, bool withBook = false)
        {
            var rentedBook = _repository.GetById(id, withCustomer, withBook);

            if (rentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Rented book not found", 404); //404 - Not Found
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Success(rentedBookDtoResult, "Rented book retrieved successfully");
        }

        public ServiceResult<GetRentedBookByIdDto> GetByBookId(int bookId)
        {
            var rentedBook = _repository.GetByBookId(bookId);

            if (rentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Rented book not found", 404); //404 - Not Found
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Success(rentedBookDtoResult, "Rented book retrieved successfully");
        }

        public ServiceResult<GetRentedBookByIdDto> GetByCustomerId(int customerId)
        {
            var rentedBook = _repository.GetByCustomerId(customerId);

            if (rentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Rented book not found", 404); //404 - Not Found
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Success(rentedBookDtoResult, "Rented book retrieved successfully");
        }


        public ServiceResult<List<GetRentedBookByIdDto>> GetCurrentRentals()
        {
            var currentRentals = _repository.GetCurrentRentals();

            if (currentRentals == null)
            {
                return ServiceResult<List<GetRentedBookByIdDto>>.Failed(null, "The currently rented books were not found", 404); //404 - Not Found
            }

            var currentRentalsDtoResult = _mapper.Map<List<GetRentedBookByIdDto>>(currentRentals);
            return ServiceResult<List<GetRentedBookByIdDto>>.Success(currentRentalsDtoResult, "The currently rented books retrieved successfully");
        }

        public ServiceResult<List<GetRentedBookByIdDto>> GetPreviousRentals()
        {
            var previousRentals = _repository.GetPreviousRentals();

            if (previousRentals == null)
            {
                return ServiceResult<List<GetRentedBookByIdDto>>.Failed(null, "Previously rented books were not found", 404); //404 - Not Found
            }

            var previousRentalsDtoResult = _mapper.Map<List<GetRentedBookByIdDto>>(previousRentals);
            return ServiceResult<List<GetRentedBookByIdDto>>.Success(previousRentalsDtoResult, "The previously rented books retrieved successfully");
        }

        public ServiceResult<GetRentedBookByIdDto> Update(int id, UpdateRentedBookDto rentedBookDto)
        {
            var rentedBook = _repository.GetById(id);

            if (rentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Rented book not found", 404); //404 - Not Found
            }

            var updatedRentedBook = _repository.Update(id, _mapper.Map<RentedBook>(rentedBookDto));

            if (updatedRentedBook == null)
            {
                return ServiceResult<GetRentedBookByIdDto>.Failed(null, "Failed to update the rented book", 500); //500 - Internal Server Error
            }

            var rentedBookDtoResult = _mapper.Map<GetRentedBookByIdDto>(updatedRentedBook);
            return ServiceResult<GetRentedBookByIdDto>.Success(rentedBookDtoResult, "Rented book updated successfully");
        }

        public ServiceResult<List<GetRentedBookByIdDto>> Search(int? customerId, int? bookId, DateTime? rentalDate, byte? howManyDaysToRent, DateTime? returnDate, bool? isRented)
        {
            var rentedBooks = _repository.Search(customerId, bookId, rentalDate, howManyDaysToRent, returnDate, isRented);

            if (rentedBooks == null)
            {
                return ServiceResult<List<GetRentedBookByIdDto>>.Failed(null, "Failed to retrieve rented books", 500); //500 - Internal Server Error
            }

            var rentedBookDtosResult = _mapper.Map<List<GetRentedBookByIdDto>>(rentedBooks);
            return ServiceResult<List<GetRentedBookByIdDto>>.Success(rentedBookDtosResult, "Rented books retrieved successfully");
        }
    }
}
