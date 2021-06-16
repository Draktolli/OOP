using System;
using System.Collections.Generic;
using System.Text;

namespace lab5.Types.Accounts
{
	public class DepositAccount : Account
	{
		public int ID;
		public Client client;
		public Bank bank;
		public double Cash;
		public DateTime CreatingDate;
		public double StartPercent;
		public DateTime FinishDate;
		public Dictionary<Transaction, double> Transactions = new Dictionary<Transaction, double>();

		public DepositAccount(Client client_, Bank bank_, DateTime finishdate, double cash)
		{
			ID = GetHashCode();
			client = client_;
			bank = bank_;
			Cash = cash;
			CreatingDate = DateTime.Now;
			FinishDate = finishdate;
			StartPercent = bank_.PercentForDeposit(cash);
		}
		public override void BalanceReplenishment(Transaction transaction)
		{
			if (client.Status == "Unactive" && transaction.Sum > bank.UnactiveTransSum)
			{
				Console.WriteLine("Please add all information");
			}
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
					percentsum += Cash * (bank.PercentForDeposit(Cash) / 365);
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
