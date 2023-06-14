using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface IRentedBookRepository
    {
        RentedBook Add(RentedBook bookRental);
        RentedBook Delete(int id);
        RentedBook GetById(int id, bool withCustomer = false, bool withBook = false);
        List<RentedBook> GetAll(int page, int pageSize);
        RentedBook GetByCustomerId(int id);
        RentedBook GetByBookId(int id);
        List<RentedBook> GetOverdueRentals();
        List<RentedBook> GetCurrentRentals();
        List<RentedBook> Search(int? customerId, int? bookId, byte? howManyDaysToRent);
        RentedBook DeliverBook(int id);

    }
}
