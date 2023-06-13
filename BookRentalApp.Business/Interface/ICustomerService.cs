using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business;
using System;
using System.Collections.Generic;
using BookRentalApp.Data.Entity;
using BookRentalApp.Business.Dto.Customer;

namespace BookRentalApp.Business.Interface
{
    public interface ICustomerService
    {
        ServiceResult<GetCustomerByIdDto> Add(CreateCustomerDto customerDto);
        ServiceResult<GetCustomerByIdDto> Delete(int id);
        ServiceResult<GetCustomerByIdDto> Update(int id, UpdateCustomerDto customerDto);
        ServiceResult<List<GetAllCustomersDto>> GetAll(int page, int pageSize);
        ServiceResult<GetCustomerByIdDto> GetById(int id);
        ServiceResult<GetCustomerByIdDto> GetByFirstName(string firstName);
        ServiceResult<GetCustomerByIdDto> GetByPhone(string phone);
        ServiceResult<GetCustomerByIdDto> GetByEmail(string email);

    }
}