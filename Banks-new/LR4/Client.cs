using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class Client 
	{
		public string Name;
		public string SurName;
		public string Adres;
		public int PassportData;
		public ClientStatus Status;
		public List<INotify> Notifies = new List<INotify>();
		public Client() { }
		public Client(string name, string surname)
		{
			Name = name;
			SurName = surname;
			Status = ClientStatus.Unactive;
		}
		public Client(string name, string surname, string adres, int passportdata)
		{
			Name = name;
			SurName = surname;
			Adres = adres;
			PassportData = passportdata;
			Status = ClientStatus.Active;
		}
		public void AddAdres(string adres)
		{
			Adres = adres;
		}
		public void AddPasportData(int passportdata)
		{
			PassportData = passportdata;
		}
		public void CheckStatus()
		{
			if (Adres != null && PassportData != 0)
			{
				Status = ClientStatus.Active;
			}
			else
			{
				Status = ClientStatus.Unactive;
			}
		}
		public void AddEmailNotify()
		{
			Notifies.Add(new EmailNotify());
		}
		public void Update(Bank bank)
		{
			foreach(INotify nt in Notifies)
			{
				nt.SendNotify();
			}
		}
	}
}
