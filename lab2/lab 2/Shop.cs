using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
	public class Shop
	{
		public int ID;
		public string Name;
		public string Adres;
		public List<Product> ProductsInShop = new List<Product>();

		public Shop (int id, string name, string adres)
		{
			ID = id;
			Name = name;
			Adres = adres;
		}
		public void AddProduct(Product product, float price, int amount)
		{
			var check = ProductsInShop.Find(item => item.Equals(product));
			if (check == null)
			{
				ProductsInShop.Add(new Product(product.ID, product.Name, price, amount));
			} else
			{
				check.Amount += amount;
				check.Price = price;
			}

		}
		public override bool  Equals(object obj)
		{
			if (obj is Shop other)
			{
				return other.ID == ID;
			}
			return false;
		}
	}
}
