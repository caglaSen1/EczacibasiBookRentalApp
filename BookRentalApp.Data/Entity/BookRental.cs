using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Data.Entity
{
    [Table("BookRentals")]
    public class BookRental : BaseEntity<int>
    {
        
        public Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Book Book { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        public DateTime RentalDate { get; set; } = DateTime.Today;
        public byte HowManyDaysToRent { get; set; }

        private DateTime _returnDate;

        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                _returnDate = RentalDate.AddDays(HowManyDaysToRent);
            }
        }
         
        private bool _isRented;

        public bool IsRented
        {
            get => _isRented;
            set
            {
                if (DateTime.Now > ReturnDate)
                {
                    _isRented = true;
                }
                else if(DateTime.Now <= ReturnDate)
                {
                    _isRented = false;
                }

            }
        }

    }

    public enum HowManyDaysToRent : byte
    {
        FiveDays = 5,
        TenDays = 10,
        FifteenDays = 15,
        TwentyDays = 20,
        TwentyFiveDays = 25,
        ThirtyDays = 30

    }
}
