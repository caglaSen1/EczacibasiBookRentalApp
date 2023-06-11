using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookRentalApp.Business.Dto.BookRental;

namespace BookRentalApp.Controllers
{
    [Route("bookRentals")]
    public class BookRentalController : Controller
    {
        private readonly IBookRentalRepository _repository;
        private readonly IMapper _mapper;

        public BookRentalController(IBookRentalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateBookRentalDto bookRentalDto)
        {
            _repository.Add(_mapper.Map<BookRental>(bookRentalDto));
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            var bookRentals = _repository.GetAll(page, pageSize);
            var bookRentalDtos = _mapper.Map<List<GetAllBookRentalsDto>>(bookRentals);
            return Ok(bookRentalDtos);
        }

        [HttpGet("{id}")] //books/2
        public IActionResult Get(int id, bool withCustomer = false, bool withBook = false)
        {
            var bookRental = _repository.GetById(id, withCustomer, withBook) ?? throw new Exception("Not Found");
            var bookRentalDto = _mapper.Map<GetBookRentalByIdDto>(bookRental);
            return Ok(bookRental);
        }

        [HttpPut("{id}")] //books/2
        public IActionResult Update(int id, UpdateBookRentalDto bookRentalDto)
        {
            var bookRental = _repository.Update(id, _mapper.Map<BookRental>(bookRentalDto));
            return Ok(_mapper.Map<GetBookRentalByIdDto>(bookRental));
        }
    }
}
