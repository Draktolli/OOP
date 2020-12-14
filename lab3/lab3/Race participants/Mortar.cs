using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Race_participants
{
	public class Mortar : AirVehicle
	{
		public Mortar()
		{
			Speed = 8;
			Name = "Mortar";
			DistanceReduction = 0.06;
		}
		public override double RaceTime(double distance)
		{
			if (distance < 0)
			{
				throw new Exception("Can not calculate for this distance");
			}
			double racetime = 0;
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
