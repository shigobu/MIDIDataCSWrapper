using System;

namespace MIDIDataCSWrapper
{
    class MIDIDataException : Exception
    {
        public MIDIDataException() : base()
        {
        }
        public MIDIDataException(string message) : base(message)
        {
        }
        public MIDIDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
