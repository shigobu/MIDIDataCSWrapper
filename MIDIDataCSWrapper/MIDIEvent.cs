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

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateNoteOn(int lTime, int lCh, int lKey, int lVel);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateKeyAftertouch(int lTime, int lCh, int lKey, int lVal);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateControlChange(int lTime, int lCh, int lNum, int lVal);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateProgramChange(int lTime, int lCh, int lNum);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateChannelAftertouch(int lTime, int lCh, int lVal);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreatePitchBend(int lTime, int lCh, int lVal);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateSysExEvent(int lTime, byte[] pBuf, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateNoteOnNoteOff(int lTime, int lCh, int lKey, int lVel1, int lVel2, int lDur);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateNoteOnNoteOn0(int lTime, int lCh, int lKey, int lVel, int lDur);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_CreateNote(int lTime, int lCh, int lKey, int lVel, int lDur);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_Delete(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_DeleteSingle(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsMetaEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsSequenceNumber(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsTextEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsCopyrightNotice(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsInstrumentName(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsLyric(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsMarker(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsCuePoint(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsProgramName(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsDeviceName(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsChannelPrefix(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsPortPrefix(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsEndofTrack(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsTempo(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsSMPTEOffset(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsTimeSignature(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsKeySignature(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsSequencerSpecific(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsMIDIEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsNoteOff(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsNoteOn(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsKeyAftertouch(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsProgramChange(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsControlChange(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsChannelAftertouch(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsPitchBend(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsSysExEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsFloating(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsCombined(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsNoteOnNoteOff(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsNoteOnNoteOn0(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsNote(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsPatchChange(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsRPNChange(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_IsNRPNChange(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetTime(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetKind(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetLen(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetData(IntPtr pMIDIEvent, IntPtr pData, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetCharCode(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetText(IntPtr pMIDIEvent, StringBuilder pData, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetTempo(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetSMPTEOffset(IntPtr pMIDIEvent, out int pMode, out int pHour, out int pMin, out int pSec, out int pFrame, out int pSubFrame);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetTimeSignature(IntPtr pMIDIEvent, out int pnn, out int pdd, out int pcc, out int pbb);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetKeySignature(IntPtr pMIDIEvent, out int psf, out int pmi);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetMIDIMessage(IntPtr pMIDIEvent, IntPtr pMessage, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetChannel(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetKey(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetVelocity(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetDuration(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetNumber(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetValue(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetBank(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetBankMSB(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetBankLSB(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetDataEntryMSB(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_GetPatchNum(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetNextEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetPrevEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetNextSameKindEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetPrevSameKindEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetFirstCombinedEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetLastCombinedEvent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_GetParent(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetTime(IntPtr pMIDIEvent, int lTime);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetTimeSingle(IntPtr pMIDIEvent, int lTime);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetKind(IntPtr pMIDIEvent, int lKind);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetData(IntPtr pMIDIEvent, byte[] pData, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetCharCode(IntPtr pMIDIEvent, int lCharCode);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetText(IntPtr pMIDIEvent, string pszText);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetTempo(IntPtr pMIDIEvent, int lTempo);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_SetSMPTEOffset(IntPtr pMIDIEvent, int pMode, int lHour, int lMin, int lSec, int lFrame, int lff);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetTimeSignature(IntPtr pMIDIEvent, int lnn, int ldd, int lcc, int lbb);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetKeySignature(IntPtr pMIDIEvent, int lsf, int lmi);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetMIDIMessage(IntPtr pMIDIEvent, sbyte[] pMessage, int lLen);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetChannel(IntPtr pMIDIEvent, int lChannel);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetKey(IntPtr pMIDIEvent, int lKey);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetVelocity(IntPtr pMIDIEvent, int lVelocity);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetDuration(IntPtr pMIDIEvent, int lDuration);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetNumber(IntPtr pMIDIEvent, int lNumber);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetValue(IntPtr pMIDIEvent, int lValue);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetBank(IntPtr pMIDIEvent, int lBank);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetBankMSB(IntPtr pMIDIEvent, int lBankMSB);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetBankLSB(IntPtr pMIDIEvent, int lBankLSB);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetDataEntryMSB(IntPtr pMIDIEvent, int lDataEntryMSB);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_SetPatchNum(IntPtr pMIDIEvent, int lNum);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_Combine(IntPtr pMIDIEvent);

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIEvent_Chop(IntPtr pMIDIEvent);

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

		private IntPtr _unManagedObjectPointer = IntPtr.Zero;
		/// <summary>
		/// アンマネージドのオブジェクトポインタ
		/// </summary>
		internal IntPtr UnManagedObjectPointer
		{
			get
			{
				if (_unManagedObjectPointer != IntPtr.Zero)
				{
					return _unManagedObjectPointer;
				}
				else
				{
					throw new MIDIDataLibException("UnManagedObjectPointerはnullです。");
				}
			}
			private set
			{
				_unManagedObjectPointer = value;
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// MIDIイベントのポインタを指定して、オブジェクトを初期化します。
		/// </summary>
		/// <param name="intPtr">MIDIイベントのポインタ</param>
		internal MIDIEvent(IntPtr intPtr)
        {
            UnManagedObjectPointer = intPtr;
        }

		/// <summary>
		/// 必要な情報を入力して、オブジェクトを初期化します。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="kind">イベントの種類</param>
		/// <param name="data">データ部</param>
		public MIDIEvent(int time, Kinds kind, byte[] data)
		{
			IntPtr intPtr = MIDIEvent_Create(time, (int)kind, data, data.Length);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("MIDIイベントの生成に失敗しました。");
			}
			UnManagedObjectPointer = intPtr;
		}

		/// <summary>
		/// 指定のオブジェクトを複製します。
		/// </summary>
		/// <param name="midiEvent">コピー元となる任意のMIDIイベント</param>
		public MIDIEvent(MIDIEvent midiEvent)
		{
			IntPtr intPtr = MIDIEvent_CreateClone(midiEvent.UnManagedObjectPointer);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("MIDIイベントの複製に失敗しました。");
			}
			UnManagedObjectPointer = intPtr;
		}

		#endregion

		#region 静的メソッド

		/// <summary>
		/// シーケンス番号イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="num">シーケンス番号(0～65535)</param>
		/// <returns>シーケンス番号イベント</returns>
		public static MIDIEvent CreateSequenceNumber(int time, int num)
		{
			if (num < 0 || 65535 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "シーケンス番号は、0から65535の範囲内である必要があります。");
			}

			IntPtr intPtr = MIDIEvent_CreateSequenceNumber(time, num);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("シーケンス番号イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// テキストイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>テキストイベント</returns>
		public static MIDIEvent CreateTextEvent(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateTextEvent(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("テキストイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してテキストイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>テキストイベント</returns>
		public static MIDIEvent CreateTextEventEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateTextEventEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("テキストイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		#endregion

	}
}
