using System;
using System.Collections.Generic;
using System.Text;

namespace lab5.Types.Accounts
{
	class CreditAccount : Account
	{
		public int ID;
		public Client client;
		public Bank bank;
		public double Cash;
		public DateTime CreatingDate;
		public double CreditLimit;
		public double Comission;
		public Dictionary<Transaction, double> Transactions = new Dictionary<Transaction, double>();
		public CreditAccount(Client client_, Bank bank_)
		{
			ID = GetHashCode();
			client = client_;
			bank = bank_;
			CreatingDate = DateTime.Now;
			CreditLimit = bank_.CreditAccountLimit;
			Comission = bank_.CreditComission;
		}
		public override void BalanceReplenishment(Transaction transaction)
		{
			Cash += transaction.Sum;
			transaction.DeleteSign = 0;
			Transactions.Add(transaction, Cash);
		}
		public override void Withdrawal(Transaction transaction)
		{
			if (client.Status == "Unactive" && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
			Cash -= transaction.Sum;
			transaction.DeleteSign = 1;
			Transactions.Add(transaction, Cash);
		}
		public override void Transfer(Transaction transaction, Account account)
		{
			if (client.Status == "Unactive" && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
			Cash -= transaction.Sum;
			account.Cash += transaction.Sum;
			transaction.DeleteSign = 1;
			Transactions.Add(transaction, Cash);
		}
		public override void TimeMachine(DateTime time)
		{
			TimeSpan time1 = time - CreatingDate;
			string nCountDay = String.Format("{0:d}", time1.Days);
			double intDay = Convert.ToDouble(nCountDay);
			if (intDay > 1)
			{
				if (Cash < 0)
				{
					for (int i = 0; i < intDay; i++)
					{
						Cash -= Math.Abs(Cash) * Comission;
					}
				}
			}
		}
	}
}
