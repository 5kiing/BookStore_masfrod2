// Mason Frodsham masfrod2
// Mission 11

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this takes care of creating the queriable Purchases object
namespace BookStore_masfrod2.Models
{
    public interface IPurchaseRepository
    {
        public IQueryable<Purchase> Purchases { get; }

        public void SavePurchase(Purchase purchase);
    }
}
