using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TusklaBlazor.Shared.Interfaces;
using TusklaBlazor.Shared.Services;
using TusklaBlazor.Shared.Models;
using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace TusklaBlazor.Shared.Services
{
    public class CartService
    {
        private readonly ILocalStorageService _localStorage;

        public List<CartItem> CartItems { get; private set; }

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            CartItems = new List<CartItem>();
        }

        public void AddToCart(Product product)
        {
            Console.WriteLine("Entered AddToCart"); // Print to console

            var existingItem = CartItems.FirstOrDefault(item => item.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = 1 });

            }
        }

        public void UpdateQuantity(CartItem cartItem, int quantity)
        {
            if (quantity > 0)
            {
                cartItem.Quantity = quantity;
            }
            else
            {
                CartItems.Remove(cartItem);
            }
        }

        public decimal GetCartTotal()
        {
            return CartItems.Sum(item => item.Quantity * item.Product.Price);
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems;
        }

        public async Task ProcessCheckout()
        {
            // Implement checkout process, e.g., save order to database, clear cart, etc.
            await Task.Delay(1000); // Simulating asynchronous operation
            CartItems.Clear();
            // Redirect to order confirmation page or show success message
        }
    }
}
