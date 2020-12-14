using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
	class Program
	{
		static void Main(string[] args)
		{
			var tasks = new Tasks();
			tasks.CreateProduct("Pdoruct 1");
			tasks.CreateProduct("Pdoruct 2");
			tasks.CreateProduct("Pdoruct 3");
			tasks.CreateProduct("Pdoruct 4");
			tasks.CreateProduct("Pdoruct 5");
			tasks.CreateProduct("Pdoruct 6");
			tasks.CreateProduct("Pdoruct 7");
			tasks.CreateProduct("Pdoruct 8");
			tasks.CreateProduct("Pdoruct 9");
			tasks.CreateProduct("Pdoruct 10");

			tasks.CreateShop("Shop 1", "Lomonosova 1");
			tasks.CreateShop("Shop 2", "Lomonosova 2");
			tasks.CreateShop("Shop 3", "Lomonosova 3");

			tasks.ShopList[0].AddProduct(tasks.ProductList[1], 90, 5);
			tasks.ShopList[0].AddProduct(tasks.ProductList[2], 50, 2);
			tasks.ShopList[0].AddProduct(tasks.ProductList[3], 22, 1);
			tasks.ShopList[0].AddProduct(tasks.ProductList[4], 70, 10);
			tasks.ShopList[0].AddProduct(tasks.ProductList[5], 100, 2);

			tasks.ShopList[1].AddProduct(tasks.ProductList[1], 70, 5);
			tasks.ShopList[1].AddProduct(tasks.ProductList[2], 20, 2);
			tasks.ShopList[1].AddProduct(tasks.ProductList[5], 15, 4);
			tasks.ShopList[1].AddProduct(tasks.ProductList[7], 37, 8);
			tasks.ShopList[1].AddProduct(tasks.ProductList[9], 60, 5);

			
			tasks.ShopList[2].AddProduct(tasks.ProductList[1], 20, 2);
			tasks.ShopList[2].AddProduct(tasks.ProductList[7], 15, 4);
			tasks.ShopList[2].AddProduct(tasks.ProductList[5], 37, 8);
			tasks.ShopList[2].AddProduct(tasks.ProductList[9], 50, 5);

			Console.WriteLine("Task 4");

			Console.WriteLine(tasks.GetCheapest(tasks.ProductList[1]));

			Console.WriteLine("task 5");
			tasks.CanBuyOnPrice(tasks.ShopList[0], 200);

			Console.WriteLine("task 6");
			Console.WriteLine(tasks.BuyProductList(tasks.ShopList[0], tasks.ProductList[3], 1));

			Console.WriteLine("task 7");
			List<(Product, int)> MyList = new List<(Product, int)>();
			MyList.Add((tasks.ProductList[1], 3));
			MyList.Add((tasks.ProductList[2], 2));
			Console.WriteLine(tasks.CheapestShop(MyList));
		}
	}
}	
