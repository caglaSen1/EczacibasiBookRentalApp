using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private readonly IBookService _serivce;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService service, IMapper mapper, ILogger<BookController> logger)
        {
            _serivce = service;
            _mapper = mapper;
            _logger = logger;   
        }

        [HttpPost]
        public IActionResult Create(CreateBookDto bookDto)
        {
            try
            {
                _serivce.Add(bookDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a book: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            try
            {
                var books = _serivce.GetAll(page, pageSize);
                var bookDtos = _mapper.Map<List<GetAllBooksDto>>(books);
                return Ok(bookDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving books: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id, bool withCategory = false)
        {
            try
            {
                var book = _serivce.GetById(id, withCategory) ?? throw new Exception("Not Found");
                var bookDto = _mapper.Map<GetBookByIdDto>(book);
                return Ok(bookDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving book with ID {BookId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, UpdateBookDto bookDto)
        {
            try
            {
                var book = _serivce.Update(id, bookDto);
                return Ok(_mapper.Map<GetBookByIdDto>(book));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book with ID {BookId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var book = _serivce.GetById(id) ?? throw new Exception("Not Found");
                _serivce.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book with ID {BookId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("search")]
        public IActionResult Search(string title, string author, string publisher, string ISBN,
        int? categoryId, double? minPrice, string categoryName, bool? isAvailable)
        {
            try
            {
                var searchResult = _serivce.Search(title, author, publisher, ISBN, categoryId, minPrice, categoryName, isAvailable) ?? throw new Exception("Not Found");
                var bookDtos = _mapper.Map<List<GetBookByIdDto>>(searchResult);
                return Ok(bookDtos);
               
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while searching books: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }


    }
}
