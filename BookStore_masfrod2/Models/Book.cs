// Mason Frodsham masfrod2
// Mission 9 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore_masfrod2.Models
{
    public partial class Book
        // Here is the scaffolded data.
        // I added a key annotation to the BookId and Required annotations to the rest
    {
        [Key]
        [Required]
        public long BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public long PageCount { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
