using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Race_participants
{
	public class Centaur : GroundVehicle
	{
		public Centaur() 
		{
			Speed = 15;
			Name = "Centaur";
			TimeToRest = 8;
			RestDuration = 2;
		}
		public override double RaceTime(double distance)
		{
			if (distance < 0)
			{
				throw new Exception("Can not calculate for this distance");
			}
			double racetime = 0;
			while (distance > 0)
			{
				distance -= Speed;
				racetime += 1;
				if (racetime % TimeToRest == 0)
				{
					racetime += RestDuration;
				}
			}
			return racetime;
		}
	}
}
