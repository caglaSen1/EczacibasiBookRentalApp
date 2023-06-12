using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;

namespace BookRentalApp.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repository, IMapper mapper, ILogger<CategoryService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResult<GetCategoryByIdDto> Add(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            if (category == null)
            {
                return ServiceResultLogger.Failed<GetCategoryByIdDto>(null, "Failed to map category", (int)HttpStatusCode.BadRequest, _logger); 
            }

            _repository.Add(category);
            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(category);
            return ServiceResult<GetCategoryByIdDto>.Succeeded(categoryDtoResult, "Category added successfully", (int)HttpStatusCode.Created);

        }

        public ServiceResult<GetCategoryByIdDto> Delete(int id)
        {
            var category = _repository.GetById(id);

            if (category == null)
            {
                return ServiceResultLogger.Failed<GetCategoryByIdDto>(null, "Category not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(category);
            _repository.Delete(id);
            return ServiceResult<GetCategoryByIdDto>.Succeeded(categoryDtoResult, "Category deleted successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<List<GetAllCategoriesDto>> GetAll(int page, int pageSize)
        {
            var categories = _repository.GetAll(page, pageSize);

            if (categories == null)
            {
                return ServiceResultLogger.Failed<List<GetAllCategoriesDto>>(null, "Failed to retrieve categories", (int)HttpStatusCode.NotFound, _logger); 
            }

            var categoryDtosResult = _mapper.Map<List<GetAllCategoriesDto>>(categories);
            return ServiceResult<List<GetAllCategoriesDto>>.Succeeded(categoryDtosResult, "Categories retrieved successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<GetCategoryByIdDto> GetById(int id)
        {
            var category = _repository.GetById(id);

            if (category == null)
            {
                return ServiceResultLogger.Failed<GetCategoryByIdDto>(null, "Category not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(category);
            return ServiceResult<GetCategoryByIdDto>.Succeeded(categoryDtoResult, "Category retrieved successfully", (int)HttpStatusCode.OK);
        }

        public ServiceResult<GetCategoryByIdDto> Update(int id, UpdateCategoryDto categoryDto)
        {
            var category = _repository.GetById(id);

            if (category == null)
            {
                return ServiceResultLogger.Failed<GetCategoryByIdDto>(null, "Category not found", (int)HttpStatusCode.NotFound, _logger);
            }

            var updatedCategory = _repository.Update(id, _mapper.Map<Category>(categoryDto));

            if (updatedCategory == null)
            {
                return ServiceResultLogger.Failed<GetCategoryByIdDto>(null, "Failed to update the category", (int)HttpStatusCode.BadRequest, _logger); 
            }

            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(updatedCategory);
            return ServiceResult<GetCategoryByIdDto>.Succeeded(categoryDtoResult, "Category updated successfully", (int)HttpStatusCode.OK);
        }
    }
}
