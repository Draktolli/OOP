using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class Transaction
	{
		public int TransactionID;
		public Account account;
		public DateTime TransactionDate;
		public double Sum;
		public double DeleteSign; // 0 - поплнение 1 - снятие 2 - перевод
		public Transaction(Account account_, double sum)
		{
			TransactionID = GetHashCode();
			account = account_;
			TransactionDate = DateTime.Now;
			Sum = sum;
		}
	}
}
