using AutoMapper;
using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService service, IMapper mapper, ILogger<BookController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;   
        }
        

        [HttpPost]
        public IActionResult Create(CreateBookDto bookDto)
        {
            var result = _service.Add(bookDto);

            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Result.Id }, result.Result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 5, string sortBy = "Default")
        {
            var result = _service.GetAll(page, pageSize, sortBy);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
            
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id, bool withCategory = false)
        {
            var result = _service.GetById(id, withCategory);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpGet("/title/{title}")]
        public IActionResult GetByTitle(string title, bool withCategory = false, string sortBy = "Default")
        {
            var result = _service.GetByTitle(title, withCategory, sortBy);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

        }

        [HttpGet("/ISBN/{ISBN}")]
        public IActionResult GetByISBN(string ISBN, bool withCategory = false, string sortBy = "Default")
        {
            var result = _service.GetByISBN(ISBN, withCategory, sortBy);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);

        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, UpdateBookDto bookDto)
        {
            var result = _service.Update(id, bookDto);

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

        [HttpGet("search")]
        public IActionResult Search(string title, string author, string publisher, string ISBN,
        int? categoryId, double? minPrice, string categoryName, bool? isAvailable, string sortBy = "Default")
        {
            var result = _service.Search(title, author, publisher, ISBN, categoryId, minPrice, categoryName, isAvailable, sortBy);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }


    }
}
