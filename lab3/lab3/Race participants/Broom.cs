using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Race_participants
{
	public class Broom : AirVehicle
	{
		public Broom()
		{
			Speed = 20;
			Name = "Broom";
			DistanceReduction = 0.01;
		}
		public override double RaceTime(double distance)
		{
			if (distance < 0)
			{
				throw new Exception("Can not calculate for this distance");
			}
			double racetime = 0;
			double st;
			st = distance / 1000;
			DistanceReduction *= st; 
			distance -= (distance * DistanceReduction);
			while (distance > 0)
			{
				distance -= Speed;
				racetime += 1;
			}
			return racetime;
		}
	}
}
