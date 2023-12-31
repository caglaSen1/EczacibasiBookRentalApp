﻿using BookRentalApp.Business.Dto.Book;
using BookRentalApp.Business.Dto.BookRental;
using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Business.Interface
{
    public interface IRentedBookService
    {
        ServiceResult<GetRentedBookByIdDto> Add(CreateRentedBookDto rentedBookDto);
        ServiceResult<GetRentedBookByIdDto> Delete(int id);
        ServiceResult<GetRentedBookByIdDto> GetById(int id, bool withCustomer = false, bool withBook = false);
        ServiceResult<List<GetAllRentedBooksDto>> GetAll(int page, int pageSize);
        ServiceResult<List<GetRentedBookByIdDto>> GetOverdueRentals();
        ServiceResult<List<GetRentedBookByIdDto>> GetCurrentRentals();
        ServiceResult<List<GetRentedBookByIdDto>> Search(int? customerId, int? bookId, byte? howManyDaysToRent);
        ServiceResult<GetRentedBookByIdDto> DeliverBook(int id);


    }
}
