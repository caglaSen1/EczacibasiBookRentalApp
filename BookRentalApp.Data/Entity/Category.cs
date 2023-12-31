﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Data.Entity
{
    [Table("Categories")]
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> BookList { get; set; }
    }

}
