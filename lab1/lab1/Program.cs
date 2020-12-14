using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			Parser parser = new Parser();
			parser.Parse(parser.ParseReader("TextFile1.INI"));
			Console.WriteLine(parser.Get<int>("COMMON", "LogNCDM"));
			Console.WriteLine(parser.Get<double>("NCMD", "SampleRate"));
			Console.WriteLine(parser.Get<string>("ADC_DEV", "Driver"));
			Console.ReadKey();
		}
	}
}
