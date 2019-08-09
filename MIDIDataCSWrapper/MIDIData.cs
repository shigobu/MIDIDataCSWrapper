using System;
using System.Collections.Generic;
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
        [DllImport("MIDIData.dll")]
        private static extern IntPtr MIDIData_Create(int lFormat, int lNumTrack, int lTimeMode, int lTimeResolution);
        #endregion

        /// <summary>
        /// MIDIデータのフォーマット
        /// </summary>
        public enum Format
        {
            Format0 = 0,
            Format1 = 1,
            Format2 = 2
        }

        /// <summary>
        /// MIDIデータのタイムモード
        /// </summary>
        public enum TimeMode
        {
            TPQN = 0,
            SMPTE24 = 24,
            SMPTE25 = 25,
            SMPTE29 = 29,
            SMPTE30 = 30
        }

        /// <summary>
        /// MIDIDataオブジェクトのポインタ
        /// </summary>
        IntPtr MIDIDataInstance = IntPtr.Zero;

        /// <summary>
        /// MIDIデータをメモリ上に新規生成します
        /// </summary>
        /// <param name="format">フォーマット</param>
        /// <param name="numTrack">初期トラック数(0～)</param>
        /// <param name="timeMode">タイムモード</param>
        /// <param name="timeResolution">タイムレゾリューション</param>
        public MIDIData(Format format, int numTrack, TimeMode timeMode, int timeResolution)
        {
            MIDIDataInstance = MIDIData_Create((int)format, numTrack, (int)timeMode, timeResolution);
            if (MIDIDataInstance == IntPtr.Zero)
            {
                throw new MIDIDataLibException("MIDIデータの作成に失敗しました。");
            }
        }
    }
}
