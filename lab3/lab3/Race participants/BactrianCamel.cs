using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
	public class BactrianCamel : GroundVehicle
	{
		public BactrianCamel()
		{
			Speed = 10;
			Name = "BactrianCamel";
			TimeToRest = 30;
			RestDuration = 5;
		}
		public override double RaceTime(double distance)
		{
			if (distance < 0)
			{
				throw new Exception("Can not calculate for this distance");
			}
			int restcount = 0;
			double racetime = 0;
			while (distance > 0)
			{
				distance -= Speed;
				racetime += 1;
				if (racetime % TimeToRest == 0)
				{
					racetime += RestDuration;
					restcount++;
				}
				if (restcount >= 1)
				{
					RestDuration = 8;
				}
			}
			return racetime;
		}
	}
}
