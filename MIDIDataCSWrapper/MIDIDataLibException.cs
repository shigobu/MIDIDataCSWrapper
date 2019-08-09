﻿using System;

namespace MIDIDataCSWrapper
{
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
