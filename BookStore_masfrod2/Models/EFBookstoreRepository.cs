// Mason Frodsham masfrod2
// Mission 9 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_masfrod2.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        // create context to pass to IBookstoreRepository that will give the dynamic bookstore book list.
        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
