﻿namespace BookRentalApp.Business.Dto.Book
{
    public class GetAllBooksDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }

        public int Page { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsAvailable { get; set; }
    }
}
