using System;
using System.Collections.Generic;
using System.Text;

namespace lab5.Types.Accounts
{
	public abstract class Account
	{
		public int ID;
		public Client client;
		public Bank bank;
		public double Cash;
		public DateTime CreatingDate;
		public Dictionary<Transaction, double> Transactions;
		public abstract void BalanceReplenishment(Transaction transaction);
		public abstract void Withdrawal(Transaction transaction);
		public abstract void Transfer(Transaction transaction, Account account);
		public abstract void TimeMachine(DateTime time);
	}
}
