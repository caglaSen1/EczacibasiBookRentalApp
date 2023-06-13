using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookRentalApp.Business.Dto.Book
{
    public class CreateBookDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string Publisher { get; set; }

        [Required]
        [MaxLength(100)]
        public string Translator { get; set; }

        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Page must be a positive value.")]
        public int Page { get; set; }

        [MaxLength(4, ErrorMessage = "The year of the first edition should have a maximum of 4 digits")]
        [MinLength(4, ErrorMessage = "The year of the first edition should have a minimum of 4 digits")]
        public string FirstEditionYear { get; set; }

        public string Language { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
