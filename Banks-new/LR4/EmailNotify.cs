using System;
using System.Collections.Generic;
using System.Text;

namespace LR4
{
	public class EmailNotify : INotify
	{
		public void SendNotify()
		{
			Console.WriteLine("New Email");
		}
	}
}
