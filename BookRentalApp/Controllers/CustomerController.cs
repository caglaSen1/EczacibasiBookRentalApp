
using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.Customer;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository repository, IMapper mapper, ILogger<CustomerController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto customerDto)
        {
            
            try
            {
                _repository.Add(_mapper.Map<Customer>(customerDto));
                return Ok();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a customer: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }

            
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            try
            {
                var customers = _repository.GetAll(page, pageSize);
                var customerDtos = _mapper.Map<List<GetAllCustomersDto>>(customers);
                return Ok(customerDtos);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customers: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("{id}")] //customers/2
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _repository.GetById(id) ?? throw new Exception("Not Found");
                var customerDto = _mapper.Map<GetCustomerByIdDto>(customer);
                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer with ID {CustomerId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("{id}")] //customer/2
        public IActionResult Update(int id, UpdateCustomerDto customerDto)
        {
            try
            {
                var customer = _repository.Update(id, _mapper.Map<Customer>(customerDto));
                return Ok(_mapper.Map<GetCustomerByIdDto>(customer));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating customer with ID {CustomerId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }
    }
}
