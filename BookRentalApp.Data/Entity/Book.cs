using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Data.Entity
{
    [Table("Books")]
    public class Book : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string? ISBN { get; set; } //International Standard Book Number

        public int Page { get; set; }

        private double _price;

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The price must be greater than 0.");
                }

                _price = value;
            }
        }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public BookRental BookRental { get; set; }

        private bool _isAvailable = true;
        public bool IsAvailable
        {
            get => _isAvailable;
            set
            {
                if (BookRental.IsRented == false)
                {
                    _isAvailable = true;
                }
                else
                {
                    _isAvailable = false;
                }
                    
            }
        }

    }
}
