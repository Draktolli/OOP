using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
	public abstract class AirVehicle : Vehicle
	{
		public string Name;
		public int Speed;
		public double DistanceReduction;
		public abstract override double RaceTime(double distance);
	}
}
