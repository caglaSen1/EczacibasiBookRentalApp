using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ServiceResult<GetBookByIdDto> Add(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            if (book == null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Failed to map book", 400); // 400 - Bad Request
            }

            _repository.Add(book);
            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            return ServiceResult<GetBookByIdDto>.Success(bookDtoResult, "Book added successfully");
        }

        public ServiceResult<GetBookByIdDto> Delete(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Book not found", 404); //404 - Not Found
            }

            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            _repository.Delete(id);
            return ServiceResult<GetBookByIdDto>.Success(bookDtoResult, "Book deleted successfully");

        }

        public ServiceResult<List<GetAllBooksDto>> GetAll(int page, int pageSize)
        {
            var books = _repository.GetAll(page, pageSize);

            if (books == null)
            {
                return ServiceResult<List<GetAllBooksDto>>.Failed(null, "Failed to retrieve books", 500); //500 - Internal Server Error
            }

            var bookDtosResult = _mapper.Map<List<GetAllBooksDto>>(books);
            return ServiceResult<List<GetAllBooksDto>>.Success(bookDtosResult, "Books retrieved successfully");

        }

        public ServiceResult<GetBookByIdDto> GetById(int id, bool withCategory = false)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Book not found", 404); //404 - Not Found
            }

            var bookDtoResult = _mapper.Map<GetBookByIdDto>(book);
            return ServiceResult<GetBookByIdDto>.Success(bookDtoResult, "Book retrieved successfully");
        }

        public ServiceResult<List<GetBookByIdDto>> Search(string title, string author, string publisher, string ISBN, int? categoryId, double? minPrice, string categoryName, bool isAvailable)
        {
            var books = _repository.Search(title, author, publisher, ISBN, categoryId, minPrice, categoryName, isAvailable);

            if (books == null)
            {
                return ServiceResult<List<GetBookByIdDto>>.Failed(null, "Failed to retrieve books", 500); //500 - Internal Server Error
            }

            var bookDtosResult = _mapper.Map<List<GetBookByIdDto>>(books);
            return ServiceResult<List<GetBookByIdDto>>.Success(bookDtosResult, "Books retrieved successfully");

        }

        public ServiceResult<GetBookByIdDto> Update(int id, UpdateBookDto bookDto)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Book not found", 404); //404 - Not Found
            }

            var updatedBook = _repository.Update(id, _mapper.Map<Book>(bookDto));

            if (updatedBook == null)
            {
                return ServiceResult<GetBookByIdDto>.Failed(null, "Failed to update the book", 500); //500 - Internal Server Error
            }

            var bookDtoResult = _mapper.Map<GetBookByIdDto>(updatedBook);
            return ServiceResult<GetBookByIdDto>.Success(bookDtoResult, "Book updated successfully");
        }
    }

}
