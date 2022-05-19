using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class DepositAccount : Account
	{
		public double StartPercent;
		public DateTime FinishDate;

		public DepositAccount(int id, Client client_, Bank bank_, DateTime finishdate, double cash)
		{
			ID = id;
			Client = client_;
			bank = bank_;
			Cash = cash;
			CreatingDate = DateTime.Now;
			FinishDate = finishdate;
			Transactions = new Dictionary<Transaction, double>();
			foreach (KeyValuePair<double, double> pair in bank.DepositPercent)
			{
				StartPercent = pair.Value;
				if (pair.Key < cash)
				{
					continue;
				}
				else
				{
					break;
				}
			}
			bank_.Clients.Add(this);
		}
		public override void BalanceReplenishment(Transaction transaction)
		{
			if (Client.Status == ClientStatus.Unactive && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
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
			if (DateTime.Now < FinishDate)
			{
				Console.WriteLine("Can't withdrawal at this date");
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
			if (DateTime.Now < FinishDate)
			{
				Console.WriteLine("Can't withdrawal at this date");
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
					percentsum += Cash * (StartPercent / 365);
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
