using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Race_participants
{
	public class FlyingCarpet : AirVehicle
	{
		public FlyingCarpet()
		{
			Speed = 10;
			Name = "FlyingCarpet";
			DistanceReduction = 0;
		}
		public override double RaceTime(double distance)
		{
			if (distance < 0)
			{
				throw new Exception("Can not calculate for this distance");
			}
			double racetime = 0;
			if (distance == 1000 && distance < 5000)
			{
				DistanceReduction = 0.03;
			}
			if (distance >= 5000 && distance < 10000)
			{
				DistanceReduction = 0.1;
			}
			if (distance > 10000)
			{
				DistanceReduction= 0.05;
			}
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
