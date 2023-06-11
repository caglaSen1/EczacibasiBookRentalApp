using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System.Collections.Generic;

namespace BookRentalApp.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ServiceResult<GetCategoryByIdDto> Add(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            if (category == null)
            {
                return ServiceResult<GetCategoryByIdDto>.Failed(null, "Failed to map category", 400); // 400 - Bad Request
            }

            _repository.Add(category);
            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(category);
            return ServiceResult<GetCategoryByIdDto>.Success(categoryDtoResult, "Category added successfully");

        }

        public ServiceResult<GetCategoryByIdDto> Delete(int id)
        {
            var category = _repository.GetById(id);

            if (category == null) 
            {
                return ServiceResult<GetCategoryByIdDto>.Failed(null, "Category not found", 404); //404 - Not Found
            }

            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(category);
            _repository.Delete(id);
            return ServiceResult<GetCategoryByIdDto>.Success(categoryDtoResult, "Category deleted successfully");
            
        }

        public ServiceResult<List<GetAllCategoriesDto>> GetAll(int page, int pageSize)
        {
            var categories = _repository.GetAll(page, pageSize);

            if (categories == null)
            {
                return ServiceResult<List<GetAllCategoriesDto>>.Failed(null, "Failed to retrieve categories", 500); //500 - Internal Server Error
            }

            var categoryDtosResult = _mapper.Map<List<GetAllCategoriesDto>>(categories);
            return ServiceResult<List<GetAllCategoriesDto>>.Success(categoryDtosResult, "Categories retrieved successfully");

        }

        public ServiceResult<GetCategoryByIdDto> GetById(int id)
        {
            var category = _repository.GetById(id);

            if (category == null)
            {
                return ServiceResult<GetCategoryByIdDto>.Failed(null, "Category not found", 404); //404 - Not Found
            }

            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(category);
            return ServiceResult<GetCategoryByIdDto>.Success(categoryDtoResult, "Category retrieved successfully");
        }

        public ServiceResult<GetCategoryByIdDto> Update(int id, UpdateCategoryDto categoryDto)
        {
            var category = _repository.GetById(id);

            if(category == null)
            {
                return ServiceResult<GetCategoryByIdDto>.Failed(null, "Category not found", 404); //404 - Not Found
            }

            var updatedCategory = _repository.Update(id, _mapper.Map<Category>(categoryDto));

            if(updatedCategory == null)
            {
                return ServiceResult<GetCategoryByIdDto>.Failed(null, "Failed to update the category", 500); //500 - Internal Server Error
            }

            var categoryDtoResult = _mapper.Map<GetCategoryByIdDto>(updatedCategory);
            return ServiceResult<GetCategoryByIdDto>.Success(categoryDtoResult, "Category updated successfully");
        }
    }
}
