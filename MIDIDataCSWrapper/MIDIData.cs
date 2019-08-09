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
    public class MIDIData : IDisposable
    {
        #region DLLImport
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr MIDIData_Create(int lFormat, int lNumTrack, int lTimeMode, int lTimeResolution);

        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern void MIDIData_Delete(IntPtr pMIDIData);


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
        private IntPtr MIDIDataInstance { get; set; }

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

        /// <summary>
        /// MIDIデータのポインタを指定して、オブジェクトを初期化します。
        /// </summary>
        /// <param name="MIDIData">MIDIデータのポインタ</param>
        private MIDIData(IntPtr MIDIData)
        {
            MIDIDataInstance = MIDIData;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)。
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。

                MIDIData_Delete(MIDIDataInstance);
                MIDIDataInstance = IntPtr.Zero;

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        ~MIDIData()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(false);
        }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        void IDisposable.Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
