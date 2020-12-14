using NUnit.Framework;
using lab3;
using lab3.Race_participants;

namespace lab3.test
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			var Race1 = new Race<Vehicle>(100000);
			Race1.AddParticipant(new Broom());
			Race1.AddParticipant(new FazeBoots());
			Race1.AddParticipant(new Centaur());
			Assert.AreEqual(Race1.RaceParticipants[0], Race1.RaceResult());
		}
		public void Test2()
		{
			var Race2 = new Race<AirVehicle>(100000);
			Race2.AddParticipant(new Broom());
			Race2.AddParticipant(new FlyingCarpet());
			Race2.AddParticipant(new Mortar());
			Assert.AreEqual(Race2.RaceParticipants[0], Race2.RaceResult());
		}
		public void Test3()
		{
			var Race3 = new Race<GroundVehicle>(100000);
			Race3.AddParticipant(new Centaur());
			Race3.AddParticipant(new FazeBoots());
			Race3.AddParticipant(new FastCamel());
			Assert.AreEqual(Race3.RaceParticipants[0], Race3.RaceResult());
		}
	}

}