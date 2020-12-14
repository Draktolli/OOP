using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab2;
using System;
using System.Collections.Generic;
using System.Text;

namespace labs2.test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var tasks = new Tasks();
			tasks.CreateProduct("Pdoruct 1");
			tasks.CreateShop("Shop 1", "Lomonosova 1");
			tasks.CreateShop("Shop 2", "Lomonosova 2");
			tasks.CreateShop("Shop 3", "Lomonosova 3");
			tasks.ShopList[0].AddProduct(tasks.ProductList[0], 90, 5);
			tasks.ShopList[1].AddProduct(tasks.ProductList[0], 70, 5);
			tasks.ShopList[2].AddProduct(tasks.ProductList[0], 20, 2);
			Assert.AreEqual("Shop 3", tasks.GetCheapest(tasks.ProductList[0]));
		}
		public void TestMethod3()
		{
			var tasks = new Tasks();
			tasks.CreateProduct("Pdoruct 1");
			tasks.CreateShop("Shop 1", "Lomonosova 1");
			tasks.ShopList[0].AddProduct(tasks.ProductList[0], 90, 5);
			Assert.AreEqual(180, tasks.BuyProductList(tasks.ShopList[0], tasks.ProductList[3], 1));
		}
		public void TestMethod4()
		{
			var tasks = new Tasks();
			tasks.CreateProduct("Pdoruct 1");
			tasks.CreateProduct("Pdoruct 2");
			tasks.CreateShop("Shop 1", "Lomonosova 1");
			tasks.CreateShop("Shop 2", "Lomonosova 2");
			tasks.CreateShop("Shop 3", "Lomonosova 3");
			tasks.ShopList[0].AddProduct(tasks.ProductList[0], 90, 5);
			tasks.ShopList[0].AddProduct(tasks.ProductList[1], 50, 2);
			tasks.ShopList[1].AddProduct(tasks.ProductList[0], 70, 5);
			tasks.ShopList[1].AddProduct(tasks.ProductList[1], 20, 2);
			tasks.ShopList[2].AddProduct(tasks.ProductList[0], 20, 2);
			tasks.ShopList[2].AddProduct(tasks.ProductList[1], 15, 4);
			List<(Product, int)> MyList = new List<(Product, int)>();
			MyList.Add((tasks.ProductList[0], 3));
			MyList.Add((tasks.ProductList[1], 2));
			Assert.AreEqual("Shop 2", tasks.CheapestShop(MyList));
		}
	}
}

