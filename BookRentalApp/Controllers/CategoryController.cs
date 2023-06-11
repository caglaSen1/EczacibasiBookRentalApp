
using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto categoryDto)
        {
            _repository.Add(_mapper.Map<Category>(categoryDto));
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            var categories = _repository.GetAll(page, pageSize);
            var categoryDtos = _mapper.Map<List<GetAllCategoriesDto>>(categories);
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")] 
        public IActionResult Get(int id)
        {
            var category = _repository.GetById(id) ?? throw new Exception("Not Found");
            var categoryDto = _mapper.Map<GetCategoryByIdDto>(category);
            return Ok(categoryDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryDto categoryDto)
        {
            var category = _repository.Update(id, _mapper.Map<Category>(categoryDto));
            return Ok(_mapper.Map<GetCategoryByIdDto>(category));

        }
    }
}
