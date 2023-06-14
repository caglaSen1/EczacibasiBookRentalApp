using AutoMapper;
using BookRentalApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.BookRental;
using Microsoft.Extensions.Logging;
using BookRentalApp.Business.Interface;
using BookRentalApp.Business.Dto.Book;

namespace BookRentalApp.Controllers
{
    [Route("rentedBooks")]
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
        public IActionResult Create(CreateRentedBookDto rentedBookDto)
        {
            var result = _service.Add(rentedBookDto);

            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Result.Id }, result.Result);
            }

            return BadRequest(result.Message);

        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 5)
        {
            var result = _service.GetAll(page, pageSize);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, bool withCustomer = false, bool withBook = false)
        {
            var result = _service.GetById(id, withCustomer, withBook);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

       
        [HttpGet("/getOverdueRentals")]
        public IActionResult GetOverdueRentals()
        {
            var result = _service.GetOverdueRentals();

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

           
        }

        [HttpGet("/getCurrentRentals")]
        public IActionResult GetCurrentRentals()
        {
            var result = _service.GetCurrentRentals();

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);


        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
            
        }

        [HttpGet("search")]
        public IActionResult Search(int? customerId, int? bookId, byte? howManyDaysToRent)
        {
            var result = _service.Search(customerId, bookId, howManyDaysToRent);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

        }

        [HttpPatch("deliverBook/{id}")]
        public IActionResult DeliverBook(int id)
        {
            
            var result = _service.DeliverBook(id);
            if (result.Success)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);


        }

    }
}
