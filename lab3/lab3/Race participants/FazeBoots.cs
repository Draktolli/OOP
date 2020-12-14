using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Race_participants
{
	public class FazeBoots : GroundVehicle
	{
		public FazeBoots()
		{
			Speed = 6;
			Name = "FazeBoots";
			TimeToRest = 60;
			RestDuration = 10;
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
				if (restcount > 0)
				{
					RestDuration = 5;
				}
			}
			return racetime;
		}
	}
}
