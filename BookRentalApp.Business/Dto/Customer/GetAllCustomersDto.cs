﻿using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Business.Dto.Customer
{
    public class GetAllCustomersDto
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
