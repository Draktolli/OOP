using System;
using System.Collections.Generic;
using System.Text;

namespace lab5.Types
{
	public class Client
	{
		public string Name;
		public string SurName;
		public string Adres;
		public int PassportData;
		public string Status;

		public Client () { }
		public Client(string name, string surname)
		{
			Name = name;
			SurName = surname;
			Status = "Unactive";
		}
		public Client(string name, string surname, string adres, int passportdata)
		{
			Name = name;
			SurName = surname;
			Adres = adres;
			PassportData = passportdata;
			Status = "Active";
		}
		public void AddAdres (string adres)
		{
			Adres = adres;
		}
		public void AddPasportData (int passportdata)
		{
			PassportData = passportdata;
		}
		public void CheckStatus()
		{
			if(Adres != null && PassportData != 0)
			{
				Status = "Active";
			}
			else
			{
				Status = "Unactive";
			}
		}
	}
}
