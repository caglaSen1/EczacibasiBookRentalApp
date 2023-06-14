using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Enum;
using BookRentalApp.Data.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;

namespace BookRentalApp.Business.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;
        private readonly ICategoryService _categoryService;

        public BookService(IBookRepository repository, IMapper mapper, ILogger<BookService> logger, ICategoryService categoryService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _categoryService = categoryService;
        }

        public ServiceResult<GetBookByIdDto> Add(CreateBookDto bookDto)
        {
            var category = _categoryService.GetById(bookDto.CategoryId).Result;

            if (category == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Category doesn't exist", (int)HttpStatusCode.NotFound, _logger);
            }

            var book = _mapper.Map<Book>(bookDto);

            if (book == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Failed to map book", (int)HttpStatusCode.BadRequest, _logger);
                
            }
            
            _repository.Add(book);
            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            return ServiceResult<GetBookByIdDto>.Succeeded(bookDtoResult, "Book added successfully", (int)HttpStatusCode.Created);
        }

        
        public ServiceResult<GetBookByIdDto> Delete(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            _repository.Delete(id);
            return ServiceResult<GetBookByIdDto>.Succeeded(bookDtoResult, "Book deleted successfully", (int)HttpStatusCode.OK);

        }

        
       
        public ServiceResult<GetBookByIdDto> GetById(int id, bool withCategory = false)
        {
            var book = _repository.GetById(id, withCategory);

            if (book == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            return ServiceResult<GetBookByIdDto>.Succeeded(bookDtoResult, "Book retrieved successfully", (int)HttpStatusCode.OK);
        }

        public ServiceResult<List<GetAllBooksDto>> GetAll(int page = 0, int pageSize = 5, string sortBy = "Default")
        {
            var books = _repository.GetAll(page, pageSize, SortByString(sortBy));

            if (books == null)
            {
                return ServiceResultLogger.Failed<List<GetAllBooksDto>>(null, "Failed to retrieve books", (int)HttpStatusCode.NotFound, _logger);
            }

            var bookDtosResult = _mapper.Map<List<GetAllBooksDto>>(books);
            return ServiceResult<List<GetAllBooksDto>>.Succeeded(bookDtosResult, "Books retrieved successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<List<GetAllBooksDto>> GetByISBN(string ISBN, bool withCategory = false, string sortBy = "Default")
        {
            var books = _repository.GetByISBN(ISBN, withCategory, SortByString(sortBy));

            if (books == null)
            {
                return ServiceResultLogger.Failed<List<GetAllBooksDto>>(null, "Book not found", (int)HttpStatusCode.NotFound, _logger);
            }

            var bookDtosResult = _mapper.Map<List<GetAllBooksDto>>(books);
            return ServiceResult<List<GetAllBooksDto>>.Succeeded(bookDtosResult, "Book retrieved successfully", (int)HttpStatusCode.OK);
        }

        public ServiceResult<List<GetAllBooksDto>> GetByTitle(string title, bool withCategory = false, string sortBy = "Default")
        {
            var books = _repository.GetByTitle(title, withCategory, SortByString(sortBy));

            if (books == null)
            {
                return ServiceResultLogger.Failed<List<GetAllBooksDto>>(null, "Book not found", (int)HttpStatusCode.NotFound, _logger);
            }

            var bookDtosResult = _mapper.Map<List<GetAllBooksDto>>(books);
            return ServiceResult<List<GetAllBooksDto>>.Succeeded(bookDtosResult, "Book retrieved successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<List<GetBookByIdDto>> Search(string title, string author, string publisher, string ISBN, int? categoryId, double? minPrice, string categoryName, bool? isAvailable, string sortBy = "Default")
        {
            var books = _repository.Search(title, author, publisher, ISBN, categoryId, minPrice, categoryName, isAvailable, SortByString(sortBy));

            if (books == null)
            {
                return ServiceResultLogger.Failed<List<GetBookByIdDto>>(null, "Failed to retrieve books", (int)HttpStatusCode.NotFound, _logger); 
            }

            var bookDtosResult = _mapper.Map<List<GetBookByIdDto>>(books);
            return ServiceResult<List<GetBookByIdDto>>.Succeeded(bookDtosResult, "Books retrieved successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<GetBookByIdDto> SetAvailability(int id, bool availability)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Failed to retrieve book", (int)HttpStatusCode.NotFound, _logger); 

            }

            if (book.IsAvailable == availability)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "The availability you want to change is the same", (int)HttpStatusCode.BadRequest, _logger); 
            }

            book.IsAvailable = availability;
            
            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            return ServiceResult<GetBookByIdDto>.Succeeded(bookDtoResult, "Availibility of book is changed", (int)HttpStatusCode.OK);

        }
             

        public ServiceResult<GetBookByIdDto> Update(int id, UpdateBookDto bookDto)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Book not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var updatedBook = _repository.Update(id, _mapper.Map<Book>(bookDto));

            if (updatedBook == null)
            {
                return ServiceResultLogger.Failed<GetBookByIdDto>(null, "Failed to update the book", (int)HttpStatusCode.NotFound, _logger); 
            }

            var bookDtoResult = _mapper.Map<GetBookByIdDto>(updatedBook);
            return ServiceResult<GetBookByIdDto>.Succeeded(bookDtoResult, "Book updated successfully", (int)HttpStatusCode.OK);
        }

        public SortBy SortByString(string sortBy)
        {
            switch(sortBy.ToLower())
            {
                case "alphabetic":
                    return SortBy.Alphabetic;
                case "ascending":
                    return SortBy.Ascending;
                case "descanding":
                    return SortBy.Descending;
                default:
                    return SortBy.Default;
            }
        }

    }

}
