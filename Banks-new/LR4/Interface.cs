using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class Interface
	{
		public MainBank bn;
		public Interface(MainBank bank)
		{
			bn = bank;
		}
		public void Start()
		{
			while(1 == 1)
			{
				Console.WriteLine("1-Register");
				Console.WriteLine("2-Create credit account");
				Console.WriteLine("3-Create debit account");
				Console.WriteLine("4-Create deposit account");
				Console.WriteLine("5-Replenishment");
				Console.WriteLine("6-Withdrawal");
				Console.WriteLine("7-Trasfer");
				Console.WriteLine("8-Check Balance");
				Console.WriteLine("9-Add Email Notification");
				Console.WriteLine("10-Change credit comission");
				Console.WriteLine("11-Time Machine");
				var key = Console.ReadLine();
				Client client = new Client();
				if (key == "1")
				{
					Console.WriteLine("Enter Name");
					var key1 = Console.ReadLine();
					string Name = key1;
					Console.WriteLine("Enter Surname");
					var key2 = Console.ReadLine();
					string Surname = key2;
					Console.WriteLine("Enter Adres");
					var key3 = Console.ReadLine();
					string adres = key3;
					Console.WriteLine("Enter Passport");
					var key4 = Console.ReadLine();
					int passport = Convert.ToInt32(key4);
					client.Name = Name;
					client.SurName = Surname;
					client.AddAdres(adres);
					client.AddPasportData(passport);
					client.CheckStatus();
				}
				if(key == "2")
				{
					foreach(Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}

					Console.WriteLine("Choose bank");
					var key1 = Console.ReadLine();

					Console.WriteLine("Write ID");
					var id = Convert.ToInt32(Console.ReadLine());
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));

					CreditAccount credit1 = new CreditAccount(id, client, Bank);
				}
				if (key == "3")
				{
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					Console.WriteLine("Choose bank");
					var key1 = Console.ReadLine();
					Console.WriteLine("Write ID");
					var id = Convert.ToInt32(Console.ReadLine());
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					DebitAccount debit1 = new DebitAccount(id, client, Bank);
				}
				if (key == "4")
				{
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					Console.WriteLine("Choose bank");
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					Console.WriteLine("Enter Sum");
					var sum = Convert.ToDouble(Console.ReadLine());
					Console.WriteLine("Write ID");
					var id = Convert.ToInt32(Console.ReadLine());
					DateTime date = new DateTime();
					date = DateTime.Now.AddYears(3);
					DepositAccount deposit1 = new DepositAccount(id, client, Bank, date, sum);

				}
				if(key == "5")
				{
					Console.WriteLine("Choose bank");
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));

					Console.WriteLine("Choose account");
					foreach (Account ac in Bank.Clients)
					{
							Console.WriteLine(ac.ID);
					}
					var id = Convert.ToInt32(Console.ReadLine());
					var acc = Bank.Clients.Find(item => item.ID.Equals(id));
					Console.WriteLine("Enter sum");
					var sum = Convert.ToDouble(Console.ReadLine());
					Transaction tr = new Transaction(acc, sum);
					acc.BalanceReplenishment(tr);
				}
				if(key == "6")
				{
					Console.WriteLine("Choose bank");
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					Console.WriteLine("Choose account");
					foreach (Account ac in Bank.Clients)
					{
							Console.WriteLine(ac.ID);
					}
					var id = Convert.ToInt32(Console.ReadLine());
					var acc = Bank.Clients.Find(item => item.ID.Equals(id));
					Console.WriteLine("Enter sum");
					var sum = Convert.ToDouble(Console.ReadLine());
					Transaction tr = new Transaction(acc, sum);
					acc.Withdrawal(tr);
				}
				if(key == "7")
				{
					Console.WriteLine("Choose bank");
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					var key7 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key7));
					Console.WriteLine("Choose accountFrom");
					foreach (Account ac in Bank.Clients)
					{
						Console.WriteLine(ac.ID);
					}
					int idfrom = Convert.ToInt32(Console.ReadLine());
					var accfrom = Bank.Clients.Find(item => item.ID.Equals(idfrom));

					Console.WriteLine("Choose bank");
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					var key71 = Console.ReadLine();
					var Bank1 = bn.Banks.Find(item => item.Name.Equals(key71));

					Console.WriteLine("Choose accountTo");
					foreach (Account ac in Bank.Clients)
					{
						Console.WriteLine(ac.ID);
					}
					int idto = Convert.ToInt32(Console.ReadLine());
					var accto = Bank.Clients.Find(item => item.ID.Equals(idto));

					Console.WriteLine("Enter sum");
					var Summ = Convert.ToInt32(Console.ReadLine());
					Transaction tr = new Transaction(accto, Summ);
					accfrom.Transfer(tr, accto);
					
				}
				if(key == "8")
				{
					Console.WriteLine("Choose bank");
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					Console.WriteLine("Choose Account");
					foreach (Account ac in Bank.Clients)
					{
							Console.WriteLine(ac.ID);
					}
					var id = Convert.ToInt32(Console.ReadLine());
					var acc = Bank.Clients.Find(item => item.ID.Equals(id));
					Console.WriteLine(acc.Cash);
				}
				if(key == "9")
				{
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					Console.WriteLine("Choose bank");
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					Bank.Attach(client);
					client.AddEmailNotify();
				}
				if(key == "10")
				{
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					Console.WriteLine("Choose bank");
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					Bank.ChangeCreditComission(0.02);
				}
				if(key == "11")
				{
					Console.WriteLine("Choose bank");
					foreach (Bank bank in bn.Banks)
					{
						Console.WriteLine(bank.Name);
					}
					var key1 = Console.ReadLine();
					var Bank = bn.Banks.Find(item => item.Name.Equals(key1));
					Console.WriteLine("Choose Account");
					foreach (Account ac in Bank.Clients)
					{
						Console.WriteLine(ac.ID);
					}
					var id = Convert.ToInt32(Console.ReadLine());
					var acc = Bank.Clients.Find(item => item.ID.Equals(id));
					var date1 = new DateTime(2022, 7, 7);
					acc.TimeMachine(date1);
				}
			}
			
		}
	}
}
