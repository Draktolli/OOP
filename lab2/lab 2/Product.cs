using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
	public class Product
	{
		public int ID;
		public string Name;
		public int Amount;
		public float Price;
		public Product (int id, string name,  float price, int amount)
		{
			ID = id;
			Name = name;
			Amount = amount;
			Price = price;
		}
		public override bool Equals(object obj)
		{
			if (obj is Product other)
			{
				return other.ID == ID;
			}
			return false;
		}
	}
}
