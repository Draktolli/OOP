using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public abstract class Account
	{
		public int ID;
		public Client Client;
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
