// Mason Frodsham masfrod2
// Mission 9 

using BookStore_masfrod2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this is the controller for the shopping cart checkout process.
namespace BookStore_masfrod2.Controllers
{
    public class PurchaseController : Controller
    {
        // purchase repository is called here
        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }

        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        // this is the logic that allows or prevents the purchase to be completed and posted to the database

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if(cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();

                return RedirectToPage("/PurchaseComplete");
            }

            else
            {
                return View();
            }
        }
    }
}
