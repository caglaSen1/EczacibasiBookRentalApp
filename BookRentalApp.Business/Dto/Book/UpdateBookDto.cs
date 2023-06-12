using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Book
{
    public class UpdateBookDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(100)]
        public string Publisher { get; set; }

        [MaxLength(100)]
        public string Translator { get; set; }

        [Required]
        public string ISBN { get; set; }

        public int Page { get; set; }
        public string FirstEditionYear { get; set; }

        public string Language { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
