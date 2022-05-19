using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class MainBank
	{
		public List<Bank> Banks;

		public MainBank()
		{
			Banks = new List<Bank>();
		}
		public Bank CreateBank(int id, string name, double unactivetranssum, double creditcomission, double creditlimit, Dictionary<double,double> depositpercent, double debitpercent)
		{
			Bank bank = new Bank(id, name, unactivetranssum, creditcomission, creditlimit, depositpercent, debitpercent);
			Banks.Add(bank);
			return bank;
		}
		public void Transfer (Transaction transaction, Account accin, Account accout, Bank bank)
		{
			if (accin.bank.Equals(bank))
			{
				accout.Transfer(transaction, accin);
			}
		}
	}
}
