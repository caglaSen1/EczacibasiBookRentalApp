using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Data.Entity
{
    [Table("RentedBooks")]
    public class RentedBook : BaseEntity<int>
    {        
        public Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Book Book { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        [Column("RetunDate")]
        public DateTime? ReturnDate;

        [Column("RentalDate")]
        public DateTime RentalDate { get; set; } = DateTime.Now.Date;

        public byte HowManyDaysToRent { get; set; } = 0;

        public DateTime MustReturnDate { get; set; }

        /*private byte _howManyDaysToRent;
        
        [Column("HowManyDaysToRent")]
        public byte HowManyDaysToRent
        {
            get => _howManyDaysToRent;
            set
            {
                _howManyDaysToRent = value;
                _mustReturnDate = RentalDate.AddDays(_howManyDaysToRent);
            }
        }
        
        private DateTime _mustReturnDate;

        [Column("MustReturnDate")]
        public DateTime MustReturnDate => _mustReturnDate;

        public RentedBook(byte howManyDaysToRent)
        {
            _howManyDaysToRent = howManyDaysToRent;
            _mustReturnDate = RentalDate.AddDays(_howManyDaysToRent);
        }*/

        /*private DateTime _mustReturnDate;

        [Column("MustReturnDate")]
        public DateTime MustReturnDate
        {
            get => _mustReturnDate;
            set => _mustReturnDate = value;
        }

        private byte _howManyDaysToRent;

        [Column("HowManyDaysToRent")]
        public byte HowManyDaysToRent
        {
            get => _howManyDaysToRent;
            set
            {
                _howManyDaysToRent = value;
                MustReturnDate = RentalDate.AddDays(value);
            }
        }

        public byte HowManyDaysToRent { get; set; }; 

        public DateTime MustReturnDate { get; set; } = RentalDate.AddDays(HowManyDaysToRent);
*/


        /* public byte HowManyDaysToRent { get; set; }

         private DateTime _mustReturnDate;


         [Column("MustReturnDate")]
         public DateTime MustReturnDate
         {
             get => _mustReturnDate;
             set
             {

                 _mustReturnDate = RentalDate.AddDays(HowManyDaysToRent);
             }
         }


         [Column("ReturnDate")]
         public DateTime? ReturnDate
         {
             get => _returnDate;
             set
             {
                 _returnDate = value;
                 if (_returnDate.HasValue)
                 {
                     // ReturnDate değeri set edildiyse MustReturnDate'i güncelle
                     _mustReturnDate = _returnDate.Value.AddDays(_howManyDaysToRent);
                 }
             }
         }*/



        /*private byte _howManyDaysToRent;
         * [Column("HowManyDaysToRent")]
        public byte HowManyDaysToRent
        {
            get => _howManyDaysToRent;
            set
            {
                _howManyDaysToRent = value;
                _mustReturnDate = RentalDate.AddDays(value);
            }
        }
         * 
         * 
         * 
         * 

        public DateTime? ReturnDate { get; set; }

        private DateTime _returnDate;

        [Column("ReturnDate")]
        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                _returnDate = RentalDate.Date;
            }
        }

        private DateTime _mustReturnDate;
        [Column("MustReturnDate")]
        public DateTime MustReturnDate
        {
            get => _mustReturnDate;
            set => _mustReturnDate = value;
        }

        */


    }


}
