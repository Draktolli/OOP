using System;
using lab3.Race_participants;


namespace lab3
{
	class Program
	{
		static void Main(string[] args)
		{
			var Race1 = new Race<Vehicle>(100000);
			Race1.AddParticipant(new Broom());
			Race1.AddParticipant(new FazeBoots());
			Race1.AddParticipant(new Centaur());
			Console.WriteLine(Race1.RaceResult());
			

			var Race3 = new Race<GroundVehicle>(100000);
			Race3.AddParticipant(new Centaur());
			Race3.AddParticipant(new FazeBoots());
			Race3.AddParticipant(new FastCamel());
			Console.WriteLine(Race3.RaceResult());
		}
	}
}
