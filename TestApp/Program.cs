using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MIDIDataCSWrapper;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			MIDIData mIDIData = new MIDIData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "無題1.skj"));
			foreach (MIDITrack item in mIDIData)
			{
				Console.WriteLine(item.ForeColor.ToString());
			}

			Console.Read();
		}
	}
}
