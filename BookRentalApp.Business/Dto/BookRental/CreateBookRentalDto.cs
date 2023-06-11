namespace BookRentalApp.Business.Dto.BookRental
{
    public class CreateBookRentalDto
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int RentalTerm { get; set; }
    }
}
