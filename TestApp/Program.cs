using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIDIDataCSWrapper;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			MIDIData mIDIData = new MIDIData(@"C:\Users\笠松茂信\Desktop\無題1.skj");
			foreach (MIDITrack item in mIDIData)
			{
				Console.WriteLine(item.ForeColor.ToString());
			}

			Console.Read();
		}
	}
}
