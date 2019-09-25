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
		private static extern int MIDIEvent_IsTrackName(IntPtr pMIDIEvent);

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
		private static extern int MIDIEvent_SetSMPTEOffset(IntPtr pMIDIEvent, int pMode, int lHour, int lMin, int lSec, int lFrame, int lff);

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

		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIEvent_ToString(IntPtr pMIDIEvent, StringBuilder pBuf, int lLen);

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
			/// 指定なしだが、{@LATIN} (ANSI)であるものと推定される。
			/// </summary>
			NoCharCodLATIN = (0x10000 | 1252),
			/// <summary>
			/// 指定なしだが、{@JP} (Shift-JIS)であるものと推定される。
			/// </summary>
			NoCharCodJP = (0x10000 | 932),
			/// <summary>
			/// 指定なしだが、UTF16リトルエンディアンであるものと推定される。
			/// </summary>
			NoCharCodUTF16LE = (0x10000 | 1200),
			/// <summary>
			/// 指定なしだが、UTF16ビッグエンディアンであるものと推定される。
			/// </summary>
			NoCharCodUTF16BE = (0x10000 | 1201),
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

		/// <summary>
		/// メタイベント(0x00～0x7F)であるかどうか調べる。
		/// </summary>
		public bool IsMetaEvent
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsMetaEvent(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// シーケンス番号イベントであるかどうか調べる。
		/// </summary>
		public bool IsSequenceNumber
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsSequenceNumber(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// テキストイベントであるかどうか調べる。
		/// </summary>
		public bool IsTextEvent
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsTextEvent(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 著作権イベントであるかどうか調べる。
		/// </summary>
		public bool IsCopyrightNotice
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsCopyrightNotice(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// シーケンス名／トラック名イベントであるかどうか調べる
		/// </summary>
		public bool IsTrackName
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsTrackName(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// インストゥルメント名イベントであるかどうか調べる。
		/// </summary>
		public bool IsInstrumentName
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsInstrumentName(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 歌詞イベントであるかどうか調べる。
		/// </summary>
		public bool IsLyric
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsLyric(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// マーカーイベントであるかどうか調べる。
		/// </summary>
		public bool IsMarker
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsMarker(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// キューポイントイベントであるかどうか調べる。
		/// </summary>
		public bool IsCuePoint
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsCuePoint(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// プログラム名イベントであるかどうか調べる。
		/// </summary>
		public bool IsProgramName
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsProgramName(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// デバイス名イベントであるかどうか調べる。
		/// </summary>
		public bool IsDeviceName
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsDeviceName(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// チャンネルプリフィックスイベントであるかどうか調べる。
		/// </summary>
		public bool IsChannelPrefix
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsChannelPrefix(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// ポートプリフィックスイベントであるかどうか調べる。
		/// </summary>
		public bool IsPortPrefix
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsPortPrefix(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// エンドオブトラックイベントであるかどうか調べる。
		/// </summary>
		public bool IsEndofTrack
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsEndofTrack(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// テンポ設定イベントであるかどうか調べる。
		/// </summary>
		public bool IsTempo
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsTempo(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// SMPTEオフセットイベントであるかどうか調べる。
		/// </summary>
		public bool IsSMPTEOffset
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsSMPTEOffset(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 拍子記号イベントであるかどうか調べる。
		/// </summary>
		public bool IsTimeSignature
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsTimeSignature(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 調性記号イベントであるかどうか調べる。
		/// </summary>
		public bool IsKeySignature
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsKeySignature(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// シーケンサー独自のイベントであるかどうか調べる。
		/// </summary>
		public bool IsSequencerSpecific
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsSequencerSpecific(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// MIDIチャンネルイベントであるかどうか調べる。
		/// </summary>
		public bool IsMIDIEvent
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsMIDIEvent(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// ノートオフイベントであるかどうか調べる。ノートオンイベントでもベロシティが0のものはノートオフイベントであるとみなす。
		/// </summary>
		public bool IsNoteOff
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsNoteOff(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// ノートオンイベントであるかどうか調べる。ノートオンイベントでもベロシティが0のものはノートオフイベントであるとみなす。
		/// </summary>
		public bool IsNoteOn
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsNoteOn(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// キーアフタータッチイベントであるかどうか調べる。
		/// </summary>
		public bool IsKeyAftertouch
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsKeyAftertouch(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// プログラムチェンジイベントであるかどうか調べる。
		/// </summary>
		public bool IsProgramChange
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsProgramChange(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// コントロールチェンジイベントであるかどうか調べる。
		/// </summary>
		public bool IsControlChange
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsControlChange(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// チャンネルアフタータッチイベントであるかどうか調べる。
		/// </summary>
		public bool IsChannelAftertouch
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsChannelAftertouch(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// ピッチベンドイベントであるかどうか調べる。
		/// </summary>
		public bool IsPitchBend
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsPitchBend(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// システムエクスクルーシブイベントであるかどうか調べる。
		/// </summary>
		public bool IsSysExEvent
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsSysExEvent(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// MIDIイベントが浮遊しているかどうか調べる。
		/// </summary>
		public bool IsFloating
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsFloating(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// MIDIイベントが他のMIDIイベントに結合しているかどうか調べる。
		/// </summary>
		public bool IsCombined
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsCombined(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 結合されたノートオン+ノートオフイベントであるかどうか調べる。
		/// </summary>
		public bool IsNoteOnNoteOff
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsNoteOnNoteOff(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 結合されたノートオン+ノートオン0イベントであるかどうか調べる。
		/// </summary>
		public bool IsNoteOnNoteOn0
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsNoteOnNoteOn0(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 結合されたノートオン+ノートオフ又は結合されたノートオン+ノートオン0であるかどうか調べる。
		/// </summary>
		public bool IsNote
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsNote(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 結合されたパッチチェンジイベントであるかどうか調べる。
		/// </summary>
		public bool IsPatchChange
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsPatchChange(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 結合されたRPNチェンジイベントであるかどうか調べる。
		/// </summary>
		public bool IsRPNChange
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsRPNChange(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 結合されたNRPNチェンジイベントであるかどうか調べる。
		/// </summary>
		public bool IsNRPNChange
		{
			get
			{
				return Convert.ToBoolean(MIDIEvent_IsNRPNChange(this.UnManagedObjectPointer));
			}
		}

		/// <summary>
		/// 時刻
		/// </summary>
		public int Time
		{
			get
			{
				return MIDIEvent_GetTime(this.UnManagedObjectPointer);
			}
			set
			{
				int err = MIDIEvent_SetTime(this.UnManagedObjectPointer, value);
				if (err == 0)
				{
					throw new MIDIDataLibException("時刻の設定に失敗しました。");
				}
			}
		}

		/// <summary>
		/// 時刻(単独のイベントに対して設定する)
		/// </summary>
		public int TimeSingle
		{
			set
			{
				int err = MIDIEvent_SetTimeSingle(this.UnManagedObjectPointer, value);
				if (err == 0)
				{
					throw new MIDIDataLibException("時刻の設定に失敗しました。");
				}
			}
		}

		/// <summary>
		/// MIDIイベントの種類
		/// </summary>
		/// <remarks>読み込んだMIDIデータによっては、Kinds列挙型で定義されていない識別番号を返す場合もあるが、あなたのプログラムはこのイベントを無視するか、適切な処置をしなければならない。</remarks>
		public int Kind
		{
			get
			{
				return MIDIEvent_GetKind(this.UnManagedObjectPointer);
			}
			set
			{
				MIDIEvent_SetKind(this.UnManagedObjectPointer, value);
			}
		}

		/// <summary>
		/// データ部の長さ
		/// </summary>
		public int Len
		{
			get
			{
				return MIDIEvent_GetLen(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// イベントのデータ部
		/// </summary>
		public byte[] Data
		{
			get
			{
				//バッファサイズ
				int dataSize = 256;
				IntPtr dataPtr = IntPtr.Zero;
				try
				{
					//メモリ確保が必ず実行され、dataPtr変数へ必ず代入されるための呪文
					System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
					try { }
					finally
					{
						//メモリ確保
						dataPtr = Marshal.AllocCoTaskMem(dataSize);
					}

					//C言語関数呼び出し
					int dataNum = MIDIEvent_GetData(this.UnManagedObjectPointer, dataPtr, dataSize);
					//コピー先配列
					byte[] midiData = new byte[dataNum];
					//MIDIメッセージ取得できたら
					if (dataNum > 0)
					{
						//配列にコピー
						Marshal.Copy(dataPtr, midiData, 0, dataNum);
					}
					return midiData;
				}
				finally
				{
					if (dataPtr != IntPtr.Zero)
					{
						Marshal.FreeCoTaskMem(dataPtr);
					}
				}

			}
			set
			{
				MIDIEvent_SetData(this.UnManagedObjectPointer, value, value.Length);
			}
		}

		/// <summary>
		/// イベントの文字コード
		/// </summary>
		public CharCodes CharCode
		{
			get
			{
				if (IsTextEvent || IsCopyrightNotice || IsTrackName || IsInstrumentName || IsLyric || IsMarker || IsCuePoint || IsDeviceName || IsProgramName)
				{
					int retVal = MIDIEvent_GetCharCode(this.UnManagedObjectPointer);
					return (CharCodes)Enum.ToObject(typeof(CharCodes), retVal);
				}
				return CharCodes.NoCharCod;
			}
			set
			{
				if (IsTextEvent || IsCopyrightNotice || IsTrackName || IsInstrumentName || IsLyric || IsMarker || IsCuePoint || IsDeviceName || IsProgramName)
				{
					int err = MIDIEvent_SetCharCode(this.UnManagedObjectPointer, (int)value);
					if (err == 0)
					{
						throw new MIDIDataLibException("文字コードの設定に失敗しました。");
					}
				}
			}
		}

		/// <summary>
		/// イベントの文字列
		/// </summary>
		public string Text
		{
			get
			{
				if (IsTextEvent || IsCopyrightNotice || IsTrackName || IsInstrumentName || IsLyric || IsMarker || IsCuePoint || IsDeviceName || IsProgramName)
				{
					StringBuilder stringBuilder = new StringBuilder(MIDIDataLib.BufferSize);
					MIDIEvent_GetText(this.UnManagedObjectPointer, stringBuilder, stringBuilder.Capacity);
					return stringBuilder.ToString();
				}
				else
				{
					throw new MIDIDataLibException("文字列を格納しているイベントではありません。文字列の取得ができません。");
				}
			}
			set
			{
				if (IsTextEvent || IsCopyrightNotice || IsTrackName || IsInstrumentName || IsLyric || IsMarker || IsCuePoint || IsDeviceName || IsProgramName)
				{
					int err = MIDIEvent_SetText(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("文字列の設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("文字列を格納しているイベントではありません。文字列の設定ができません。");
				}
			}
		}

	/// <summary>
	/// テンポイベントのテンポ値を返す。
	/// </summary>
	public int Tempo
		{
			get
			{
				if (IsTempo)
				{
					return MIDIEvent_GetTempo(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("テンポイベントではありません。テンポの取得ができません。");
				}
			}
			set
			{
				if (IsTempo)
				{
					int err = MIDIEvent_SetTempo(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("テンポの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("テンポイベントではありません。テンポの設定ができません。");
				}
			}
		}

		/// <summary>
		/// SMPTEオフセット
		/// </summary>
		public SMPTEOffset SMPTEOffset
		{
			get
			{
				if (IsSMPTEOffset)
				{
					int sMPTEmode, hour, min, sec, frame, subFrame;
					int err = MIDIEvent_GetSMPTEOffset(this.UnManagedObjectPointer, out sMPTEmode, out hour, out min, out sec, out frame, out subFrame);
					if (err == 0)
					{
						throw new MIDIDataLibException("SMPTEオフセットの取得ができませんでした。");
					}
					return new SMPTEOffset((SMPTE)Enum.ToObject(typeof(SMPTE), sMPTEmode), hour, min, sec, frame, subFrame);
				}
				else
				{
					throw new MIDIDataLibException("SMPTEオフセットイベントではありません。SMPTEオフセットの取得ができません。");
				}
			}
			set
			{
				if (IsSMPTEOffset)
				{
					int err = MIDIEvent_SetSMPTEOffset(this.UnManagedObjectPointer, (int)value.Mode, value.Hour, value.Min, value.Sec, value.Frame, value.SubFrame);
					if (err == 0)
					{
						throw new MIDIDataLibException("SMPTEオフセットの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("SMPTEオフセットイベントではありません。SMPTEオフセットの設定ができません。");
				}
			}
		}

		/// <summary>
		/// 拍子記号
		/// </summary>
		public TimeSignature TimeSignature
		{
			get
			{
				if (IsTimeSignature)
				{
					int nn, dd, cc, bb;
					int err = MIDIEvent_GetTimeSignature(this.UnManagedObjectPointer, out nn, out dd, out cc, out bb);
					if (err == 0)
					{
						throw new MIDIDataLibException("拍子記号の取得ができませんでした。");
					}
					return new TimeSignature(nn, dd, cc, bb);
				}
				else
				{
					throw new MIDIDataLibException("拍子記号イベントイベントではありません。拍子記号の取得ができません。");
				}
			}
			set
			{
				if (IsTimeSignature)
				{
					int err = MIDIEvent_SetTimeSignature(this.UnManagedObjectPointer, value.nn, value.dd, value.cc, value.bb);
					if (err == 0)
					{
						throw new MIDIDataLibException("拍子記号の設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("拍子記号イベントイベントではありません。拍子記号の設定ができません。");
				}
			}
		}

		/// <summary>
		/// 調性記号
		/// </summary>
		public KeySignature KeySignature
		{
			get
			{
				if (IsKeySignature)
				{
					int sf, mi;
					int err = MIDIEvent_GetKeySignature(this.UnManagedObjectPointer, out sf, out mi);
					if (err == 0)
					{
						throw new MIDIDataLibException("調性記号の取得ができませんでした。");
					}
					return new KeySignature(sf, (Keys)Enum.ToObject(typeof(Keys), mi));
				}
				else
				{
					throw new MIDIDataLibException("調性記号イベントではありません。調性記号の取得ができません。");
				}
			}
			set
			{
				if (IsKeySignature)
				{
					int err = MIDIEvent_SetKeySignature(this.UnManagedObjectPointer, value.sf, (int)value.mi);
					if (err == 0)
					{
						throw new MIDIDataLibException("調性記号の設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("調性記号イベントではありません。調性記号の設定ができません。");
				}
			}
		}

		/// <summary>
		/// MIDIメッセージ
		/// </summary>
		public sbyte[] MIDIMessage
		{
			get
			{
				if (IsMIDIEvent || IsSysExEvent)
				{
					//バッファサイズ
					int dataSize = 256;
					IntPtr dataPtr = IntPtr.Zero;
					try
					{
						//メモリ確保が必ず実行され、dataPtr変数へ必ず代入されるための呪文
						System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
						try { }
						finally
						{
							//メモリ確保
							dataPtr = Marshal.AllocCoTaskMem(dataSize);
						}

						//C言語関数呼び出し
						int dataNum = MIDIEvent_GetMIDIMessage(this.UnManagedObjectPointer, dataPtr, dataSize);
						//コピー先配列
						byte[] midiData = new byte[dataNum];
						//MIDIメッセージ取得できたら
						if (dataNum > 0)
						{
							//配列にコピー
							Marshal.Copy(dataPtr, midiData, 0, dataNum);
						}
						return midiData.Cast<sbyte>().ToArray();
					}
					finally
					{
						if (dataPtr != IntPtr.Zero)
						{
							Marshal.FreeCoTaskMem(dataPtr);
						}
					}
				}
				else
				{
					throw new MIDIDataLibException("MIDIメッセージイベントではありません。MIDIメッセージの取得ができません。");
				}
			}
			set
			{
				if (IsMIDIEvent || IsSysExEvent)
				{
					MIDIEvent_SetMIDIMessage(this.UnManagedObjectPointer, value, value.Length);
				}
				else
				{
					throw new MIDIDataLibException("MIDIメッセージイベントではありません。MIDIメッセージの設定ができません。");
				}
			}
		}

		/// <summary>
		/// チャンネル
		/// </summary>
		public int Channel
		{
			get
			{
				if (IsMIDIEvent)
				{
					return MIDIEvent_GetChannel(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("MIDIチャンネルイベントではありません。チャンネルの取得ができません。");
				}
			}
			set
			{
				if (IsMIDIEvent)
				{
					if (value < 0 || 15 < value)
					{
						throw new ArgumentOutOfRangeException(null, MIDIDataLib.MessageChannelOutOfRange);
					}
					int err = MIDIEvent_SetChannel(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("チャンネルの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("MIDIチャンネルイベントではありません。チャンネルの設定ができません。");
				}
			}
		}

		/// <summary>
		/// キー
		/// </summary>
		public int Key
		{
			get
			{
				if (IsNoteOff || IsNoteOn || IsKeyAftertouch)
				{
					return MIDIEvent_GetKey(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("ノート・キーアフタータッチイベントではありません。キーの取得ができません。");
				}
			}
			set
			{
				if (IsNoteOff || IsNoteOn || IsKeyAftertouch)
				{
					if (value < 0 || 127 < value)
					{
						throw new ArgumentOutOfRangeException(null, MIDIDataLib.MessageKeyOutOfRange);
					}
					int err = MIDIEvent_SetKey(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("キーの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("ノート・キーアフタータッチイベントではありません。キーの設定ができません。");
				}
			}
		}

		/// <summary>
		/// ベロシティ
		/// </summary>
		public int Velocity
		{
			get
			{
				if (IsNoteOff || IsNoteOn)
				{
					return MIDIEvent_GetVelocity(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("ノートイベントではありません。ベロシティの取得ができません。");
				}
			}
			set
			{
				if (IsNoteOff || IsNoteOn)
				{
					if (value < 0 || 127 < value)
					{
						throw new ArgumentOutOfRangeException(null, "ベロシティは0～127の範囲内である必要があります。");
					}
					int err = MIDIEvent_SetVelocity(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("ベロシティの設定に失敗しました。");
					}
				}
			}
		}

		/// <summary>
		/// 音長さ
		/// </summary>
		public int Duration
		{
			get
			{
				if (IsNote)
				{
					return MIDIEvent_GetDuration(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("ノートイベントではありません。音長さの取得ができません。");
				}
			}
			set
			{
				if (IsNote)
				{
					if (IsNoteOn)
					{
						if (value < 0)
						{
							throw new ArgumentOutOfRangeException(null, "ノートオンイベントに対しては、音長さは正の値である必要があります。");
						}
					}
					if (IsNoteOff)
					{
						if (value > 0)
						{
							throw new ArgumentOutOfRangeException(null, "ノートオフイベントに対しては、音長さは負の値である必要があります。");
						}
					}
					int err = MIDIEvent_SetDuration(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("音長さの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("ノートイベントではありません。音長さの設定ができません。");
				}
			}
		}

		/// <summary>
		/// ナンバー
		/// </summary>
		public int Number
		{
			get
			{
				if (IsSequenceNumber || IsChannelPrefix || IsPortPrefix || IsControlChange || IsProgramChange)
				{
					return MIDIEvent_GetNumber(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("ナンバーが定義されたイベントではありません。ナンバーの取得ができません。");
				}
			}
			set
			{
				if (IsSequenceNumber || IsChannelPrefix || IsPortPrefix || IsControlChange || IsProgramChange)
				{
					int err = MIDIEvent_SetNumber(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("ナンバーの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("ナンバーが定義されたイベントではありません。ナンバーの設定ができません。");
				}
			}
		}

		/// <summary>
		/// 値
		/// </summary>
		public int Value
		{
			get
			{
				if (IsSequenceNumber || IsChannelPrefix || IsPortPrefix || IsKeyAftertouch || IsControlChange || IsProgramChange || IsChannelAftertouch || IsPitchBend)
				{
					return MIDIEvent_GetValue(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("値が定義されたイベントではありません。値の取得ができません。");
				}
			}
			set
			{
				if (IsSequenceNumber || IsChannelPrefix || IsPortPrefix || IsKeyAftertouch || IsControlChange || IsProgramChange || IsChannelAftertouch || IsPitchBend)
				{
					int err = MIDIEvent_SetValue(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("値の設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("値が定義されたイベントではありません。値の設定ができません。");
				}
			}
		}

		/// <summary>
		/// バンク
		/// </summary>
		public int Bank
		{
			get
			{
				if (IsPatchChange || IsRPNChange || IsNRPNChange)
				{
					return MIDIEvent_GetBank(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("バンクが定義されたイベントではありません。バンクの取得ができません。");
				}
			}
			set
			{
				if (IsPatchChange || IsRPNChange || IsNRPNChange)
				{
					if (value < 0 || 16383 < value)
					{
						throw new ArgumentOutOfRangeException(null, "バンクは0～16383の範囲内である必要があります。");
					}
					int err = MIDIEvent_SetBank(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("バンクの設定に失敗しました。");
					}
				}
			}
		}

		/// <summary>
		/// バンク上位
		/// </summary>
		public int BankMSB
		{
			get
			{
				if (IsPatchChange || IsRPNChange || IsNRPNChange)
				{
					return MIDIEvent_GetBankMSB(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("バンクが定義されたイベントではありません。バンクMSBの取得ができません。");
				}
			}
			set
			{
				if (IsPatchChange || IsRPNChange || IsNRPNChange)
				{
					if (value < 0 || 127 < value)
					{
						throw new ArgumentOutOfRangeException(null, "バンクMSBは0～127の範囲内である必要があります。");
					}
					int err = MIDIEvent_SetBankMSB(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("バンクMSBの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("バンクが定義されたイベントではありません。バンクMSBの設定ができません。");
				}
			}
		}

		/// <summary>
		/// バンク下位
		/// </summary>
		public int BankLSB
		{
			get
			{
				if (IsPatchChange || IsRPNChange || IsNRPNChange)
				{
					return MIDIEvent_GetBankLSB(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("バンクが定義されたイベントではありません。バンクLSBの取得ができません。");
				}
			}
			set
			{
				if (IsPatchChange || IsRPNChange || IsNRPNChange)
				{
					if (value < 0 || 127 < value)
					{
						throw new ArgumentOutOfRangeException(null, "バンクLSBは0～127の範囲内である必要があります。");
					}
					int err = MIDIEvent_SetBankLSB(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("バンクLSBの設定に失敗しました。");
					}
				}
				else
				{
					throw new MIDIDataLibException("バンクが定義されたイベントではありません。バンクLSBの設定ができません。");
				}
			}
		}

		/// <summary>
		/// データエントリーMSB
		/// </summary>
		public int DataEntryMSB
		{
			get
			{
				if (IsRPNChange || IsNRPNChange)
				{
					return MIDIEvent_GetDataEntryMSB(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("RPNチェンジイベント・NRPNチェンジイベントではありません。データエントリーMSBの取得ができません。");
				}
			}
			set
			{
				if (IsRPNChange || IsNRPNChange)
				{
					if (value < 0 || 127 < value)
					{
						throw new ArgumentOutOfRangeException(null, "データエントリーMSBは0～127の範囲内である必要があります。");
					}
					int err = MIDIEvent_SetDataEntryMSB(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("データエントリーMSBの設定に失敗しました。");
					}
				}
			}
		}

		/// <summary>
		/// プログラムナンバー
		/// </summary>
		public int PatchNum
		{
			get
			{
				if (IsPatchChange)
				{
					return MIDIEvent_GetPatchNum(this.UnManagedObjectPointer);
				}
				else
				{
					throw new MIDIDataLibException("パッチチェンジチェンジイベントではありません。プログラムナンバーの取得ができません。");
				}
			}
			set
			{
				if (IsPatchChange)
				{
					if (value < 0 || 127 < value)
					{
						throw new ArgumentOutOfRangeException(null, "ログラムナンバーは0～127の範囲内である必要があります。");
					}
					int err = MIDIEvent_SetPatchNum(this.UnManagedObjectPointer, value);
					if (err == 0)
					{
						throw new MIDIDataLibException("ログラムナンバーの設定に失敗しました。");
					}
				}
			}
		}

		/// <summary>
		/// 次のMIDIイベント
		/// </summary>
		public MIDIEvent NextEvent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetNextEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDIEvent(intPtr);
				}
			}
		}

		/// <summary>
		/// ラッパー独自プロパティ。
		/// MIDI再生用。
		/// このプロパティは、自分自身に持っているアンマネージド・オブジェクトのポインタを次のイベントのポインタに変更し、自分自身を返す。
		/// イベントの列挙には使えない。NextEventプロパティより高速(であってほしい)
		/// </summary>
		public MIDIEvent NextEventForPlay
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetNextEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					this.UnManagedObjectPointer = intPtr;
					return this;
				}
			}
		}

		/// <summary>
		/// 前のMIDIイベント
		/// </summary>
		public MIDIEvent PrevEvent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetPrevEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDIEvent(intPtr);
				}
			}
		}

		/// <summary>
		/// 次の同種のMIDIイベント
		/// </summary>
		public MIDIEvent NextSameKindEvent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetNextSameKindEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDIEvent(intPtr);
				}
			}
		}

		/// <summary>
		/// 前の同種のMIDIイベント
		/// </summary>
		public MIDIEvent PrevSameKindEvent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetPrevSameKindEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDIEvent(intPtr);
				}
			}
		}

		/// <summary>
		/// 結合イベントの場合、結合している最初のイベント
		/// </summary>
		public MIDIEvent FirstCombinedEvent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetFirstCombinedEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDIEvent(intPtr);
				}
			}
		}

		/// <summary>
		/// 結合イベントの場合、結合している最後のイベント
		/// </summary>
		public MIDIEvent LastCombinedEvent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetLastCombinedEvent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDIEvent(intPtr);
				}
			}
		}

		/// <summary>
		/// このMIDIイベントが含まれるMIDIトラック
		/// </summary>
		public MIDITrack Parent
		{
			get
			{
				IntPtr intPtr = MIDIEvent_GetParent(this.UnManagedObjectPointer);
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDITrack(intPtr);
				}
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

		/// <summary>
		/// 著作権イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>著作権イベント</returns>
		public static MIDIEvent CreateCopyrightNotice(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateCopyrightNotice(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("著作権イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定して著作権イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>著作権イベント</returns>
		public static MIDIEvent CreateCopyrightNoticeEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateCopyrightNoticeEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("著作権イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// シーケンス名・トラック名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>シーケンス名・トラック名イベント</returns>
		public static MIDIEvent CreateTrackName(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateTrackName(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("シーケンス名・トラック名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してシーケンス名・トラック名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>シーケンス名・トラック名イベント</returns>
		public static MIDIEvent CreateTrackNameEx(int time,CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateTrackNameEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("シーケンス名・トラック名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// インストゥルメント名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>インストゥルメント名イベント</returns>
		public static MIDIEvent CreateInstrumentName(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateInstrumentName(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("インストゥルメント名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してインストゥルメント名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>インストゥルメント名イベント</returns>
		public static MIDIEvent CreateInstrumentNameEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateInstrumentNameEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("インストゥルメント名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 歌詞イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>歌詞イベント</returns>
		public static MIDIEvent CreateLyric(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateLyric(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("歌詞イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定して歌詞イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>歌詞イベント</returns>
		public static MIDIEvent CreateLyricEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateLyricEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("歌詞イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// マーカーイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>マーカーイベント</returns>
		public static MIDIEvent CreateMarker(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateMarker(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("マーカーイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してマーカーイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>マーカーイベント</returns>
		public static MIDIEvent CreateMarkerEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateMarkerEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("マーカーイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// キューポイントイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>キューポイントイベント</returns>
		public static MIDIEvent CreateCuePoint(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateCuePoint(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("キューポイントイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してキューポイントイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>キューポイントイベント</returns>
		public static MIDIEvent CreateCuePointEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateCuePointEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("キューポイントイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// プログラム名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>プログラム名イベント</returns>
		public static MIDIEvent CreateProgramName(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateProgramName(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("プログラム名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してプログラム名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>プログラム名イベント</returns>
		public static MIDIEvent CreateProgramNameEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateProgramNameEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("プログラム名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// デバイス名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		/// <returns>デバイス名イベント</returns>
		public static MIDIEvent CreateDeviceName(int time, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateDeviceName(time, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("デバイス名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 文字コードを指定してデバイス名イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		/// <returns>デバイス名イベント</returns>
		public static MIDIEvent CreateDeviceNameEx(int time, CharCodes charCode, string text)
		{
			IntPtr intPtr = MIDIEvent_CreateDeviceNameEx(time, (int)charCode, text);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("デバイス名イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// チャンネルプリフィックスイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="num">チャンネル番号(0～15)</param>
		/// <returns>チャンネルプリフィックスイベント</returns>
		public static MIDIEvent CreateChannelPrefix(int time, int num)
		{
			if (num < 0 || 15 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateChannelPrefix(time, num);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("チャンネルプリフィックスイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// ポートプリフィックスイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="num">ポート番号(0～255)</param>
		/// <returns>ポートプリフィックスイベント</returns>
		public static MIDIEvent CreatePortPrefix(int time, int num)
		{
			if (num < 0 || 255 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "ポート番号は0から255の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreatePortPrefix(time, num);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ポートプリフィックスイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// エンドオブトラックイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <returns>エンドオブトラックイベント</returns>
		public static MIDIEvent CreateEndofTrack(int time)
		{
			IntPtr intPtr = MIDIEvent_CreateEndofTrack(time);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("エンドオブトラックイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// テンポイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="tempo">テンポ</param>
		/// <returns>テンポイベント</returns>
		public static MIDIEvent CreateTempo(int time, int tempo)
		{
			IntPtr intPtr = MIDIEvent_CreateTempo(time, tempo);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("テンポイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// SMPTEオフセットイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="offset">MPTEオフセット</param>
		/// <returns>SMPTEオフセットイベント</returns>
		public static MIDIEvent CreateSMPTEOffset(int time, SMPTEOffset offset)
		{
			IntPtr intPtr = MIDIEvent_CreateSMPTEOffset(time, (int)offset.Mode, offset.Hour, offset.Min, offset.Sec, offset.Frame, offset.SubFrame);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("SMPTEオフセットイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 拍子記号イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="timeSignature">拍子記号</param>
		/// <returns>拍子記号イベント</returns>
		public static MIDIEvent CreateTimeSignature(int time, TimeSignature timeSignature)
		{
			IntPtr intPtr = MIDIEvent_CreateTimeSignature(time, timeSignature.nn, timeSignature.dd, timeSignature.cc, timeSignature.bb);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("拍子記号イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// 調性記号イベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="keySignature">調性記号</param>
		/// <returns>調性記号イベント</returns>
		public static MIDIEvent CreateKeySignature(int time, KeySignature keySignature)
		{
			IntPtr intPtr = MIDIEvent_CreateKeySignature(time, keySignature.sf, (int)keySignature.mi);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("調性記号イベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// シーケンサー独自のイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="buf">データ部</param>
		/// <returns>シーケンサー独自のイベント</returns>
		public static MIDIEvent CreateSequencerSpecific(int time, sbyte[] buf)
		{
			IntPtr intPtr = MIDIEvent_CreateSequencerSpecific(time, buf, buf.Length);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("シーケンサー独自のイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}
		/// <summary>
		/// ノートオフイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号(0～15)</param>
		/// <param name="key">キー値(0～127)</param>
		/// <param name="vel">ベロシティ(離鍵速度)(0～127)</param>
		/// <returns>ノートオフイベント</returns>
		public static MIDIEvent CreateNoteOff(int time, int ch, int key, int vel)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (key < 0 || 127 < key)
			{
				throw new ArgumentOutOfRangeException(nameof(key), "キー値は0から127の範囲内である必要があります。");
			}
			if (vel < 0 || 127 < vel)
			{
				throw new ArgumentOutOfRangeException(nameof(vel), "ベロシティは0から127の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateNoteOff(time, ch, key, vel);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ノートオフイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// ノートオンイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号(0～15)</param>
		/// <param name="key">キー値(0～127)</param>
		/// <param name="vel">ベロシティ(離鍵速度)(0～127)</param>
		/// <returns>ノートオンイベント</returns>
		public static MIDIEvent CreateNoteOn(int time, int ch, int key, int vel)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (key < 0 || 127 < key)
			{
				throw new ArgumentOutOfRangeException(nameof(key), "キー値は0から127の範囲内である必要があります。");
			}
			if (vel < 0 || 127 < vel)
			{
				throw new ArgumentOutOfRangeException(nameof(vel), "ベロシティは0から127の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateNoteOn(time, ch, key, vel);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ノートオンイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// キーアフタータッチイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号</param>
		/// <param name="key">キー値(0～127)</param>
		/// <param name="val">値(0～127)</param>
		/// <returns>キーアフタータッチイベント</returns>
		public static MIDIEvent CreateKeyAftertouch(int time, int ch, int key, int val)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (key < 0 || 127 < key)
			{
				throw new ArgumentOutOfRangeException(nameof(key), "キー値は0から127の範囲内である必要があります。");
			}
			if (val < 0 || 127 < val)
			{
				throw new ArgumentOutOfRangeException(nameof(val), "値は0から127の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateKeyAftertouch(time, ch, key, val);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("キーアフタータッチイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// コントロールチェンジイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号</param>
		/// <param name="key">コントロールナンバー(0～127)</param>
		/// <param name="val">値(0～127)</param>
		/// <returns>コントロールチェンジイベント</returns>
		public static MIDIEvent CreateControlChange(int time, int ch, int num, int val)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (num < 0 || 127 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "コントロールナンバーは0から127の範囲内である必要があります。");
			}
			if (val < 0 || 127 < val)
			{
				throw new ArgumentOutOfRangeException(nameof(val), "値は0から127の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateControlChange(time, ch, num, val);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("コントロールチェンジイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// プログラムチェンジイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号</param>
		/// <param name="key">プログラムナンバー(0～127)</param>
		/// <returns>プログラムチェンジイベント</returns>
		public static MIDIEvent CreateProgramChange(int time, int ch, int num)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (num < 0 || 127 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "プログラムナンバーは0から127の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateProgramChange(time, ch, num);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("プログラムチェンジイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// チャンネルアフタータッチイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号</param>
		/// <param name="val">値(0～127)</param>
		/// <returns>チャンネルアフタータッチイベント</returns>
		public static MIDIEvent CreateChannelAftertouch(int time, int ch, int val)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (val < 0 || 127 < val)
			{
				throw new ArgumentOutOfRangeException(nameof(val), "値は0から127の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreateChannelAftertouch(time, ch, val);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("チャンネルアフタータッチイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// ピッチベンドイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号</param>
		/// <param name="val">値(0～16383)</param>
		/// <returns>ピッチベンドイベント</returns>
		public static MIDIEvent CreatePitchBend(int time, int ch, int val)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (val < 0 || 127 < val)
			{
				throw new ArgumentOutOfRangeException(nameof(val), "ピッチベンドは0から16383の範囲内である必要があります。");
			}
			IntPtr intPtr = MIDIEvent_CreatePitchBend(time, ch, val);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ピッチベンドイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// システムエクスクルーシブイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="buf">データ部</param>
		/// <returns>システムエクスクルーシブイベント</returns>
		public static MIDIEvent CreateSysExEvent(int time, byte[] buf)
		{
			IntPtr intPtr = MIDIEvent_CreateSysExEvent(time, buf, buf.Length);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("システムエクスクルーシブイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// ベロシティ(打鍵速度)が1以上のノートオン、及びベロシティ(離鍵速度)が0以上のノートオフの2つのイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号(0～15)</param>
		/// <param name="key">キー番号(0～127)</param>
		/// <param name="vel1">ノートオンイベントのベロシティ(打鍵速度)(1～127)</param>
		/// <param name="vel2">ノートオフイベントのベロシティ(離鍵速度)(0～127)</param>
		/// <param name="dur">長さ(1～)</param>
		/// <returns>ノートイベント</returns>
		public static MIDIEvent CreateNoteOnNoteOff(int time, int ch, int key, int vel1, int vel2, int dur)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (key < 0 || 127 < key)
			{
				throw new ArgumentOutOfRangeException(nameof(key), "キー値は0から127の範囲内である必要があります。");
			}
			if (vel1 < 1 || 127 < vel1)
			{
				throw new ArgumentOutOfRangeException(nameof(vel1), "ノートオンイベントのベロシティは1から127の範囲内である必要があります。");
			}
			if (vel2 < 0 || 127 < vel2)
			{
				throw new ArgumentOutOfRangeException(nameof(vel2), "ノートオフイベントのベロシティは0から127の範囲内である必要があります。");
			}
			if (dur < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(dur), "長さに0以下の値は指定できません。");
			}
			IntPtr intPtr = MIDIEvent_CreateNoteOnNoteOff(time, ch, key, vel1, vel2, dur);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ノートイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// ベロシティ(打鍵速度)が1以上のノートオン、及びベロシティ(打鍵速度)が0のノートオンの2つのイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号(0～15)</param>
		/// <param name="key">キー番号(0～127)</param>
		/// <param name="vel">ノートオンイベントのベロシティ(打鍵速度)(1～127)</param>
		/// <param name="dur">長さ(1～)</param>
		/// <returns>ノートイベント</returns>
		public static MIDIEvent CreateNoteOnNoteOn0(int time, int ch, int key, int vel, int dur)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (key < 0 || 127 < key)
			{
				throw new ArgumentOutOfRangeException(nameof(key), "キー値は0から127の範囲内である必要があります。");
			}
			if (vel < 1 || 127 < vel)
			{
				throw new ArgumentOutOfRangeException(nameof(vel), "ノートオンイベントのベロシティは1から127の範囲内である必要があります。");
			}
			if (dur < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(dur), "長さに0以下の値は指定できません。");
			}
			IntPtr intPtr = MIDIEvent_CreateNoteOnNoteOn0(time, ch, key, vel, dur);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ノートイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		/// <summary>
		/// ノートイベントを生成する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="ch">チャンネル番号(0～15)</param>
		/// <param name="key">キー番号(0～127)</param>
		/// <param name="vel">ノートオンイベントのベロシティ(打鍵速度)(1～127)</param>
		/// <param name="dur">長さ(1～)</param>
		/// <returns>ノートイベント</returns>
		public static MIDIEvent CreateNote(int time, int ch, int key, int vel, int dur)
		{
			if (ch < 0 || 15 < ch)
			{
				throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0から15の範囲内である必要があります。");
			}
			if (key < 0 || 127 < key)
			{
				throw new ArgumentOutOfRangeException(nameof(key), "キー値は0から127の範囲内である必要があります。");
			}
			if (vel < 1 || 127 < vel)
			{
				throw new ArgumentOutOfRangeException(nameof(vel), "ノートオンイベントのベロシティは1から127の範囲内である必要があります。");
			}
			if (dur < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(dur), "長さに0以下の値は指定できません。");
			}
			IntPtr intPtr = MIDIEvent_CreateNote(time, ch, key, vel, dur);
			if (intPtr == IntPtr.Zero)
			{
				throw new MIDIDataLibException("ノートイベントの生成に失敗しました。");
			}
			return new MIDIEvent(intPtr);
		}

		#endregion

		#region メソッド

		/// <summary>
		/// 指定したMIDIイベントを削除する。
		/// 指定MIDIイベントが他のMIDIイベントと結合している場合、結合しているMIDIイベントも同時に削除する。
		/// すなわち、2つ以上のMIDIイベントが削除されることがある。
		/// </summary>
		/// <returns>削除したMIDIイベントの数(1以上)</returns>
		public int Delete()
		{
			int retVal = MIDIEvent_Delete(this.UnManagedObjectPointer);
			if (retVal == 0)
			{
				throw new MIDIDataLibException("MIDIEventオブジェクトの削除に失敗しました。");
			}
			this.UnManagedObjectPointer = IntPtr.Zero;
			return retVal;
		}

		/// <summary>
		/// 指定したMIDIイベントを削除する。
		/// 指定MIDIイベントが他のMIDIイベントと結合している場合、結合を切り離し、指定したイベントのみを削除する。
		/// すなわち、2つ以上のMIDIイベントが削除されることはない。
		/// </summary>
		public void DeleteSingle()
		{
			int retVal = MIDIEvent_DeleteSingle(this.UnManagedObjectPointer);
			if (retVal == 0)
			{
				throw new MIDIDataLibException("MIDIEventオブジェクトの削除に失敗しました。");
			}
			this.UnManagedObjectPointer = IntPtr.Zero;
		}

		/// <summary>
		/// 結合されていないMIDIイベントで、結合できるものがある場合は結合する。
		/// </summary>
		public void Combine()
		{
			MIDIEvent_Combine(this.UnManagedObjectPointer);
		}

		/// <summary>
		/// 結合されているMIDIイベントを、バラバラに切り離す。
		/// </summary>
		public void Chop()
		{
			MIDIEvent_Chop(this.UnManagedObjectPointer);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(MIDIDataLib.BufferSize);
			MIDIEvent_ToString(this.UnManagedObjectPointer, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		#endregion

		#region ファイナライザー
		~MIDIEvent()
		{
			//浮遊イベントのときのみメモリ上から削除
			if (IsFloating)
			{
				DeleteSingle();
			}
		}
		#endregion

	}
}
