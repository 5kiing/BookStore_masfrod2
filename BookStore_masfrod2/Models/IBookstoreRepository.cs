// Mason Frodsham masfrod2
// Mission 9 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_masfrod2.Models
{

    // create passable object that takes from EFBookstoreRepository and gives to The Home Controller the book list.
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
