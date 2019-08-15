using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	public class MIDITrack
	{
		internal MIDITrack(IntPtr ipTrack)
		{
			this.UnManagedObjectPointer = ipTrack;
		}

		internal IntPtr UnManagedObjectPointer { get; private set; }
	}
}
