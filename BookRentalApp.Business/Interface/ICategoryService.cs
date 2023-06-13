using BookRentalApp.Business.Dto.Category;
using System.Collections.Generic;

namespace BookRentalApp.Business.Interface
{
    public interface ICategoryService
    {
        ServiceResult<GetCategoryByIdDto> Add(CreateCategoryDto categoryDto);
        ServiceResult<GetCategoryByIdDto> Delete(int id);
        ServiceResult<GetCategoryByIdDto> Update(int id, UpdateCategoryDto categoryDto);
        ServiceResult<List<GetAllCategoriesDto>> GetAll(int page, int pageSize);
        ServiceResult<GetCategoryByIdDto> GetById(int id, bool withBooks = false);
        ServiceResult<GetCategoryByIdDto> GetByName(string name, bool withBooks = false);

    }
}
