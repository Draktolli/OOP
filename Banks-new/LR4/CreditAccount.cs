using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	class CreditAccount : Account
	{
		public double CreditLimit;
		public double Comission;
		public CreditAccount(int id, Client client_, Bank bank_)
		{
			ID = id;
			Client = client_;
			bank = bank_;
			CreatingDate = DateTime.Now;
			CreditLimit = bank_.CreditAccountLimit;
			Comission = bank_.CreditComission;
			Transactions = new Dictionary<Transaction, double>();
			bank_.Clients.Add(this);
		}
		public override void BalanceReplenishment(Transaction transaction)
		{
			Cash += transaction.Sum;
			transaction.DeleteSign = 0;
			Transactions.Add(transaction, Cash);
		}
		public override void Withdrawal(Transaction transaction)
		{
			if (Client.Status == ClientStatus.Unactive && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
			this.Cash -= transaction.Sum;
			transaction.DeleteSign = 1;
			Transactions.Add(transaction, Cash);
		}
		public override void Transfer(Transaction transaction, Account account)
		{
			if (Client.Status == ClientStatus.Unactive && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
			this.Withdrawal(new Transaction(this, transaction.Sum));
			account.BalanceReplenishment(new Transaction(this, transaction.Sum));
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
