using System;
using System.Collections.Generic;
using System.Text;
using lab5.Types.Accounts;

namespace lab5.Types
{
	public class Transaction
	{
		public int TransactionID;
		public Account account;
		public DateTime TransactionDate;
		public double Sum;
		public double DeleteSign; // 0 - поплнение 1 - снятие 2 - перевод
		public Transaction (Account account_, double sum)
		{
			TransactionID = GetHashCode();
			account = account_;
			TransactionDate = DateTime.Now;
			Sum = sum;
		}
	}
}
