
using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository repository, IMapper mapper, ILogger<CategoryController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto categoryDto)
        {
            try
            {
                _repository.Add(_mapper.Map<Category>(categoryDto));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a category: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            try
            {
                var categories = _repository.GetAll(page, pageSize);
                var categoryDtos = _mapper.Map<List<GetAllCategoriesDto>>(categories);
                return Ok(categoryDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories: {ErrorMessage}", ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("{id}")] 
        public IActionResult Get(int id)
        {
            try
            {
                var category = _repository.GetById(id) ?? throw new Exception("Not Found");
                var categoryDto = _mapper.Map<GetCategoryByIdDto>(category);
                return Ok(categoryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a category with ID {CategoryId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryDto categoryDto)
        {
            try
            {
                var category = _repository.Update(id, _mapper.Map<Category>(categoryDto));
                return Ok(_mapper.Map<GetCategoryByIdDto>(category));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the category with ID {CategoryId}: {ErrorMessage}", id, ex.Message);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }

        }
    }
}
