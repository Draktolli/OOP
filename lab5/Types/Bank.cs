using System;
using System.Collections.Generic;
using System.Text;
using lab5.Types.Accounts;

namespace lab5.Types
{
	public abstract class Bank
	{
		public int ID;
		public string Name;
		public double UnactiveTransSum;
		public double CreditComission;
		public double CreditAccountLimit;
		public double DebitPercent;
		Dictionary<Client, List<Account>> Clients = new Dictionary<Client, List<Account>>();

		public abstract double PercentForDeposit(double sum);
		public void DeleteTransaction(Account account, Transaction transaction)
		{
			if (transaction.DeleteSign == 0)
			{
				account.Cash -= transaction.Sum;
			}
			if (transaction.DeleteSign == 1)
			{
				account.Cash += transaction.Sum;
			}
			if (transaction.DeleteSign == 2)
			{
				account.Cash += transaction.Sum;
				transaction.account.Cash -= transaction.Sum;
			}
		}
	}
	
}
