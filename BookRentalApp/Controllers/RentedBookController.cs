using AutoMapper;
using BookRentalApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.BookRental;
using Microsoft.Extensions.Logging;
using BookRentalApp.Business.Interface;

namespace BookRentalApp.Controllers
{
    [Route("bookRentals")]
    public class RentedBookController : Controller
    {
        private readonly IRentedBookService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<RentedBookController> _logger;

        public RentedBookController(IRentedBookService service, IMapper mapper, ILogger<RentedBookController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateRentedBookDto bookRentalDto)
        {
            try
            {
                _service.Add(bookRentalDto);
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
                var bookRentals = _service.GetAll(page, pageSize);
                var bookRentalDtos = _mapper.Map<List<GetAllRentedBooksDto>>(bookRentals);
                return Ok(bookRentalDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving book rentals: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("{id}")] 
        public IActionResult Get(int id, bool withCustomer = false, bool withBook = false)
        {
            try
            {
                var bookRental = _service.GetById(id, withCustomer, withBook) ?? throw new Exception("Not Found");
                var bookRentalDto = _mapper.Map<GetRentedBookByIdDto>(bookRental);
                return Ok(bookRental);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a book rental with ID {Id}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, UpdateRentedBookDto bookRentalDto)
        {
            try
            {
                var bookRental = _service.Update(id, bookRentalDto);
                return Ok(_mapper.Map<GetRentedBookByIdDto>(bookRental));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book rental with ID {BookRentalId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }
    }
}
