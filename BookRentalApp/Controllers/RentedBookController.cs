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
        public IActionResult Create(CreateRentedBookDto rentedBookDto)
        {
            var result = _service.Add(rentedBookDto);

            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Result.Id }, result.Result);
            }

            return BadRequest(result.Message);

            /*try
            {
                _service.Add(rentedBookDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a rented book: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }*/
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
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

        [HttpGet("{customerId}")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _service.GetByCustomerId(id);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

            /*try
            {
                var rentedBook = _service.GetByCustomerId(customerId) ?? throw new Exception("Not Found");
                var rentedBookDto = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
                return Ok(rentedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a rented book with customer ID {Id}: {ErrorMessage}", customerId, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }*/
        }

        [HttpGet("{bookId}")]
        public IActionResult GetByBookId(int id)
        {
            var result = _service.GetByBookId(id);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

            /*try
            {
                var rentedBook = _service.GetByBookId(bookId) ?? throw new Exception("Not Found");
                var rentedBookDto = _mapper.Map<GetRentedBookByIdDto>(rentedBook);
                return Ok(rentedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a rented book with book ID {Id}: {ErrorMessage}", bookId, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }*/
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRentedBookDto rentedBookDto)
        {
            var result = _service.Update(id, rentedBookDto);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);

            /*try
            {
                var rentedBook = _service.Update(id, rentedBookDto);
                return Ok(_mapper.Map<GetRentedBookByIdDto>(rentedBook));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the rented book with ID {BookRentalId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }*/
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
            /*try
            {
                var rentedBook = _service.GetById(id) ?? throw new Exception("Not Found");
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the rented book with ID {BookRentalId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }*/
        }

        [HttpGet("search")]
        public IActionResult Search(int? customerId, int? bookId, DateTime? rentalDate, byte? howManyDaysToRent, DateTime? returnDate)
        {
            var result = _service.Search(customerId, bookId, rentalDate, howManyDaysToRent, returnDate);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

            /*try
            {
                var searchResult = _service.Search(customerId, bookId, rentalDate, howManyDaysToRent, returnDate) ?? throw new Exception("Not Found");
                var rentedBookDtos = _mapper.Map<List<GetBookByIdDto>>(searchResult);
                return Ok(rentedBookDtos);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while searching rented books: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }*/
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
