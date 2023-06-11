using System;
using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Data.Entity
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
