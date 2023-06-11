
using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.Customer;

namespace BookRentalApp.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto customerDto)
        {
            _repository.Add(_mapper.Map<Customer>(customerDto));
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            var customers = _repository.GetAll(page, pageSize);
            var customerDtos = _mapper.Map<List<GetAllCustomersDto>>(customers);
            return Ok(customerDtos);
        }

        [HttpGet("{id}")] //customers/2
        public IActionResult Get(int id)
        {
            var customer = _repository.GetById(id) ?? throw new Exception("Not Found");
            var customerDto = _mapper.Map<GetCustomerByIdDto>(customer);
            return Ok(customerDto);
        }

        [HttpPut("{id}")] //customer/2
        public IActionResult Update(int id, UpdateCustomerDto customerDto)
        {
            var customer = _repository.Update(id, _mapper.Map<Customer>(customerDto));
            return Ok(_mapper.Map<GetCustomerByIdDto>(customer));
        }
    }
}
