using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Dto.Customer;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ServiceResult<GetCustomerByIdDto> Add(CreateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            if (customer == null)
            {
                return ServiceResult<GetCustomerByIdDto>.Failed(null, "Failed to map customer", 400); // 400 - Bad Request)
            }

            _repository.Add(customer);
            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(customer);
            return ServiceResult<GetCustomerByIdDto>.Success(customerDtoResult, "Category added successfully");
        }

        public ServiceResult<GetCustomerByIdDto> Delete(int id)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return ServiceResult<GetCustomerByIdDto>.Failed(null, "Customer not found", 404); //404 - Not Found
            }

            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(customer);
            _repository.Delete(id);
            return ServiceResult<GetCustomerByIdDto>.Success(customerDtoResult, "Customer deleted successfully");

        }

        public ServiceResult<List<GetAllCustomersDto>> GetAll(int page, int pageSize)
        {
            var customers = _repository.GetAll(page, pageSize);

            if (customers == null)
            {
                return ServiceResult<List<GetAllCustomersDto>>.Failed(null, "Failed to retrieve categories", 500); // 500 - Internal Server Error
            }

            var customerDtosResult = _mapper.Map<List<GetAllCustomersDto>>(customers);
            return ServiceResult<List<GetAllCustomersDto>>.Success(customerDtosResult, "Customers retrieved successfully");

        }

        public ServiceResult<GetCustomerByIdDto> GetById(int id)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return ServiceResult<GetCustomerByIdDto>.Failed(null, "Customer not found", 404); // 404 - Not Found
            }

            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(customer);
            return ServiceResult<GetCustomerByIdDto>.Success(customerDtoResult, "Customer retrieved successfully");

        }

        public ServiceResult<GetCustomerByIdDto> Update(int id, UpdateCustomerDto customerDto)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return ServiceResult<GetCustomerByIdDto>.Failed(null, "Customer not found", 404); // 404 - Not Found
            }

            var updatedCustomer = _repository.Update(id, _mapper.Map<Customer>(customerDto));

            if (updatedCustomer == null)
            {
                return ServiceResult<GetCustomerByIdDto>.Failed(null, "Failed to update the customer", 500); // 500 - Internal Server Error
            }

            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(updatedCustomer);
            return ServiceResult<GetCustomerByIdDto>.Success(customerDtoResult, "Customer updated successfully");

        }
    }
}
