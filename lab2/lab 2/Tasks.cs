using System;
using System.Collections.Generic;
using System.Text;


namespace lab2
{
	public class Tasks
	{
		public List<Shop> ShopList = new List<Shop>();
		public List<Product> ProductList = new List<Product>();


		public void CreateProduct (string name)
		{
			ProductList.Add(new Product(ProductList.Count + 1, name, 0, 0));
		}
		public void CreateShop (string name, string adres)
		{
			ShopList.Add(new Shop(ShopList.Count + 1, name, adres));
		}
		public string GetCheapest (Product product)
		{
			string res = "";
			float price = float.MaxValue;
			foreach (Shop shop in ShopList)
			{
				Product shopproduct = shop.ProductsInShop.Find(item => item.Equals(product));
				if (shopproduct == null)
				{
					continue;
				}
				if (shopproduct.Price < price)
				{
					price = shopproduct.Price;
					res = shop.Name;
				}
			}
			return res;
		}
		public void CanBuyOnPrice (Shop shop, float price)
		{
			var ourshop = ShopList.Find(item => item.Equals(shop));
			if (ourshop == null)
			{
				throw new Exception("Shop does not Exist");
			}
			foreach (var product in ourshop.ProductsInShop)
			{
				float qty = price / product.Price;
				Console.WriteLine($"{Convert.ChangeType(qty, typeof(int))}, {product.Name}");
			}
		}
		public float BuyProductList (Shop shop, Product product, int amount)
		{
			var ourshop = ShopList.Find(item => item.Equals(shop));
			var ourproduct = ourshop.ProductsInShop.Find(item => item.Equals(product));
			if (ourshop == null)
			{
				throw new Exception("Shop does not exist");
			}
			if (ourproduct == null)
			{
				throw new Exception("Product does not exist");
			}
			if (ourproduct.Amount < amount)
			{
				Console.WriteLine("Shop does not has not enough products");
			}
			float res = ourproduct.Price * amount;
			return res;
		}
		public string CheapestShop(List<(Product product, int amount)> ProdList)
		{
			float lowestprice = float.MaxValue;
			string cheapestshop = "";
			foreach(Shop shop in ShopList)
			{
				foreach(var pack in ProdList)
				{
					var ourproduct = shop.ProductsInShop.Find(item => item.Equals(pack.product));
					if ( ourproduct is null)
					{
						break;
					}
					if (ourproduct.Amount < pack.amount)
					{
						break;
					}
					float thisshopprice = ourproduct.Price * pack.amount;
					if (thisshopprice < lowestprice)
					{
						lowestprice = thisshopprice;
						cheapestshop = shop.Name;
					}
				}
			}
			return cheapestshop;
		}


	}
}
