using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
	public abstract class Vehicle
	{
		public string Name;
		public int Speed;
		public abstract double RaceTime(double distance);
	}
}
