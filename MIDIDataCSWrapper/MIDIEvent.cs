using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	public class MIDIEvent
	{
		#region DllImport

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_Create(int lTime, int lKind, byte[] pData, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateClone(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateSequenceNumber(int lTime, int lNum);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateTextEvent(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateTextEventEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateCopyrightNotice(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateCopyrightNoticeEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateTrackName(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateTrackNameEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateInstrumentName(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateInstrumentNameEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateLyric(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateLyricEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateMarker(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateMarkerEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateCuePoint(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateCuePointEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateProgramName(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateProgramNameEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateDeviceName(int lTime, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateDeviceNameEx(int lTime, int lCharCode, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateChannelPrefix(int lTime, int lNum);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreatePortPrefix(int lTime, int lNum);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateEndofTrack(int lTime);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateTempo(int lTime, int lTempo);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateSMPTEOffset(int lTime, int lMode, int lHour, int lMin, int lSec, int lFrame, int lSubFrame);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateTimeSignature(int lTime, int lnn, int ldd, int lcc, int lbb);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateKeySignature(int lTime, int lsf, int lmi);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateSequencerSpecific(int lTime, sbyte[] pBuf, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateNoteOff(int lTime, int lCh, int lKey, int lVel);

		#endregion

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
			//以下、チャンネルイベント
			NoteOff           = 0x80 ,
			NoteOff1,
			NoteOff2,
			NoteOff3,
			NoteOff4,
			NoteOff5,
			NoteOff6,
			NoteOff7,
			NoteOff8,
			NoteOff9,
			NoteOff10,
			NoteOff11,
			NoteOff12,
			NoteOff13,
			NoteOff14,
			NoteOff15,
			NoteOn            = 0x90 ,
			NoteOn1,
			NoteOn2,
			NoteOn3,
			NoteOn4,
			NoteOn5,
			NoteOn6,
			NoteOn7,
			NoteOn8,
			NoteOn9,
			NoteOn10,
			NoteOn11,
			NoteOn12,
			NoteOn13,
			NoteOn14,
			NoteOn15,
			KeyAfterTouch     = 0xA0 ,
			KeyAfterTouch1,
			KeyAfterTouch2,
			KeyAfterTouch3,
			KeyAfterTouch4,
			KeyAfterTouch5,
			KeyAfterTouch6,
			KeyAfterTouch7,
			KeyAfterTouch8,
			KeyAfterTouch9,
			KeyAfterTouch10,
			KeyAfterTouch11,
			KeyAfterTouch12,
			KeyAfterTouch13,
			KeyAfterTouch14,
			KeyAfterTouch15,
			ControlChange     = 0xB0 ,
			ControlChange1,
			ControlChange2,
			ControlChange3,
			ControlChange4,
			ControlChange5,
			ControlChange6,
			ControlChange7,
			ControlChange8,
			ControlChange9,
			ControlChange10,
			ControlChange11,
			ControlChange12,
			ControlChange13,
			ControlChange14,
			ControlChange15,
			ProgramChange     = 0xC0 ,
			ProgramChange1,
			ProgramChange2,
			ProgramChange3,
			ProgramChange4,
			ProgramChange5,
			ProgramChange6,
			ProgramChange7,
			ProgramChange8,
			ProgramChange9,
			ProgramChange10,
			ProgramChange11,
			ProgramChange12,
			ProgramChange13,
			ProgramChange14,
			ProgramChange15,
			ChannelAfterTouch = 0xD0 ,
			ChannelAfterTouch1,
			ChannelAfterTouch2,
			ChannelAfterTouch3,
			ChannelAfterTouch4,
			ChannelAfterTouch5,
			ChannelAfterTouch6,
			ChannelAfterTouch7,
			ChannelAfterTouch8,
			ChannelAfterTouch9,
			ChannelAfterTouch10,
			ChannelAfterTouch11,
			ChannelAfterTouch12,
			ChannelAfterTouch13,
			ChannelAfterTouch14,
			ChannelAfterTouch15,
			PitchBend         = 0xE0 ,
			PitchBend1,
			PitchBend2,
			PitchBend3,
			PitchBend4,
			PitchBend5,
			PitchBend6,
			PitchBend7,
			PitchBend8,
			PitchBend9,
			PitchBend10,
			PitchBend11,
			PitchBend12,
			PitchBend13,
			PitchBend14,
			PitchBend15,
			//チャンネルイベント終了
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
