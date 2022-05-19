using System;
using System.Collections.Generic;

namespace LR4
{
	class Program
	{
		static void Main(string[] args)
		{

			MainBank mainBank = new MainBank();
			Client client = new Client("asd", "asd", "asd", 123);
			Dictionary<double, double> dict = new Dictionary<double, double>();
			dict.Add(0, 0.03);
			dict.Add(50000, 0.04);
			dict.Add(100000, 0.05);
			Bank Sberbank = mainBank.CreateBank(1, "Sber", 10000, 0.01, 100000, dict, 0.05);
			Interface int1 = new Interface(mainBank);
			int1.Start();
			CreditAccount credit1 = new CreditAccount(1, client, Sberbank);
			CreditAccount credit2 = new CreditAccount(2, client, Sberbank);
			Transaction tr1 = new Transaction(credit1, 50);
			credit1.BalanceReplenishment(tr1);
			Console.WriteLine(credit1.Cash);
			Transaction tr2 = new Transaction(credit2, 100);
			credit1.Transfer(tr2, credit2);
			Console.WriteLine(credit1.Cash);
			Console.WriteLine(credit2.Cash);
		}
	}
}
