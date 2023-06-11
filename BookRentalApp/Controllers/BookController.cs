using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateBookDto bookDto)
        {
            _repository.Add(_mapper.Map<Book>(bookDto));
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            var books = _repository.GetAll(page, pageSize);
            var bookDtos = _mapper.Map<List<GetAllBooksDto>>(books);
            return Ok(bookDtos);
        }

        [HttpGet("{id}")] //books/2
        public IActionResult Get(int id, bool withCategory = false)
        {
            var book = _repository.GetById(id, withCategory) ?? throw new Exception("Not Found");
            var bookDto = _mapper.Map<GetBookByIdDto>(book);
            return Ok(bookDto);
        }

        [HttpPut("{id}")] //books/2
        public IActionResult Update(int id, UpdateBookDto bookDto)
        {
            var book = _repository.Update(id, _mapper.Map<Book>(bookDto));
            return Ok(_mapper.Map<GetBookByIdDto>(book));
        }
    }
}
