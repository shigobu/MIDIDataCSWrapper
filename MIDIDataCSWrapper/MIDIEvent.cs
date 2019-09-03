using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	public class MIDIEvent
	{
		#region 列挙型

		/// <summary>
		/// 文字コードを表す列挙体
		/// </summary>
		public enum CharCodes
		{
			/// <summary>
			/// 指定なし。
			/// Windowsのコントロールパネルで指定されている文字コード(ANSI Code Page)でテキストエンコードするものとみなされる。
			/// </summary>
			NoCharCod = 0,
			/// <summary>
			/// {@LATIN} (ANSI)
			/// </summary>
			LATIN = 1252,
			/// <summary>
			/// {@JP} (Shift-JIS)
			/// </summary>
			JP = 932,
			/// <summary>
			/// UTF16リトルエンディアン
			/// </summary>
			UTF16LE = 1200,
			/// <summary>
			/// UTF16ビッグエンディアン
			/// </summary>
			UTF16BE = 1201
		}

		/// <summary>
		/// 長調か短調かを表します。
		/// </summary>
		public enum Keys
		{
			/// <summary>
			/// 長調
			/// </summary>
			Major = 0,
			/// <summary>
			/// 短調
			/// </summary>
			Minor = 1
		}

		/// <summary>
		/// SMPTEフレームモード
		/// </summary>
		public enum SMPTE
		{
			SMPTE24 = 0x00,
			SMPTE25 = 0x01,
			SMPTE30D = 0x02,
			SMPTE30N = 0x03 
		}

		/// <summary>
		/// MIDIイベントの種類
		/// </summary>
		public enum Kinds
		{
			SequenceNumber    = 0x00 ,
			TextEvent         = 0x01 ,
			CopyrightNotice   = 0x02 ,
			TrackName         = 0x03 ,
			InstrumentName    = 0x04 ,
			Lyric             = 0x05 ,
			Marker            = 0x06 ,
			CuePoint          = 0x07 ,
			ProgramName       = 0x08 ,
			DeviceName        = 0x09 ,
			ChannelPrefix     = 0x20 ,
			PortPrefix        = 0x21 ,
			EndOfTrack        = 0x2F ,
			Tempo             = 0x51 ,
			SmpteOffSet       = 0x54 ,
			TimeSignature     = 0x58 ,
			KeySignature      = 0x59 ,
			SequencerSpecific = 0x7F ,
			NoteOff           = 0x80 ,
			NoteOn            = 0x90 ,
			KeyAfterTouch     = 0xA0 ,
			ControlChange     = 0xB0 ,
			ProgramChange     = 0xC0 ,
			ChannelAfterTouch = 0xD0 ,
			PitchBend         = 0xE0 ,
			SysExStart        = 0xF0 ,
			SysExContinue     = 0xF7 
		}

		#endregion

		#region プロパティ
		internal IntPtr UnManagedObjectPointer { get; private set; }
        #endregion

        #region コンストラクタ

        /// <summary>
        /// MIDIイベントのポインタを指定して、オブジェクトを初期化します。
        /// </summary>
        /// <param name="intPtr">MIDIイベントのポインタ</param>
        public MIDIEvent(IntPtr intPtr)
        {
            UnManagedObjectPointer = intPtr;
        }

        #endregion

    }
}
