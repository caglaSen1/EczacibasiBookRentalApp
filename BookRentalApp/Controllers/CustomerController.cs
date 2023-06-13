using AutoMapper;
using BookRentalApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.Customer;
using Microsoft.Extensions.Logging;
using BookRentalApp.Business.Interface;

namespace BookRentalApp.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService service, IMapper mapper, ILogger<CustomerController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto customerDto)
        {

            var result = _service.Add(customerDto);

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
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpGet("/email/{email}")]
        public IActionResult GetById(string email)
        {
            var result = _service.GetByEmail(email);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpGet("/phone/{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            var result = _service.GetByPhone(phone);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, UpdateCustomerDto customerDto)
        {
            var result = _service.Update(id, customerDto);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Message);
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
    }
}
