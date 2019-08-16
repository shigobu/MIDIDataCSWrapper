using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
    /// <summary>
    /// MIDIデータは、フォーマット、トラック数、タイムベース(タイムモード及び分解能)の情報を持ち、子に単数又は複数のトラックを持つことができる。
    /// </summary>
    public class MIDIData
    {
        #region DLLImport

        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_Create(int lFormat, int lNumTrack, int lTimeMode, int lTimeResolution);

        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern void MIDIData_Delete(IntPtr pMIDIData);

        /// <summary>
        /// 世界樹シーケンスファイル(*.skj)からMIDIデータを読み込む。
        /// </summary>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns>MIDIデータへのポインタ</returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_LoadFromBinary(string pszFileName);

        /// <summary>
        /// スタンダードMIDIファイル(*.mid)からMIDIデータを読み込む。
        /// </summary>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns>MIDIデータへのポインタ</returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_LoadFromSMF(string pszFileName);

        /// <summary>
        /// Cherryシーケンスファイル(*.chy)からMIDIデータを読み込む。
        /// </summary>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns>MIDIデータへのポインタ</returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_LoadFromCherry(string pszFileName);

        /// <summary>
        /// MIDICSVファイル(*.csv)からMIDIデータを読み込む。
        /// </summary>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns>MIDIデータへのポインタ</returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_LoadFromMIDICSV(string pszFileName);

        /// <summary>
        /// 旧Cakewalkシーケンスファイル(*.wrk)からMIDIデータを読み込む。
        /// </summary>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns>MIDIデータへのポインタ</returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_LoadFromWRK(string pszFileName);

        /// <summary>
        /// マビノギMMLファイル(*.mmml)からMIDIデータを読み込む。
        /// </summary>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns>MIDIデータへのポインタ</returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_LoadFromMabiMML(string pszFileName);

		/// <summary>
		/// MIDIデータを世界樹シーケンスファイル(*.skj)として保存する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszFileName">ファイル名</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern int MIDIData_SaveAsBinary(IntPtr pMIDIData, string pszFileName);

		/// <summary>
		/// MIDIデータをスタンダードMIDIファイル(*.mid)として保存する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszFileName">ファイル名</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SaveAsSMF(IntPtr pMIDIData, string pszFileName);

		/// <summary>
		/// MIDIデータをCherryシーケンスファイル(*.chy)として保存する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszFileName">ファイル名</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SaveAsCherry(IntPtr pMIDIData, string pszFileName);

		/// <summary>
		/// MIDIデータをMIDICSVファイル(*.csv)として保存する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszFileName">ファイル名</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SaveAsMIDICSV(IntPtr pMIDIData, string pszFileName);

		/// <summary>
		/// ターゲットトラックの直前にpMIDITrackで示すトラックを挿入する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pMIDITrack">挿入するMIDIトラックオブジェクトのポインタ</param>
		/// <param name="pTarget">ターゲットトラックのポインタ</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_InsertTrackBefore(IntPtr pMIDIData, IntPtr pMIDITrack, IntPtr pTarget);

		/// <summary>
		/// ターゲットトラックの直後にpMIDITrackで示すトラックを挿入する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pMIDITrack">挿入するMIDIトラックオブジェクトのポインタ</param>
		/// <param name="pTarget">ターゲットトラックのポインタ</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_InsertTrackAfter(IntPtr pMIDIData, IntPtr pMIDITrack, IntPtr pTarget);

		/// <summary>
		/// MIDIデータ内の全トラックの最後にpMIDITrackで示すトラックを挿入する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pMIDITrack">挿入するMIDIトラックオブジェクトのポインタ</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_AddTrack(IntPtr pMIDIData, IntPtr pMIDITrack);

		/// <summary>
		/// MIDIデータから指定のMIDIトラックを除外する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pMIDITrack">除外するMIDIトラックオブジェクトのポインタ</param>
		/// <returns></returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_RemoveTrack(IntPtr pMIDIData, IntPtr pMIDITrack);

		/// <summary>
		/// MIDIデータのフォーマットを返す。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>
		/// MIDIDATA_FORMAT0(=0), MIDIDATA_FORMAT1(=1), MIDIDATA_FORMAT2(=2)のいずれか。
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetFormat(IntPtr pMIDIData);

		/// <summary>
		/// MIDIデータのトラック数を返す。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>MIDIデータのトラック数</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetNumTrack(IntPtr pMIDIData);

		/// <summary>
		/// MIDIデータのタイムモードを返す。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>
		/// MIDIDATA_TPQNBASE(=0), 
		/// MIDIDATA_SMPTE24BASE(=24), 
		/// MIDIDATA_SMPTE25BASE(=25), 
		/// MIDIDATA_SMPTE29BASE(=29), 
		/// MIDIDATA_SMPTE30BASE(=30)
		/// のうちのいずれか。
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetTimeMode(IntPtr pMIDIData);

		/// <summary>
		/// MIDIデータのタイムレゾリューション(分解能)を返す。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>
		/// タイムモードがMIDIDATA_TQPNBASE(=0)の場合、MIDIDATA_MINTPQNRESOLUTION(=1)以上、MIDIDATA_MAXTPQNRESOLUTION(=32767)以下の値である。
		/// タイムモードがその他の場合、MIDIDATA_MINSMPTERESOLUTION(=1)以上、MIDIDATA_MAXSMPTERESOLUTION(=255)以下の値である。
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetTimeResolution(IntPtr pMIDIData);

		/// <summary>
		/// MIDIデータのタイムベース、すなわちタイムモードとタイムレゾリューション(分解能)を同時に取得する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pMode">タイムモード</param>
		/// <param name="pResolution">タイムレゾリューション(分解能)</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetTimeBase(IntPtr pMIDIData, out int pMode, out int pResolution);

		/// <summary>
		/// MIDIデータのタイトルを調べ、指定のバッファに格納する。
		/// ここでいうMIDIデータのタイトルとは、MIDIデータ内の最初のトラックの、最初のトラック名イベントに含まれる文字列である。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pBuf">タイトル文字列を格納するバッファ</param>
		/// <param name="lLen">最大取り込み長さ[文字]</param>
		/// <returns>pBuf</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIData_GetTitle(IntPtr pMIDIData, StringBuilder pBuf, int lLen);

		/// <summary>
		/// MIDIデータの著作権を調べ、指定のバッファに格納する。
		/// ここでいうMIDIデータの著作権とは、MIDIデータ内の最初のトラックの、最初の著作権イベントに含まれる文字列である。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pBuf">著作権文字列を格納するバッファ</param>
		/// <param name="lLen">最大取り込み長さ[文字]</param>
		/// <returns>pBuf</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIData_GetCopyright(IntPtr pMIDIData, StringBuilder pBuf, int lLen);

		/// <summary>
		/// MIDIデータのコメントを調べ、指定のバッファに格納する。
		/// ここでいうMIDIデータのコメントとは、MIDIデータ内の最初のトラックの、最初のテキストイベントに含まれる文字列である。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pBuf">コメント文字列を格納するバッファ</param>
		/// <param name="lLen">最大取り込み長さ[文字]</param>
		/// <returns>pBuf</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIData_GetComment(IntPtr pMIDIData, StringBuilder pBuf, int lLen);

		/// <summary>
		/// 最初のトラックへのポインタを返す。なければNULLを返す。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>最初のトラックへのポインタ</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIData_GetFirstTrack(IntPtr pMIDIData);

		/// <summary>
		/// 最後のトラックへのポインタを返す。なければNULLを返す。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>最後のトラックへのポインタ</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIData_GetLastTrack(IntPtr pMIDIData);

		/// <summary>
		/// 指定トラック番号のトラックへのポインタを返す。なければNULLを返す。
		/// この関数は低速であるので、あまり頻繁に使ってはならない。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTrackIndex">トラック番号(0～)</param>
		/// <returns>指定トラック番号のトラックへのポインタ</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr MIDIData_GetTrack(IntPtr pMIDIData, int lTrackIndex);

		/// <summary>
		/// MIDIデータの開始時刻を返す。開始時刻とは、全トラック中における最も最初のイベントの時刻である。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>MIDIデータの開始時刻</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetBeginTime(IntPtr pMIDIData);

		/// <summary>
		/// MIDIデータの終了時刻を返す。終了時刻とは、全トラック中における最も最後のイベントの時刻である。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>MIDIデータの終了時刻</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetEndTime(IntPtr pMIDIData);

		/// <summary>
		/// このMIDIデータにXFデータ(YAMAHAの拡張形式)であることを示すシーケンサ独自のイベントが含まれている場合、XFのヴァージョンを取得する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>XFデータ(YAMAHAの拡張形式)のヴァージョン。XFデータでない場合は0。</returns>
		/// <remarks>具体的には、シーケンサ固有のイベントで、{43 7B 00 58 46 Mj Mn S1 S0} を探し、(Mj | (Mn &lt;&lt; 8) | (S1 &lt;&lt; 16) | (S0 &lt;&lt; 24)) を返す。XFデータでない場合は0を返す。</remarks>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_GetXFVersion(IntPtr pMIDIData);

		/// <summary>
		/// MIDIデータのフォーマットを設定する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lFormat">MIDIデータのフォーマット</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0		
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SetFormat(IntPtr pMIDIData, int lFormat);

		/// <summary>
		/// MIDIデータのタイムモードとタイムレゾリューションを同時に設定する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTimeMode">タイムモード</param>
		/// <param name="lTimeResolution">タイムレゾリューション</param>
		/// <returns>
		/// 正常終了:1
		/// 異常終了:0		
		/// </returns>
		/// <remarks>
		/// この関数はタイムベース変換機能を含んでいる。
		/// それゆえ、タイムモードとタイムレゾリューションを別々に設定する関数は用意されていない。
		/// </remarks>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SetTimeBase(IntPtr pMIDIData, int lTimeMode, int lTimeResolution);

		/// <summary>
		/// MIDIデータのタイトルを設定する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszText">タイトル</param>
		/// <returns>未定義</returns>
		/// <remarks>
		/// ここでいうMIDIデータのタイトルとは、MIDIデータ内の最初のトラックの、最初のトラック名イベントに含まれる文字列である。
		/// 該当イベントが存在しない場合、自動的に追加される。pszTextがNULLの場合、タイトルは削除される。
		/// </remarks>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SetTitle(IntPtr pMIDIData, string pszText);

		/// <summary>
		/// MIDIデータの著作権を設定する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszText">著作権</param>
		/// <returns>未定義</returns>
		/// <remarks>
		/// ここでいうMIDIデータの著作権とは、MIDIデータ内の最初のトラックの、最初の著作権イベントに含まれる文字列である。
		/// 該当イベントが存在しない場合、自動的に追加される。pszTextがNULLの場合、著作権は削除される。
		/// </remarks>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SetCopyright(IntPtr pMIDIData, string pszText);

		/// <summary>
		/// MIDIデータのコメントを設定する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="pszText">コメント</param>
		/// <returns>未定義</returns>
		/// <remarks>
		/// ここでいうMIDIデータのコメントとは、MIDIデータ内の最初のトラックの、最初のテキストイベントに含まれる文字列である。
		/// 該当イベントが存在しない場合、自動的に追加される。pszTextがNULLの場合、コメントは削除される。
		/// </remarks>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_SetComment(IntPtr pMIDIData, string pszText);

		/// <summary>
		/// 指定したMIDIデータに含まれるMIDIトラックの数を数える。また、m_lNumTrackの値を更新する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <returns>MIDIトラック数</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_CountTrack(IntPtr pMIDIData);

		/// <summary>
		/// lTimeで示される時刻から、ミリ秒単位の時刻を計算して取得する。
		/// この関数は、最初のMIDIトラックのみに含まれるテンポイベントを使って計算する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTime">時刻</param>
		/// <returns>ミリ秒単位の時刻</returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_TimeToMillisec(IntPtr pMIDIData, int lTime);

		/// <summary>
		/// lMillisecで示されるミリ秒単位の時刻から、ティック単位の時刻(TPQNベースの場合)又はサブフレーム単位の時刻(SMPTEベースの場合)を取得する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lMillisec">ミリ秒単位の時刻</param>
		/// <returns>
		/// ティック単位の時刻(TPQNベースの場合)
		/// サブフレーム単位の時刻(SMPTEベースの場合)
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_MillisecToTime(IntPtr pMIDIData, int lMillisec);

		/// <summary>
		/// MIDIデータのタイムモードがTPQNベースの場合、小節：拍：ティックで表されるタイムから、累積ティック単位のタイムを計算してバッファに格納する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lMeasure">小節番号(0オリジン)</param>
		/// <param name="lBeat">拍番号(0オリジン)</param>
		/// <param name="lTick">ティック番号(0オリジン)</param>
		/// <param name="pTime">累積ティック単位のタイムを格納するバッファ</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_MakeTime(IntPtr pMIDIData, int lMeasure, int lBeat, int lTick, out int pTime);

		/// <summary>
		/// この関数はMIDIData_MakeTimeと変わらないが、同時に指定時刻における拍子記号情報を得ることができる。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lMeasure">小節番号(0オリジン)</param>
		/// <param name="lBeat">拍番号(0オリジン)</param>
		/// <param name="lTick">ティック番号(0オリジン)</param>
		/// <param name="pTime">累積ティック単位のタイムを格納するバッファ</param>
		/// <param name="pnn">最新拍子記号の分子を格納するバッファ</param>
		/// <param name="pdd">最新拍子記号の分母の指数部分を格納するバッファ</param>
		/// <param name="pcc">1拍あたりのMIDIクロック数</param>
		/// <param name="pbb">1拍の長さを32分音符の数で表す</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_MakeTimeEx(IntPtr pMIDIData, int lMeasure, int lBeat, int lTick, out int pTime, out int pnn, out int pdd, out int pcc, out int pbb);

		/// <summary>
		/// MIDIデータのタイムモードがTPQNベースの場合、累積ティック単位のタイムから、小節：拍：ティックで表されるタイムを計算してバッファに格納する。
		/// MIDIデータのタイムモードがSMPTEベースの場合、指定したタイムから、フレーム番号とサブフレーム番号(0以上(分解能-1)以下)を計算してバッファに格納する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTime">分解すべき累積タイム</param>
		/// <param name="pMeasure">小節番号(0オリジン)を格納するバッファ</param>
		/// <param name="pBeat">拍番号(0オリジン)を格納するバッファ</param>
		/// <param name="pTick">ティック番号(0オリジン)を格納するバッファ</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_BreakTime(IntPtr pMIDIData, int lTime, out int pMeasure, out int pBeat, out int pTick);

		/// <summary>
		/// この関数はMIDIData_BreakTimeと変わらないが、同時に指定時刻における拍子記号情報を得ることができる。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTime">分解すべき累積タイム</param>
		/// <param name="pMeasure">小節番号(0オリジン)を格納するバッファ</param>
		/// <param name="pBeat">拍番号(0オリジン)を格納するバッファ</param>
		/// <param name="pTick">ティック番号(0オリジン)を格納するバッファ</param>
		/// <param name="pnn">最新拍子記号の分子を格納するバッファ</param>
		/// <param name="pdd">最新拍子記号の分母の指数部分を格納するバッファ</param>
		/// <param name="pcc">1拍あたりのMIDIクロック数</param>
		/// <param name="pbb">1拍の長さを32分音符の数で表す</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_BreakTimeEx(IntPtr pMIDIData, int lTime, out int pMeasure, out int pBeat, out int pTick, out int pnn, out int pdd, out int pcc, out int pbb);

		/// <summary>
		/// lTimeにおけるテンポ(lTimeにテンポイベントがない場合は直前のテンポ)を調べ、バッファに格納する。
		/// </summary>
		/// <param name="pMIDIData">データ</param>
		/// <param name="lTime">時刻</param>
		/// <param name="pTempo">テンポを格納するバッファ</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_FindTempo(IntPtr pMIDIData, int lTime, out int pTempo);

		/// <summary>
		/// lTimeにおける拍子記号(lTimeに拍子記号イベントがない場合は直前の拍子記号)を調べ、バッファに格納する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTime">時刻</param>
		/// <param name="pnn">分子を格納するバッファ</param>
		/// <param name="pdd">分母を格納するバッファ</param>
		/// <param name="pcc">1拍あたりのMIDIクロック数を格納するバッファ</param>
		/// <param name="pbb">1拍当たりの32分音符の数を格納するバッファ</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_FindTimeSignature(IntPtr pMIDIData, int lTime, out int pnn, out int pdd, out int pcc, out int pbb);

		/// <summary>
		/// lTimeにおける調性記号(lTimeに調性記号イベントがない場合は直前の調性記号)を調べ、バッファに格納する。
		/// </summary>
		/// <param name="pMIDIData">MIDIデータへのポインタ</param>
		/// <param name="lTime">時刻</param>
		/// <param name="psf">#又は♭の数を格納するバッファ</param>
		/// <param name="pmi">長調か短調かを格納するバッファ</param>
		/// <returns>
		/// 正常終了：0以外
		/// 異常終了：0
		/// </returns>
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIData_FindKeySignature(IntPtr pMIDIData, int lTime, out int psf, out int pmi);
		#endregion

		#region 列挙型
        /// <summary>
        /// MIDIデータのフォーマット
        /// </summary>
        public enum Formats
        {
            Format0 = 0,
            Format1 = 1,
            Format2 = 2
        }

        /// <summary>
        /// MIDIデータのタイムモード
        /// </summary>
        public enum TimeModes
        {
            TPQN = 0,
            SMPTE24 = 24,
            SMPTE25 = 25,
            SMPTE29 = 29,
            SMPTE30 = 30
        }
        #endregion

        #region 定数

        //ファイル拡張子
        private const string midiExt = ".mid";
        private const string skjExt = ".skj";
        private const string cherryExt = ".chy";
        private const string midiCsvExt = ".csv";
        private const string cakewalkExt = ".wrk";
        private const string mabinogiMMLExt = ".mmml";

		//文字列バッファのサイズ
		private const int bufferSize = 256;
        #endregion

        #region プロパティ
        /// <summary>
        /// MIDIDataオブジェクトのポインタ
        /// </summary>
        private IntPtr UnManagedObjectPointer { get; set; }

		/// <summary>
		/// MIDIデータのフォーマットを取得、設定します。
		/// </summary>
		public Formats Format
		{
			get
			{
				return (Formats)MIDIData_GetFormat(this.UnManagedObjectPointer);
			}
			set
			{
				MIDIData_SetFormat(this.UnManagedObjectPointer, (int)value);
			}
		}

		/// <summary>
		/// MIDIデータのトラック数を取得します。
		/// </summary>
		public int NumTrack
		{
			get
			{
				return MIDIData_GetNumTrack(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// MIDIデータのタイムモードを取得します。
		/// </summary>
		public TimeModes TimeMode
		{
			get
			{
				return (TimeModes)MIDIData_GetTimeMode(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// MIDIデータのタイムレゾリューション(分解能)を取得します。
		/// </summary>
		public int TimeResolution
		{
			get
			{
				return MIDIData_GetTimeResolution(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// MIDIデータのタイトルを取得、設定します。
		/// </summary>
		public string Title
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(bufferSize);
				MIDIData_GetTitle(this.UnManagedObjectPointer, stringBuilder, bufferSize);
				return stringBuilder.ToString();
			}
			set
			{
				MIDIData_SetTitle(this.UnManagedObjectPointer, value);
			}
		}

		/// <summary>
		/// MIDIデータの著作権を取得、設定します。
		/// </summary>
		public string Copyright
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(bufferSize);
				MIDIData_GetCopyright(this.UnManagedObjectPointer, stringBuilder, bufferSize);
				return stringBuilder.ToString();
			}
			set
			{
				MIDIData_SetCopyright(this.UnManagedObjectPointer, value);
			}
		}

		/// <summary>
		/// MIDIデータのコメントを取得、設定します。
		/// </summary>
		public string Comment
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(bufferSize);
				MIDIData_GetComment(this.UnManagedObjectPointer, stringBuilder, bufferSize);
				return stringBuilder.ToString();
			}
			set
			{
				MIDIData_SetComment(this.UnManagedObjectPointer, value);
			}
		}

		/// <summary>
		/// 最初のMIDIトラックを取得します。
		/// </summary>
		public MIDITrack FirstTrack
		{
			get
			{
				IntPtr midiTrack = MIDIData_GetFirstTrack(this.UnManagedObjectPointer);
				if (midiTrack == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDITrack(midiTrack);
				}
			}
		}

		/// <summary>
		/// 最後のMIDIトラックを取得します。
		/// </summary>
		public MIDITrack LastTrack
		{
			get
			{
				IntPtr midiTrack = MIDIData_GetLastTrack(this.UnManagedObjectPointer);
				if (midiTrack == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new MIDITrack(midiTrack);
				}
			}
		}

		/// <summary>
		/// MIDIデータの開始時刻を取得します。
		/// </summary>
		public int BeginTime
		{
			get
			{
				return MIDIData_GetBeginTime(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// MIDIデータの終了時刻を取得します。
		/// </summary>
		public int EndTime
		{
			get
			{
				return MIDIData_GetEndTime(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// このMIDIデータにXFデータ(YAMAHAの拡張形式)であることを示すシーケンサ独自のイベントが含まれている場合、XFのヴァージョンを取得する。
		/// </summary>
		public int XFVersion
		{
			get
			{
				return MIDIData_GetXFVersion(this.UnManagedObjectPointer);
			}
		}

		/// <summary>
		/// 指定したMIDIデータに含まれるMIDIトラックの数を数える。
		/// </summary>
		public int CountTrack
		{
			get
			{
				return MIDIData_CountTrack(this.UnManagedObjectPointer);
			}
		}

		#endregion

		#region 静的メソッド
        /// <summary>
        /// 世界樹シーケンスファイル(*.skj)からMIDIデータを読み込み、MIDIデータオブジェクトを作成します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static MIDIData LoadFromBinary(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //ロード
            IntPtr midiDataPtr = MIDIData_LoadFromBinary(fileName);

            if (midiDataPtr == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイルの読み込みに失敗しました。");
            }

            return new MIDIData(midiDataPtr);
        }

        /// <summary>
        /// スタンダードMIDIファイル(*.mid)からMIDIデータを読み込み、MIDIデータオブジェクトを作成します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static MIDIData LoadFromSMF(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //ロード
            IntPtr midiDataPtr = MIDIData_LoadFromSMF(fileName);

            if (midiDataPtr == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイルの読み込みに失敗しました。");
            }

            return new MIDIData(midiDataPtr);
        }

        /// <summary>
        /// Cherryシーケンスファイル(*.chy)からMIDIデータを読み込み、MIDIデータオブジェクトを作成します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static MIDIData LoadFromCherry(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //ロード
            IntPtr midiDataPtr = MIDIData_LoadFromCherry(fileName);

            if (midiDataPtr == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイルの読み込みに失敗しました。");
            }

            return new MIDIData(midiDataPtr);
        }

        /// <summary>
        /// MIDICSVファイル(*.csv)からMIDIデータを読み込み、MIDIデータオブジェクトを作成します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static MIDIData LoadFromMIDICSV(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //ロード
            IntPtr midiDataPtr = MIDIData_LoadFromMIDICSV(fileName);

            if (midiDataPtr == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイルの読み込みに失敗しました。");
            }

            return new MIDIData(midiDataPtr);
        }

        /// <summary>
        /// 旧Cakewalkシーケンスファイル(*.wrk)からMIDIデータを読み込み、MIDIデータオブジェクトを作成します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static MIDIData LoadFromWRK(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //ロード
            IntPtr midiDataPtr = MIDIData_LoadFromWRK(fileName);

            if (midiDataPtr == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイルの読み込みに失敗しました。");
            }

            return new MIDIData(midiDataPtr);
        }

        /// <summary>
        /// マビノギMMLファイル(*.mmml)からMIDIデータを読み込み、MIDIデータオブジェクトを作成します。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        public static MIDIData LoadFromMabiMML(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //ロード
            IntPtr midiDataPtr = MIDIData_LoadFromMabiMML(fileName);

            if (midiDataPtr == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイルの読み込みに失敗しました。");
            }

            return new MIDIData(midiDataPtr);
        }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// MIDIデータのポインタを指定して、オブジェクトを初期化します。
		/// </summary>
		/// <param name="midiData">MIDIデータのポインタ</param>
		private MIDIData(IntPtr midiData)
        {
            UnManagedObjectPointer = midiData;
        }

        /// <summary>
        /// MIDIデータをメモリ上に新規生成します
        /// </summary>
        /// <param name="format">フォーマット</param>
        /// <param name="numTrack">初期トラック数(0～)</param>
        /// <param name="timeMode">タイムモード</param>
        /// <param name="timeResolution">タイムレゾリューション</param>
        public MIDIData(Formats format, int numTrack, TimeModes timeMode, int timeResolution)
        {
            UnManagedObjectPointer = MIDIData_Create((int)format, numTrack, (int)timeMode, timeResolution);
            if (UnManagedObjectPointer == IntPtr.Zero)
            {
                throw new MIDIDataLibException("MIDIデータの作成に失敗しました。");
            }
        }

        /// <summary>
        /// ファイル名を指定してMIDIデータを初期化します。
        /// 拡張子で読み込み処理を分岐させます。
        /// 対応拡張子は、skj,mid,chy,csv,wrk,mmmlです。
        /// これ以外の拡張子の場合、ArgumentExceptionが投げられます。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public MIDIData(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            //ファイルが無い場合
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }

            //拡張子取得
            string extension = Path.GetExtension(fileName);

            //拡張子に応じて分岐
            switch (extension)
            {
                case midiExt:
                    UnManagedObjectPointer = MIDIData_LoadFromSMF(fileName);
                    break;

                case skjExt:
                    UnManagedObjectPointer = MIDIData_LoadFromBinary(fileName);
                    break;

                case cherryExt:
                    UnManagedObjectPointer = MIDIData_LoadFromCherry(fileName);
                    break;

                case midiCsvExt:
                    UnManagedObjectPointer = MIDIData_LoadFromMIDICSV(fileName);
                    break;

                case cakewalkExt:
                    UnManagedObjectPointer = MIDIData_LoadFromWRK(fileName);
                    break;

                case mabinogiMMLExt:
                    UnManagedObjectPointer = MIDIData_LoadFromMabiMML(fileName);
                    break;
                
                default:
                    throw new ArgumentException("非対応の拡張子です。", nameof(fileName));
                    break;
            }

            if (UnManagedObjectPointer == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイル読み込みに失敗しました。");
            }
        }
		#endregion

		#region　メソッド
		/// <summary>
		/// MIDIデータを世界樹シーケンスファイル(*.skj)として保存する。
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		public void SaveAsBinary(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException(nameof(fileName));
			}

			int err = MIDIData_SaveAsBinary(UnManagedObjectPointer, fileName);
			if (err == 0)
			{
				throw new MIDIDataLibException("ファイルの保存に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIデータをスタンダードMIDIファイル(*.mid)として保存する。
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		public void SaveAsSMF(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException(nameof(fileName));
			}

			int err = MIDIData_SaveAsSMF(UnManagedObjectPointer, fileName);
			if (err == 0)
			{
				throw new MIDIDataLibException("ファイルの保存に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIデータをCherryシーケンスファイル(*.chy)
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		public void SaveAsCherry(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException(nameof(fileName));
			}

			int err = MIDIData_SaveAsCherry(UnManagedObjectPointer, fileName);
			if (err == 0)
			{
				throw new MIDIDataLibException("ファイルの保存に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIデータをMIDICSVファイル(*.csv)として保存する。
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		public void SaveAsMIDICSV(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException(nameof(fileName));
			}

			int err = MIDIData_SaveAsMIDICSV(UnManagedObjectPointer, fileName);
			if (err == 0)
			{
				throw new MIDIDataLibException("ファイルの保存に失敗しました。");
			}
		}

		/// <summary>
		/// ターゲットトラックの直前にmidiTrackで示すトラックを挿入する。
		/// </summary>
		/// <param name="midiTrack">挿入するMIDIトラック</param>
		/// <param name="target">ターゲットトラック</param>
		public void InsertTrackBefore(MIDITrack midiTrack, MIDITrack target)
		{
			int err = 0;
			if (target == null)
			{
				err = MIDIData_InsertTrackBefore(UnManagedObjectPointer, midiTrack.UnManagedObjectPointer, IntPtr.Zero);
			}
			else
			{
				err = MIDIData_InsertTrackBefore(UnManagedObjectPointer, midiTrack.UnManagedObjectPointer, target.UnManagedObjectPointer);
			}

			if (err == 0)
			{
				throw new MIDIDataLibException("トラックの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// ターゲットトラックの直後にmidiTrackで示すトラックを挿入する。
		/// </summary>
		/// <param name="midiTrack">挿入するMIDIトラック</param>
		/// <param name="target">ターゲットトラック</param>
		public void InsertTrackAfter(MIDITrack midiTrack, MIDITrack target)
		{
			int err = 0;
			if (target == null)
			{
				err = MIDIData_InsertTrackAfter(UnManagedObjectPointer, midiTrack.UnManagedObjectPointer, IntPtr.Zero);
			}
			else
			{
				err = MIDIData_InsertTrackAfter(UnManagedObjectPointer, midiTrack.UnManagedObjectPointer, target.UnManagedObjectPointer);
			}

			if (err == 0)
			{
				throw new MIDIDataLibException("トラックの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIデータ内の全トラックの最後にmidiTrackで示すトラックを挿入する。
		/// </summary>
		/// <param name="midiTrack">挿入するMIDIトラック</param>
		public void AddTrack(MIDITrack midiTrack)
		{
			int err = 0;
			err = MIDIData_AddTrack(this.UnManagedObjectPointer, midiTrack.UnManagedObjectPointer);
			if (err == 0)
			{
				throw new MIDIDataLibException("トラックの挿入に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIデータから指定のMIDIトラックを除外する。
		/// </summary>
		/// <param name="midiTrack">除外するMIDIトラック</param>
		public void RemoveTrack(MIDITrack midiTrack)
		{
			int err = 0;
			err = MIDIData_RemoveTrack(this.UnManagedObjectPointer, midiTrack.UnManagedObjectPointer);
			if (err == 0)
			{
				throw new MIDIDataLibException("トラックの除外に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIデータのタイムベース、すなわちタイムモードとタイムレゾリューション(分解能)を同時に取得する。
		/// </summary>
		/// <param name="timeMode">タイムモード</param>
		/// <param name="resolution">タイムレゾリューション(分解能)</param>
		public void GetTimeBase(out TimeModes timeMode, out int resolution)
		{
			int tempTimeMode = 0;
			int err = MIDIData_GetTimeBase(this.UnManagedObjectPointer, out tempTimeMode, out resolution);
			if (err == 0)
			{
				throw new MIDIDataLibException("タイムベース取得に失敗しました。");
			}
			timeMode = (TimeModes)tempTimeMode;
		}

		/// <summary>
		/// 指定トラック番号のトラックを返す。
		/// </summary>
		/// <param name="trackIndex">トラック番号</param>
		/// <returns>指定トラック番号のトラック</returns>
		/// <remarks>この関数は低速であるので、あまり頻繁に使ってはならない。</remarks>
		private MIDITrack GetTrack(int trackIndex)
		{
			IntPtr track = MIDIData_GetTrack(this.UnManagedObjectPointer, trackIndex);
			if (track == IntPtr.Zero)
			{
				return null;
			}
			else
			{
				return new MIDITrack(track);
			}
		}

		/// <summary>
		/// timeで示される時刻から、ミリ秒単位の時刻を計算して取得する。
		/// </summary>
		/// <param name="time">時刻</param>
		/// <returns>ミリ秒単位の時刻</returns>
		public int TimeToMillisec(int time)
		{
			return MIDIData_TimeToMillisec(this.UnManagedObjectPointer, time);
		}

		/// <summary>
		/// millisecで示されるミリ秒単位の時刻から、ティック単位の時刻(TPQNベースの場合)又はサブフレーム単位の時刻(SMPTEベースの場合)を取得する。
		/// </summary>
		/// <param name="millisec">ミリ秒単位の時刻</param>
		/// <returns>
		/// ティック単位の時刻(TPQNベースの場合)
		/// サブフレーム単位の時刻(SMPTEベースの場合)
		/// </returns>
		public int MillisecToTime(int millisec)
		{
			return MIDIData_MillisecToTime(this.UnManagedObjectPointer, millisec);
		}

		/// <summary>
		/// MIDIデータのタイムモードがTPQNベースの場合、小節：拍：ティックで表されるタイムから、累積ティック単位のタイムを計算してバッファに格納する。
		/// </summary>
		/// <param name="measureBeatTick">小節：拍：ティックオブジェクト</param>
		/// <returns>累積ティック単位のタイム</returns>
		public int MakeTime(MeasureBeatTick measureBeatTick)
		{
			int tempTime = 0;
			int err = MIDIData_MakeTime(this.UnManagedObjectPointer, measureBeatTick.Measure, measureBeatTick.Beat, measureBeatTick.Tick, out tempTime);
			if (err == 0)
			{
				throw new MIDIDataLibException("累積ティック単位のタイムの取得に失敗しました。");
			}
			return tempTime;
		}

		/// <summary>
		/// この関数はMakeTimeと変わらないが、同時に指定時刻における拍子記号情報を得ることができる。
		/// </summary>
		/// <param name="measureBeatTick">小節：拍：ティックオブジェクト</param>
		/// <param name="time">累積ティック単位のタイム</param>
		/// <param name="timeSignature">拍子記号情報</param>
		public void MakeTimeEx(MeasureBeatTick measureBeatTick, out int time, out TimeSignature timeSignature)
		{
			int nn, dd, cc, bb;
			int err = MIDIData_MakeTimeEx(this.UnManagedObjectPointer, measureBeatTick.Measure, measureBeatTick.Beat, measureBeatTick.Tick, out time, out nn, out dd, out cc, out bb);
			if (err == 0)
			{
				throw new MIDIDataLibException("累積ティック単位のタイムの取得と拍子記号取得に失敗しました。");
			}
			timeSignature = new TimeSignature(nn, dd, cc, bb);
		}

		/// <summary>
		/// MIDIデータのタイムモードがTPQNベースの場合、累積ティック単位のタイムから、小節：拍：ティックで表されるタイムを計算して返す
		/// MIDIデータのタイムモードがSMPTEベースの場合、指定したタイムから、フレーム番号とサブフレーム番号(0以上(分解能-1)以下)を計算して返す。
		/// フレーム番号はMeasureに、サブフレーム番号はTickに格納され、Beatは常に0となる。。
		/// </summary>
		/// <param name="time">分解すべき累積タイム</param>
		/// <returns>MeasureBeatTickオブジェクト</returns>
		public MeasureBeatTick BreakTime(int time)
		{
			int measure, beat, tick;
			int err = MIDIData_BreakTime(this.UnManagedObjectPointer, time, out measure, out beat, out tick);
			if (err == 0)
			{
				throw new MIDIDataLibException("小節：拍：ティック情報の取得に失敗しました。");
			}
			return new MeasureBeatTick(measure, beat, tick);
		}

		/// <summary>
		/// この関数はMIDIData_BreakTimeと変わらないが、同時に指定時刻における拍子記号情報を返す。
		/// </summary>
		/// <param name="time">分解すべき累積タイム</param>
		/// <param name="measureBeatTick">MeasureBeatTickオブジェクト</param>
		/// <param name="timeSignature">拍子記号情報</param>
		public void BreakTimeEx(int time, out MeasureBeatTick measureBeatTick, out TimeSignature timeSignature)
		{
			int measure, beat, tick;
			int nn, dd, cc, bb;
			int err = MIDIData_BreakTimeEx(this.UnManagedObjectPointer, time, out measure, out beat, out tick, out nn, out dd, out cc, out bb);
			if (err == 0)
			{
				throw new MIDIDataLibException("小節：拍：ティック情報の取得と拍子記号情報の取得に失敗しました。");
			}
			measureBeatTick = new MeasureBeatTick(measure, beat, tick);
			timeSignature = new TimeSignature(nn, dd, cc, bb);
		}

		/// <summary>
		/// timeにおけるテンポ(timeにテンポイベントがない場合は直前のテンポ)を調べ返す。
		/// </summary>
		/// <param name="time">時刻</param>
		/// <returns>テンポ</returns>
		public int FindTempo(int time)
		{
			int tempo = 0;
			int err = MIDIData_FindTempo(this.UnManagedObjectPointer, time, out tempo);
			if (err == 0)
			{
				throw new MIDIDataLibException("テンポ取得に失敗しました。");
			}
			return tempo;
		}

		/// <summary>
		/// timeにおける拍子記号(timeに拍子記号イベントがない場合は直前の拍子記号)を調べ返す。
		/// </summary>
		/// <param name="time">時刻</param>
		/// <returns></returns>
		public TimeSignature FindTimeSignature(int time)
		{
			int nn, dd, cc, bb;
			int err = MIDIData_FindTimeSignature(this.UnManagedObjectPointer, time, out nn, out dd, out cc, out bb);
			if (err == 0)
			{
				throw new MIDIDataLibException("拍子記号の取得に失敗しました。");
			}
			return new TimeSignature(nn, dd, cc, bb);
		}
		#endregion

		#region インデクサー
		/// <summary>
		/// 指定トラック番号のトラックを返す。低速なので、頻繁な使用禁止。foreachループを使用すること。
		/// </summary>
		/// <param name="index">トラック番号</param>
		/// <returns></returns>
		public MIDITrack this [int index]
		{
			get
			{
				MIDITrack midiTrack = GetTrack(index);
				if (midiTrack == null)
				{
					throw new IndexOutOfRangeException();
				}
				else
				{
					return midiTrack;
				}
			}
		}
		#endregion

		#region ファイナライザー
		~MIDIData()
        {
			MIDIData_Delete(UnManagedObjectPointer);
			UnManagedObjectPointer = IntPtr.Zero;
		}
        #endregion
    }
}
