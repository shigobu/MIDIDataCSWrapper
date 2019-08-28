﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	/// <summary>
	/// MIDIトラックは、単数又は複数のMIDIイベントを子に持つ。
	/// </summary>
	public class MIDITrack
	{
		#region DllImport

		/// <summary>
		/// MIDIトラックを新規に生成する。
		/// </summary>
		/// <returns>MIDIトラックへのポインタ</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDITrack_Create();

		/// <summary>
		/// 既存のMIDIトラックを複製して新しいMIDIトラックを生成する。
		/// </summary>
		/// <param name="pMIDITrack">複製元トラックへのポインタ</param>
		/// <returns>複製したMIDIトラックへのポインタ</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDITrack_CreateClone(IntPtr pMIDITrack);

		/// <summary>
		/// MIDIトラックをメモリ上から削除する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern void MIDITrack_Delete(IntPtr pMIDITrack);

		/// <summary>
		/// MIDIトラックに任意のイベントを挿入する。挿入位置は、イベントの時刻により自動決定される。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="pMIDIEvent">挿入するイベントへのポインタ</param>
		/// <returns>
		/// 正常終了:挿入したイベントの数(1以上)
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertEvent(IntPtr pMIDITrack, IntPtr pMIDIEvent);

		/// <summary>
		/// MIDIトラックに任意のイベントを挿入する。挿入位置はターゲットイベントの直前である。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="pMIDIEvent">挿入するイベントへのポインタ</param>
		/// <param name="pTarget">挿入位置指定用ターゲットイベントへのポインタ</param>
		/// 正常終了:挿入したイベントの数(1以上)
		/// 異常終了:0
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertEventBefore(IntPtr pMIDITrack, IntPtr pMIDIEvent, IntPtr pTarget);

		/// <summary>
		/// MIDIトラックに任意のイベントを挿入する。挿入位置はターゲットイベントの直後である。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="pMIDIEvent">挿入するイベントへのポインタ</param>
		/// <param name="pTarget">挿入位置指定用ターゲットイベントへのポインタ</param>
		/// 正常終了:挿入したイベントの数(1以上)
		/// 異常終了:0
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertEventAfter(IntPtr pMIDITrack, IntPtr pMIDIEvent, IntPtr pTarget);

		/// <summary>
		/// シーケンス番号イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lNum">シーケンス番号(0～65535)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertSequenceNumber(IntPtr pMIDITrack, int lTime, int lNum);

		/// <summary>
		/// テキストイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertTextEvent(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してテキストイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertTextEventEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// 著作権イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertCopyrightNotice(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定して著作権イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertCopyrightNoticeEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);
		
		/// <summary>
		/// シーケンス名・トラック名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertTrackName (IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してシーケンス名・トラック名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertTrackNameEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// インストゥルメント名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertInstrumentName(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してインストゥルメント名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertInstrumentNameEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// 歌詞イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時間</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertLyric(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定して歌詞イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertLyricEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// マーカーイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertMarker(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してマーカーイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertMarkerEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// キューポイントイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertCuePoint(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してキューポイントイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertCuePointEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// プログラム名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時間</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertProgramName(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してプログラム名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時間</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertProgramNameEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// デバイス名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時間</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertDeviceName(IntPtr pMIDITrack, int lTime, string pszText);

		/// <summary>
		/// 文字コードを指定してデバイス名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時間</param>
		/// <param name="lCharCode">文字コード</param>
		/// <param name="pszText">文字列</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertDeviceNameEx(IntPtr pMIDITrack, int lTime, int lCharCode, string pszText);

		/// <summary>
		/// チャンネルプリフィックスイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時間</param>
		/// <param name="lNum">チャンネル番号(0～15)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertChannelPrefix(IntPtr pMIDITrack, int lTime, int lNum);

		/// <summary>
		/// ポートプリフィックスイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lNum">ポート番号(0～255)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertPortPrefix(IntPtr pMIDITrack, int lTime, int lNum);

		/// <summary>
		/// エンドオブトラックイベントを生成し、指定トラックに挿入する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertEndofTrack(IntPtr pMIDITrack, int lTime);

		/// <summary>
		/// テンポイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lTempo">テンポ</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertTempo(IntPtr pMIDITrack, int lTime, int lTempo);

		/// <summary>
		/// SMPTEオフセットイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lMode">モード(0～3)</param>
		/// <param name="lHour">時間(0～23)</param>
		/// <param name="lMin">分(0～59)</param>
		/// <param name="lSec">秒(0～59)</param>
		/// <param name="lFrame">フレーム(0～30)</param>
		/// <param name="lSubFrame">サブフレーム(0～99)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertSMPTEOffset(IntPtr pMIDITrack, int lTime, int lMode, int lHour, int lMin, int lSec, int lFrame, int lSubFrame);

		/// <summary>
		/// 拍子記号イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lnn">分子</param>
		/// <param name="ldd">分母</param>
		/// <param name="lcc">1拍あたりのMIDIクロック数</param>
		/// <param name="lbb">1拍当たりの32分音符の数</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertTimeSignature(IntPtr pMIDITrack, int lTime, int lnn, int ldd, int lcc, int lbb);

		/// <summary>
		/// 調性記号イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lsf">#又は♭の数(-7～+7)</param>
		/// <param name="lmi">長調・短調を示す値(0～1)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertKeySignature(IntPtr pMIDITrack, int lTime, int lsf, int lmi);

		/// <summary>
		/// シーケンサー独自のイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pBuf">データ部へのポインタ</param>
		/// <param name="lLen">データ部の長さ[バイト]</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertSequencerSpecific(IntPtr pMIDITrack, int lTime, sbyte[] pBuf, int lLen);

		/// <summary>
		/// ノートオフイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lKey">キー値(0～127)</param>
		/// <param name="lVel">ベロシティ(0～127)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertNoteOff(IntPtr pMIDITrack, int lTime, int lCh, int lKey, int lVel);

		/// <summary>
		/// ノートオンイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lKey">キー値(0～127)</param>
		/// <param name="lVel">ベロシティ(0～127)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertNoteOn(IntPtr pMIDITrack, int lTime, int lCh, int lKey, int lVel);

		/// <summary>
		/// キーアフタータッチイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lKey">キー値(0～127)</param>
		/// <param name="lVal">値(0～127)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertKeyAftertouch(IntPtr pMIDITrack, int lTime, int lCh, int lKey, int lVal);

		/// <summary>
		/// コントロールチェンジイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lNum">コントロールナンバー(0～127)</param>
		/// <param name="lVal">値(0～127)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertControlChange(IntPtr pMIDITrack, int lTime, int lCh, int lNum, int lVal);

		/// <summary>
		/// プログラムチェンジイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lNum">プログラムナンバー(0～127)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertProgramChange(IntPtr pMIDITrack, int lTime, int lCh, int lNum);

		/// <summary>
		/// チャンネルアフタータッチイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lVal">値(0～127)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertChannelAftertouch(IntPtr pMIDITrack, int lTime, int lCh, int lVal);

		/// <summary>
		/// ピッチベンドイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lVal">値(0～16383)</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertPitchBend(IntPtr pMIDITrack, int lTime, int lCh, int lVal);

		/// <summary>
		/// システムエクスクルーシブイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="pBuf">データ部へのポインタ</param>
		/// <param name="lLen">データ部の長さ</param>
		/// <returns>
		/// 正常終了：1
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertSysExEvent(IntPtr pMIDITrack, int lTime, byte[] pBuf, int lLen);

		/// <summary>
		/// ノートオンイベント、ノートオフイベントの2つのイベントを生成し、指定トラックに挿入する。
		/// </summary>
		/// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
		/// <param name="lTime">絶対時刻</param>
		/// <param name="lCh">チャンネル番号(0～15)</param>
		/// <param name="lKey">キー番号(0～127)</param>
		/// <param name="lVel">ノートオンイベントのベロシティ</param>
		/// <param name="lDur">長さ</param>
		/// <returns>
		/// 正常終了：2
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_InsertNote(IntPtr pMIDITrack, int lTime, int lCh, int lKey, int lVel, int lDur);

        /// <summary>
        /// MIDIトラックから指定のMIDIイベントを除外する。
        /// </summary>
        /// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
        /// <param name="pMIDIEvent">トラックから除去するMIDIイベントへのポインタ</param>
        /// <returns>
        /// 正常終了：除外したイベントの数(1以上)
        /// 異常終了：0
        /// </returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_RemoveEvent(IntPtr pMIDITrack, IntPtr pMIDIEvent);

        /// <summary>
        /// MIDIトラックから指定のMIDIイベントを除外する。
        /// </summary>
        /// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
        /// <param name="pMIDIEvent">トラックから除去するMIDIイベントへのポインタ</param>
        /// <returns>
        /// 正常終了：1
        /// 異常終了：0
        /// </returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDITrack_RemoveSingleEvent(IntPtr pMIDITrack, IntPtr pMIDIEvent);

        /// <summary>
        /// MIDIトラックが浮遊トラックであるかどうか調べる。
        /// </summary>
        /// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
        /// <returns>
        /// はい:1
        /// いいえ:0
        /// </returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern int MIDITrack_IsFloating(IntPtr pMIDITrack);

        /// <summary>
        /// MIDIトラックがコンダクタートラックとして正しいことを確認する。
        /// </summary>
        /// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
        /// <returns>
        /// 正しい:1
        /// 正しくない:0
        /// </returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern int MIDITrack_CheckSetupTrack(IntPtr pMIDITrack);

        /// <summary>
        /// MIDIトラックが非コンダクタートラックとして正しいことを確認する。
        /// </summary>
        /// <param name="pMIDITrack"></param>
        /// <param name="pMIDITrack">MIDIトラックへのポインタ</param>
        /// <returns>
        /// 正しい:1
        /// 正しくない:0
        /// </returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern int MIDITrack_CheckNonSetupTrack(IntPtr pMIDITrack);
        #endregion

        #region プロパティ
        /// <summary>
        /// アンマネージドのオブジェクトポインタ
        /// </summary>
        internal IntPtr UnManagedObjectPointer { get; private set; }

        /// <summary>
        /// MIDIトラックが浮遊トラックであるかどうか調べる。
        /// </summary>
        public bool IsFloating
        {
            get
            {
                int temp = MIDITrack_IsFloating(this.UnManagedObjectPointer);
                if (temp == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// MIDIトラックがコンダクタートラックとして正しいことを確認する。
        /// </summary>
        public bool CheckSetupTrack
        {
            get
            {
                int temp = MIDITrack_CheckSetupTrack(this.UnManagedObjectPointer);
                if (temp == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// MIDIトラックが非コンダクタートラックとして正しいことを確認する。
        /// </summary>
        public bool CheckNonSetupTrack
        {
            get
            {
                int temp = MIDITrack_CheckNonSetupTrack(this.UnManagedObjectPointer);
                if (temp == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #region コンストラクタ
        /// <summary>
        /// 空のMIDIトラックを作成して、オブジェクトを初期化します。
        /// </summary>
        public MIDITrack()
		{
			this.UnManagedObjectPointer = MIDITrack_Create();
			if (this.UnManagedObjectPointer == IntPtr.Zero)
			{
				throw new MIDIDataLibException("MIDIトラックの作成に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIトラックを複製して、オブジェクトを初期化します。
		/// </summary>
		/// <param name="mIDITrack"></param>
		public MIDITrack(MIDITrack mIDITrack)
		{
			this.UnManagedObjectPointer = MIDITrack_CreateClone(mIDITrack.UnManagedObjectPointer);
			if (this.UnManagedObjectPointer == IntPtr.Zero)
			{
				throw new MIDIDataLibException("MIDIトラックの複製に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIトラックのポインタを指定して、オブジェクトの初期化をします。
		/// </summary>
		/// <param name="track"></param>
		internal MIDITrack(IntPtr track)
		{
			this.UnManagedObjectPointer = track;
		}

		#endregion

		#region メソッド

		/// <summary>
		/// MIDIトラックをメモリ上から削除する。
		/// </summary>
		public void Delete()
		{
			MIDITrack_Delete(this.UnManagedObjectPointer);
			this.UnManagedObjectPointer = IntPtr.Zero;
		}

		/// <summary>
		/// MIDIトラックに任意のイベントを挿入する。挿入位置は、イベントの時刻により自動決定される。
		/// </summary>
		/// <param name="midiEvent">挿入するイベント</param>
		public void InsertEvent(MIDIEvent midiEvent)
		{
			int err = MIDITrack_InsertEvent(this.UnManagedObjectPointer, midiEvent.UnManagedObjectPointer);
			if (err == 0)
			{
				throw new MIDIDataLibException("MIDIイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIトラックに任意のイベントを挿入する。挿入位置はターゲットイベントの直前である。
		/// </summary>
		/// <param name="midiEvent">挿入するイベント</param>
		/// <param name="target">挿入位置指定用ターゲットイベント</param>
		public void InsertEventBefore(MIDIEvent midiEvent, MIDIEvent target)
		{
			int err = MIDITrack_InsertEventBefore(this.UnManagedObjectPointer, midiEvent.UnManagedObjectPointer, target.UnManagedObjectPointer);
			if (err == 0)
			{
				throw new MIDIDataLibException("MIDIイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIトラックに任意のイベントを挿入する。挿入位置はターゲットイベントの直後である。
		/// </summary>
		/// <param name="midiEvent">挿入するイベント</param>
		/// <param name="target">挿入位置指定用ターゲットイベント</param>
		public void InsertEventAfter(MIDIEvent midiEvent, MIDIEvent target)
		{
			int err = MIDITrack_InsertEventAfter(this.UnManagedObjectPointer, midiEvent.UnManagedObjectPointer, target.UnManagedObjectPointer);
			if (err == 0)
			{
				throw new MIDIDataLibException("MIDIイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// シーケンス番号イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="num">シーケンス番号(0～65535)</param>
		public void InsertSequenceNumber(int time, int num)
		{
			if (num < 0 || 65535 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "シーケンス番号は、0～65535の範囲内である必要があります。");
			}

			int err = MIDITrack_InsertSequenceNumber(this.UnManagedObjectPointer, time, num);
			if (err == 0)
			{
				throw new MIDIDataLibException("シーケンス番号の挿入に失敗しました。");
			}
		}

		/// <summary>
		/// テキストイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertTextEvent(int time, string text)
		{
			int err = MIDITrack_InsertTextEvent(this.UnManagedObjectPointer, time, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("テキストイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定してテキストイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertTextEventEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertTextEventEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("テキストイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 著作権イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertCopyrightNotice(int time, string text)
		{
			int err = MIDITrack_InsertCopyrightNotice(this.UnManagedObjectPointer, time, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("著作権イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定して著作権イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertCopyrightNoticeEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertCopyrightNoticeEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("著作権イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// シーケンス名・トラック名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertTrackName(int time, string text)
		{
			int err = MIDITrack_InsertTrackName(this.UnManagedObjectPointer, time, text);
			if(err == 0)
			{
				throw new MIDIDataLibException("シーケンス名・トラック名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定してシーケンス名・トラック名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertTrackNameEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertTrackNameEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("シーケンス名・トラック名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// インストゥルメント名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertInstrumentName(int time, string text)
		{
			int err = MIDITrack_InsertInstrumentName(this.UnManagedObjectPointer, time, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("インストゥルメント名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定してインストゥルメント名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertInstrumentNameEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertInstrumentNameEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("インストゥルメント名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 歌詞イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertLyric(int time, string text)
		{
			int err = MIDITrack_InsertLyric(this.UnManagedObjectPointer, time, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("歌詞イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定して歌詞イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertLyricEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertLyricEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("歌詞イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// マーカーイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertMarker(int time, string text)
		{
			int err = MIDITrack_InsertMarker(this.UnManagedObjectPointer, time, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("マーカーイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定してマーカーイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertMarkerEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertMarkerEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("マーカーイベントの挿入に失敗しました。");
			}
		}

        /// <summary>
        /// キューポイントイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時刻</param>
        /// <param name="text">文字列</param>
        public void InsertCuePoint(int time, string text)
        {
            int err = MIDITrack_InsertCuePoint(this.UnManagedObjectPointer, time, text);
            if (err == 0)
			{
                throw new MIDIDataLibException("キューポイントイベントの挿入に失敗しました。");
            }
		}

        /// <summary>
		/// 文字コードを指定してキューポイントイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
		/// <param name="time">絶対時刻</param>
        /// <param name="charCode">文字コード</param>
        /// <param name="text">文字列</param>
        public void InsertCuePointEx(int time, MIDIEvent.CharCodes charCode, string text)
        {
			int err = MIDITrack_InsertCuePointEx(this.UnManagedObjectPointer, time, (int)charCode, text);
            if (err == 0)
            {
				throw new MIDIDataLibException("キューポイントイベントの挿入に失敗しました。");
			}
        }

        /// <summary>
		/// プログラム名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
		/// <param name="time">絶対時刻</param>
        /// <param name="text">文字列</param>
		public void InsertProgramName(int time, string text)
		{
			int err = MIDITrack_InsertProgramName(this.UnManagedObjectPointer, time, text);
            if (err == 0)
            {
				throw new MIDIDataLibException("プログラム名イベントの挿入に失敗しました。");
			}
        }

		/// <summary>
		/// 文字コードを指定してプログラム名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertProgramNameEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertProgramNameEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("プログラム名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// デバイス名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="text">文字列</param>
		public void InsertDeviceName(int time, string text)
		{
			int err = MIDITrack_InsertDeviceName(this.UnManagedObjectPointer, time, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("デバイス名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// 文字コードを指定してデバイス名イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="charCode">文字コード</param>
		/// <param name="text">文字列</param>
		public void InsertDeviceNameEx(int time, MIDIEvent.CharCodes charCode, string text)
		{
			int err = MIDITrack_InsertDeviceNameEx(this.UnManagedObjectPointer, time, (int)charCode, text);
			if (err == 0)
			{
				throw new MIDIDataLibException("デバイス名イベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// チャンネルプリフィックスイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時刻</param>
		/// <param name="num">チャンネル番号(0～15)</param>
		public void InsertChannelPrefix(int time, int num)
		{
			if (num < 0 || 15 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "チャンネル番号は、0から15の間である必要があります。");
			}
			int err = MIDITrack_InsertChannelPrefix(this.UnManagedObjectPointer, time, num);
			if (err == 0)
			{
				throw new MIDIDataLibException("チャンネルプリフィックスイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// ポートプリフィックスイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時間</param>
		/// <param name="num">ポート番号(0～255)</param>
		public void InsertPortPrefix(int time, int num)
		{
			if (num < 0 || 255 < num)
			{
				throw new ArgumentOutOfRangeException(nameof(num), "ポート番号は、0から255の範囲である必要があります。");
			}

			int err = MIDITrack_InsertPortPrefix(this.UnManagedObjectPointer, time, num);
			if (err == 0)
			{
				throw new MIDIDataLibException("ポートプリフィックスイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// エンドオブトラックイベントを生成し、指定トラックに挿入する。
		/// </summary>
		/// <param name="time">絶対時間</param>
		public void InsertEndofTrack(int time)
		{
			int err = MIDITrack_InsertEndofTrack(this.UnManagedObjectPointer, time);
			if (err == 0)
			{
				throw new MIDIDataLibException("エンドオブトラックイベントの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// テンポイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
		/// </summary>
		/// <param name="time">絶対時間</param>
		/// <param name="tempo">テンポ</param>
		public void InsertTempo(int time, int tempo)
		{
			int err = MIDITrack_InsertTempo(this.UnManagedObjectPointer, time, tempo);
			if (err == 0)
			{
				throw new MIDIDataLibException("テンポイベントの挿入に失敗しました。");
			}
		}

        /// <summary>
        /// SMPTEオフセットイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="offset">オフセットオブジェクト</param>
		public void InsertSMPTEOffset(int time, SMPTEOffset offset)
		{
			int err = MIDITrack_InsertSMPTEOffset(this.UnManagedObjectPointer, time, (int)offset.Mode, offset.Hour, offset.Min, offset.Sec, offset.Frame, offset.SubFrame);
			if (err == 0)
			{
				throw new MIDIDataLibException("SMPTEオフセットイベントの挿入に失敗しました。");
			}
		}

        /// <summary>
        /// 拍子記号イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="timeSignature">拍子記号オブジェクト</param>
        public void InsertTimeSignature(int time, TimeSignature timeSignature)
        {
            int err = MIDITrack_InsertTimeSignature(this.UnManagedObjectPointer, time, timeSignature.nn, timeSignature.dd, timeSignature.cc, timeSignature.bb);
            if (err == 0)
            {
                throw new MIDIDataLibException("拍子記号イベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// 調性記号イベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="keySignature">調性記号</param>
        public void InsertKeySignature(int time, KeySignature keySignature)
        {
            int err = MIDITrack_InsertKeySignature(this.UnManagedObjectPointer, time, keySignature.sf, (int)keySignature.mi);
            if (err == 0)
            {
                throw new MIDIDataLibException("調性記号イベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// シーケンサー独自のイベントを生成し、指定トラックに挿入する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="buf">データ</param>
        public void InsertSequencerSpecific(int time, sbyte[] buf)
        {
            int err = MIDITrack_InsertSequencerSpecific(this.UnManagedObjectPointer, time, buf, buf.Length);
            if (err == 0)
            {
                throw new MIDIDataLibException("シーケンサー独自のイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// ノートオフイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="key">キー値(0～127)</param>
        /// <param name="vel">ベロシティ(0～127)</param>
        public void InsertNoteOff(int time, int ch, int key, int vel)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (key < 0 || 127 < key)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "キー値は0～127の範囲内である必要があります。");
            }

            if (vel < 0 || 127 < vel)
            {
                throw new ArgumentOutOfRangeException(nameof(vel), "ベロシティは0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertNoteOff(this.UnManagedObjectPointer, time, ch, key, vel);
            if (err == 0)
            {
                throw new MIDIDataLibException("ノートオフイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// ノートオンイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="key">キー値(0～127)</param>
        /// <param name="vel">ベロシティ(0～127)</param>
        public void InsertNoteOn(int time, int ch, int key, int vel)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (key < 0 || 127 < key)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "キー値は0～127の範囲内である必要があります。");
            }

            if (vel < 0 || 127 < vel)
            {
                throw new ArgumentOutOfRangeException(nameof(vel), "ベロシティは0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertNoteOn(this.UnManagedObjectPointer, time, ch, key, vel);
            if (err == 0)
            {
                throw new MIDIDataLibException("ノートオンイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// キーアフタータッチイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="key">キー値(0～127)</param>
        /// <param name="val">値(0～127)</param>
        public void InsertKeyAftertouch(int time,int ch, int key, int val)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (key < 0 || 127 < key)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "キー値は0～127の範囲内である必要があります。");
            }

            if (val < 0 || 127 < val)
            {
                throw new ArgumentOutOfRangeException(nameof(val), "値は0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertKeyAftertouch(this.UnManagedObjectPointer, time, ch, key, val);
            if (err == 0)
            {
                throw new MIDIDataLibException("キーアフタータッチイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// コントロールチェンジイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="num">コントロールナンバー(0～127)</param>
        /// <param name="val">値(0～127)</param>
        public void InsertControlChange(int time, int ch, int num, int val)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (num < 0 || 127 < num)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "コントロールナンバーは0～127の範囲内である必要があります。");
            }

            if (val < 0 || 127 < val)
            {
                throw new ArgumentOutOfRangeException(nameof(val), "値は0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertControlChange(this.UnManagedObjectPointer, time, ch, num, val);
            if (err == 0)
            {
                throw new MIDIDataLibException("コントロールチェンジイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// プログラムチェンジイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="num">プログラムナンバー(0～127)</param>
        public void InsertProgramChange(int time, int ch, int num)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (num < 0 || 127 < num)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "プログラムナンバーは0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertProgramChange(this.UnManagedObjectPointer, time, ch, num);
            if (err == 0)
            {
                throw new MIDIDataLibException("プログラムチェンジイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// チャンネルアフタータッチイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時間</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="val">値(0～127)</param>
        public void InsertChannelAftertouch(int time, int ch, int val)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (val < 0 || 127 < val)
            {
                throw new ArgumentOutOfRangeException(nameof(val), "値は0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertChannelAftertouch(this.UnManagedObjectPointer, time, ch, val);
            if (err == 0)
            {
                throw new MIDIDataLibException("チャンネルアフタータッチイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// ピッチベンドイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時刻</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="val">値(0～16383)</param>
        public void InsertPitchBend(int time, int ch, int val)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (val < 0 || 16383 < val)
            {
                throw new ArgumentOutOfRangeException(nameof(val), "値は0～16383の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertPitchBend(this.UnManagedObjectPointer, time, ch, val);
            if (err == 0)
            {
                throw new MIDIDataLibException("ピッチベンドイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// システムエクスクルーシブイベントを生成し、指定トラックに挿入する。挿入位置は時刻により自動決定する。
        /// </summary>
        /// <param name="time">絶対時刻</param>
        /// <param name="buf">データ部</param>
        public void InsertSysExEvent(int time, byte[] buf)
        {
            int err = MIDITrack_InsertSysExEvent(this.UnManagedObjectPointer, time, buf, buf.Length);
            if (err == 0)
            {
                throw new MIDIDataLibException("システムエクスクルーシブイベントの挿入に失敗しました。");
            }
        }

        /// <summary>
        /// ノートオンイベント、ノートオフイベントの2つのイベントを生成し、指定トラックに挿入する。
        /// </summary>
        /// <param name="time">絶対時刻</param>
        /// <param name="ch">チャンネル番号(0～15)</param>
        /// <param name="key">キー番号(0～127)</param>
        /// <param name="vel">ノートオンイベントのベロシティ</param>
        /// <param name="dur">長さ</param>
        public void InsertNote(int time, int ch, int key, int vel, int dur)
        {
            if (ch < 0 || 15 < ch)
            {
                throw new ArgumentOutOfRangeException(nameof(ch), "チャンネル番号は0～15の範囲内である必要があります。");
            }

            if (key < 0 || 127 < key)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "キー値は0～127の範囲内である必要があります。");
            }

            if (vel < 0 || 127 < vel)
            {
                throw new ArgumentOutOfRangeException(nameof(vel), "ベロシティは0～127の範囲内である必要があります。");
            }

            int err = MIDITrack_InsertNote(this.UnManagedObjectPointer, time, ch, key, vel, dur);
            if (err == 0)
            {
                throw new MIDIDataLibException("ノートイベントの挿入に失敗しました。");
            }

        }

        /// <summary>
        /// MIDIトラックから指定のMIDIイベントを除外する。指定MIDIイベントが他のMIDIイベントと結合している場合、結合しているMIDIイベントも同時に除外する。
        /// </summary>
        /// <param name="midiEvent"></param>
        public void RemoveEvent(MIDIEvent midiEvent)
        {
            int err = MIDITrack_RemoveEvent(this.UnManagedObjectPointer, midiEvent.UnManagedObjectPointer);
            if (err == 0)
            {
                throw new MIDIDataLibException("MIDIイベントの除外の失敗しました。");
            }
        }

        /// <summary>
        /// MIDIトラックから指定のMIDIイベントを除外する。指定MIDIイベントが他のMIDIイベントと結合している場合、結合を切り離し、指定したMIDIイベントのみを除外する。
        /// </summary>
        /// <param name="midiEvent">MIDIトラックへのポインタ</param>
        public void RemoveSingleEvent(MIDIEvent midiEvent)
        {
            int err = MIDITrack_RemoveSingleEvent(this.UnManagedObjectPointer, midiEvent.UnManagedObjectPointer);
            if (err == 0)
            {
                throw new MIDIDataLibException("MIDIイベントの除外の失敗しました。");
            }
        }
        #endregion

        #region ファイナライザー
        ~MIDITrack()
		{
			//浮遊トラックだったら消すように変更する。
			Delete();
		}
		#endregion
	}
}
