using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab1;

namespace labs.test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Parser parser = new Parser();
			parser.Parse(parser.ParseReader("TextFile1.INI"));
			Assert.AreEqual(1, parser.Get<int>("COMMON", "LogNCDM"));
		}
		public void TestMethod2()
		{
			Parser parser = new Parser();
			parser.Parse(parser.ParseReader("TextFile1.INI"));
			Assert.AreEqual(900000.0, parser.Get<double>("NCMD", "SampleRate"));
		}
		public void TestMethod3()
		{
			Parser parser = new Parser();
			parser.Parse(parser.ParseReader("TextFile1.INI"));
			Assert.AreEqual("libusb", parser.Get<string>("ADC_DEV", "Driver"));
		}
	}
}
