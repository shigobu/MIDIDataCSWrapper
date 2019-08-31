using System;

namespace MIDIDataCSWrapper
{
    /// <summary>
    /// MIDIDataLibの関数が失敗したときにスローされます。
    /// </summary>
    public class MIDIDataLibException : Exception
    {
        public MIDIDataLibException() : base("MIDIDataライブラリで不明なエラーが発生しました。")
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
