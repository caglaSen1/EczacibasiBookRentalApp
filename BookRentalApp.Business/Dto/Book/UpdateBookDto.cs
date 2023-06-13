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

        
        public string ISBN { get; set; }

        public int Page { get; set; }
        public string FirstEditionYear { get; set; }

        public string Language { get; set; }

        
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }

        
        public int CategoryId { get; set; }
    }
}
