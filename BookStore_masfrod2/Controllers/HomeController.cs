// Mason Frodsham masfrod2
// Mission 11

using BookStore_masfrod2.Models;
using BookStore_masfrod2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_masfrod2.Controllers
{
    public class HomeController : Controller
    {
        // create repository variable to pass the bookstore list to the page dynamically
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        // perform the logic to determine how many pages are needed to include the list
        public IActionResult Index(string category, int productPage)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((productPage - 1) * pageSize)
                .Take(pageSize),

                //this filters the books based on category using the repository.
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = productPage
                }
            };

            return View(x);
        }
    }
}
