using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Book
{
    public class UpdateBookDto
    {
        [MaxLength(250)]
        public string Title { get; set; }
        
        [MaxLength(100)]
        public string Author { get; set; }
        
        [MaxLength(100)]
        public string Publisher { get; set; }

        [MaxLength(100)]
        public string Translator { get; set; }
        
        [MaxLength(15)]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Page must be a positive value.")]
        public int Page { get; set; }

        [MaxLength(4, ErrorMessage = "The year of the first edition should have a maximum of 4 digits")]
        public string FirstEditionYear { get; set; }

        public string Language { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }

        public int CategoryId { get; set; }
    }
}
