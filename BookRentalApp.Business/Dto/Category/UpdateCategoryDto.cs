using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
    }
}
