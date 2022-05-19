using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class Bank
	{
		public int ID;
		public string Name;
		public double UnactiveTransSum;
		public double CreditComission;
		public double CreditAccountLimit;
		public double DebitPercent;
		public Dictionary<double, double> DepositPercent; //key - сумма выше которой будет процент value - процент
		public List<Account> Clients;
		public List<Client> Subscribers;

		public Bank(int id, string name, double unactivetranssum, double creditcomission, double creditlimit, Dictionary<double, double> depositpercent, double debitpercent)
		{
			ID = id;
			Name = name;
			UnactiveTransSum = unactivetranssum;
			CreditComission = creditcomission;
			CreditAccountLimit = creditlimit;
			DebitPercent = debitpercent;
			DepositPercent = depositpercent;
			Clients = new List<Account>();
			Subscribers = new List<Client>();
		}
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
		public void Attach(Client client)
		{
			Subscribers.Add(client);
		}
		public void Detach(Client client)
		{
			Subscribers.Remove(client);
		}
		public void ChangeCreditaccountLimit(double limit)
		{
			CreditAccountLimit = limit;
			Notify();
		}
		public void ChangeCreditComission(double comission)
		{
			CreditComission = comission;
			Notify();
		}
		public void Notify()
		{
			foreach(Client clients in Subscribers)
			{
				clients.Update(this);
			}
		}
	}
}
