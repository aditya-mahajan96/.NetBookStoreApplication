﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahajan_BookStore_921.Models
{
    public class CartItemList
    {
        private List<CartItem> cartItems;

        public CartItemList()
        {
            cartItems = new List<CartItem>();
        }

        public int Count
        {
            get { return cartItems.Count; }
        }

        public CartItem this[int index]
        {
            get { return cartItems[index]; }
            set { cartItems[index] = value; }
        }

        public CartItem this[string id]
        {
            get
            {
                foreach (CartItem c in cartItems)
                    if (c.bookValue.ProductID == id) return c;
                return null;
            }
        }

        public static CartItemList GetCartOrCreateIt()
        {
            CartItemList cart = (CartItemList)HttpContext.Current.Session["Cart"];
            if (cart == null)
                HttpContext.Current.Session["Cart"] = new CartItemList();
            return (CartItemList)HttpContext.Current.Session["Cart"];
        }

        public void AddItem(Book product, int quantity)
        {
            CartItem c = new CartItem(product, quantity);
            cartItems.Add(c);
        }

        public void RemoveAt(int index)
        {
            cartItems.RemoveAt(index);
        }

        public void Clear()
        {
            cartItems.Clear();
        }
    }

}