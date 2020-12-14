using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
	public abstract class GroundVehicle : Vehicle
	{
		public string Name;
		public int Speed;
		public int TimeToRest;
		public double RestDuration;
		public abstract override double RaceTime(double distance);
	}
}
