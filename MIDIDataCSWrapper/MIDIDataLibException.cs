using System;

namespace MIDIDataCSWrapper
{
    /// <summary>
    /// MIDIDataLibの関数が失敗したときにスローされます。
    /// </summary>
    class MIDIDataLibException : Exception
    {
        public MIDIDataLibException() : base()
        {
        }
        public MIDIDataLibException(string message) : base(message)
        {
        }
        public MIDIDataLibException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
