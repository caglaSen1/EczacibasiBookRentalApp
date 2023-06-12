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

        [HttpGet("{id}")] //books/2
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

        [HttpPut("{id}")] //books/2
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
    }
}
