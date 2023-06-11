using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.BookRental;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Controllers
{
    [Route("bookRentals")]
    public class BookRentalController : Controller
    {
        private readonly IBookRentalRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookRentalController> _logger;

        public BookRentalController(IBookRentalRepository repository, IMapper mapper, ILogger<BookRentalController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateBookRentalDto bookRentalDto)
        {
            try
            {
                _repository.Add(_mapper.Map<BookRental>(bookRentalDto));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a book rental: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            try
            {
                var bookRentals = _repository.GetAll(page, pageSize);
                var bookRentalDtos = _mapper.Map<List<GetAllBookRentalsDto>>(bookRentals);
                return Ok(bookRentalDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving book rentals: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("{id}")] //books/2
        public IActionResult Get(int id, bool withCustomer = false, bool withBook = false)
        {
            try
            {
                var bookRental = _repository.GetById(id, withCustomer, withBook) ?? throw new Exception("Not Found");
                var bookRentalDto = _mapper.Map<GetBookRentalByIdDto>(bookRental);
                return Ok(bookRental);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a book rental with ID {Id}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("{id}")] //books/2
        public IActionResult Update(int id, UpdateBookRentalDto bookRentalDto)
        {
            try
            {
                var bookRental = _repository.Update(id, _mapper.Map<BookRental>(bookRentalDto));
                return Ok(_mapper.Map<GetBookRentalByIdDto>(bookRental));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book rental with ID {BookRentalId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }
    }
}
