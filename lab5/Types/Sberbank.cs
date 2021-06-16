using System;
using System.Collections.Generic;
using System.Text;
using lab5.Types.Accounts;

namespace lab5.Types
{
	class Sberbank : Bank
	{
		public Sberbank()
		{
		 ID = 12331;
		 Name = "Sberbank";
		 UnactiveTransSum = 10000;
		 CreditComission = 0.01;
		 CreditAccountLimit = 100000;
		 DebitPercent = 0.02;
		}

		public override double PercentForDeposit(double sum)
		{
			double percent = 0;
			if (sum <= 50000)
			{
				percent = 0.03;
			}
			if (sum > 50000 && sum <= 100000)
			{
				percent = 0.04;
			}
			if (sum > 100000)
			{
				percent = 0.05;
			}
			return percent;
		}
		
	}
}
