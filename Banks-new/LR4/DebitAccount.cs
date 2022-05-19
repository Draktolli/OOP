using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class DebitAccount : Account
	{
		public double Percent;
		public DebitAccount(int id, Client client_, Bank bank_)
		{
			ID = id;
			Client = client_;
			bank = bank_;
			CreatingDate = DateTime.Now;
			Percent = bank_.DebitPercent;
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
			if (transaction.Sum > Cash)
			{
				Console.WriteLine("Sum is too big, can't withdrawal from debit account");
			}
			else
			{
				Cash -= transaction.Sum;
				transaction.DeleteSign = 1;
				Transactions.Add(transaction, Cash);
			}
		}
		public override void Transfer(Transaction transaction, Account account)
		{
			if (Client.Status == ClientStatus.Unactive && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
			if (transaction.Sum > Cash)
			{
				Console.WriteLine("Sum is too big, can't withdrawal from debit account");
			}
			else
			{
				Cash -= transaction.Sum;
				account.Cash += transaction.Sum;
				transaction.DeleteSign = 1;
				Transactions.Add(transaction, Cash);
			}
		}
		public override void TimeMachine(DateTime time)
		{
			double percentsum = 0.0;
			int daycount = 0;
			TimeSpan time1 = time - CreatingDate;
			string nCountDay = String.Format("{0:d}", time1.Days);
			double intDay = Convert.ToDouble(nCountDay);
			if (intDay > 30)
			{
				for (int i = 0; i < intDay; i++)
				{
					percentsum += Cash * (Percent / 365);
					daycount += 1;
					if (daycount >= 30)
					{
						Cash += percentsum;
						daycount = 0;
					}
				}
			}
		}
	}
}
