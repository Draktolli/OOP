using System;
using lab5.Types;
using lab5.Types.Accounts;

namespace lab5
{
	class Program
	{
		static void Main(string[] args)
		{
			Client Anatolii = new Client("Anatolii", "Koverin");
			Console.WriteLine(Anatolii.Status);
			Anatolii.AddAdres("Звездная");
			Anatolii.AddPasportData(1234123456);
			Anatolii.CheckStatus();
			Console.WriteLine(Anatolii.Status);

			Sberbank sberbank = new Sberbank();
			CreditAccount credit1 = new CreditAccount(Anatolii, sberbank);

			Transaction trans1 = new Transaction(credit1, 50.0);
			credit1.BalanceReplenishment(trans1);
			Console.WriteLine(credit1.Cash);

			Transaction trans2 = new Transaction(credit1, 100.0);
			credit1.Withdrawal(trans2);
			Console.WriteLine(credit1.Cash);
			var date1 = new DateTime(2021, 7, 7);
			credit1.TimeMachine(date1);
			Console.WriteLine(credit1.Cash);
			Console.WriteLine(credit1.CreditLimit);
		}
	}
}
