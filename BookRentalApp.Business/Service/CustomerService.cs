using AutoMapper;
using BookRentalApp.Business.Dto.Category;
using BookRentalApp.Business.Dto.Customer;
using BookRentalApp.Business.Interface;
using BookRentalApp.Data.Entity;
using BookRentalApp.Data.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookRentalApp.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository repository, IMapper mapper, ILogger<CustomerService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResult<GetCustomerByIdDto> Add(CreateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            if (customer == null)
            {
                return ServiceResultLogger.Failed<GetCustomerByIdDto>(null, "Failed to map customer", (int)HttpStatusCode.BadRequest, _logger); 
            }

            _repository.Add(customer);
            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(customer);
            return ServiceResult<GetCustomerByIdDto>.Succeeded(customerDtoResult, "Category added successfully", (int)HttpStatusCode.Created);
        }

        public ServiceResult<GetCustomerByIdDto> Delete(int id)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return ServiceResultLogger.Failed<GetCustomerByIdDto>(null, "Customer not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(customer);
            _repository.Delete(id);
            return ServiceResult<GetCustomerByIdDto>.Succeeded(customerDtoResult, "Customer deleted successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<List<GetAllCustomersDto>> GetAll(int page, int pageSize)
        {
            var customers = _repository.GetAll(page, pageSize);

            if (customers == null)
            {
                return ServiceResultLogger.Failed<List<GetAllCustomersDto>>(null, "Failed to retrieve categories", (int)HttpStatusCode.NotFound, _logger); 
            }

            var customerDtosResult = _mapper.Map<List<GetAllCustomersDto>>(customers);
            return ServiceResult<List<GetAllCustomersDto>>.Succeeded(customerDtosResult, "Customers retrieved successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<GetCustomerByIdDto> GetById(int id)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return ServiceResultLogger.Failed<GetCustomerByIdDto>(null, "Customer not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(customer);
            return ServiceResult<GetCustomerByIdDto>.Succeeded(customerDtoResult, "Customer retrieved successfully", (int)HttpStatusCode.OK);

        }

        public ServiceResult<GetCustomerByIdDto> Update(int id, UpdateCustomerDto customerDto)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return ServiceResultLogger.Failed<GetCustomerByIdDto>(null, "Customer not found", (int)HttpStatusCode.NotFound, _logger); 
            }

            var updatedCustomer = _repository.Update(id, _mapper.Map<Customer>(customerDto));

            if (updatedCustomer == null)
            {
                return ServiceResultLogger.Failed<GetCustomerByIdDto>(null, "Failed to update the customer", (int)HttpStatusCode.BadRequest, _logger); 
            }

            var customerDtoResult = _mapper.Map<GetCustomerByIdDto>(updatedCustomer);
            return ServiceResult<GetCustomerByIdDto>.Succeeded(customerDtoResult, "Customer updated successfully", (int)HttpStatusCode.OK);

        }
    }
}
