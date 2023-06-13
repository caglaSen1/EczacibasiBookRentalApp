using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookRentalApp.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService service, IMapper mapper, ILogger<CategoryController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto categoryDto)
        {
            var result = _service.Add(categoryDto);

            if(result.Success)
            {
                return CreatedAtAction(nameof(GetById), new {id = result.Result.Id}, result.Result);
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
        public IActionResult GetById(int id, bool withBooks = false)
        {
            var result = _service.GetById(id, withBooks);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpGet("/name/{name}")]
        public IActionResult GetByName(string name, bool withBooks = false)
        {
            var result = _service.GetByName(name, withBooks);

            if (result.Success)
            {
                return Ok(result.Result);
            }

            return NotFound(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryDto categoryDto)
        {
            var result = _service.Update(id, categoryDto);

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
