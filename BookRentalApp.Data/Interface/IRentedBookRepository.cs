using BookRentalApp.Data.Entity;
using System;
using System.Collections.Generic;

namespace BookRentalApp.Data.Interface
{
    public interface IRentedBookRepository
    {
        void Add(RentedBook bookRental);
        void Delete(int id);
        RentedBook Update(int id, RentedBook bookRental);
        RentedBook GetById(int id, bool withCustomer = false, bool withBook = false);
        List<RentedBook> GetAll(int page, int pageSize);
        RentedBook GetByCustomerId(int id);
        RentedBook GetByBookId(int id);
        List<RentedBook> GetPreviousRentals();
        List<RentedBook> GetCurrentRentals();
        List<RentedBook> Search(int? customerId, int? bookId, DateTime? rentalDate, byte? howManyDaysToRent, DateTime? returnDate);
        RentedBook DeliverBook(int id);

    }
}
