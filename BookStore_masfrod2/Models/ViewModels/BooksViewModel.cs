// Mason Frodsham masfrod2
// Mission 9 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_masfrod2.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }

        //pass PageInfo.cs to here so that it can be used in Index.cshtml
        public PageInfo PageInfo { get; set; }
    }
}
