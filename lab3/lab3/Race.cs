using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
	public class Race<T>
		where T : Vehicle
	{
		public double RaceDistance;
		public List<T> RaceParticipants = new List<T>();
		public Race (double distance)
		{
			if (distance <= 0)
			{
				throw new Exception("Can not create race with this distance");
			}
			else
			{
				RaceDistance = distance;
			}
		}
		public void AddParticipant(T vehicle)
		{
			RaceParticipants.Add(vehicle);
		}
		public T RaceResult()
		{
			T winner = RaceParticipants[0];
			double time = 0;
			foreach(T participant in RaceParticipants)
			{
				double curtime = winner.RaceTime(RaceDistance);
				if (curtime < time)
				{
					time = curtime;
					winner = participant;
				}
			}
			return winner;
		}
	}
}
