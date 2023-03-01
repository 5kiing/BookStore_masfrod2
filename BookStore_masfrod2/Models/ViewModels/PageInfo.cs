// Mason Frodsham masfrod2
// Mission 9 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_masfrod2.Models.ViewModels
{
    // create variables to dynamically create page tag helpers
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Figure out how many pages are needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
