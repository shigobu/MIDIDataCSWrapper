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
    public class MIDIData : IDisposable
    {
        #region DLLImport

        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern int MIDIDataLib_SetDefaultCharCode(int lCharCode);

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
        /// <param name="pMIDIData">MIDIデータオブジェクトのポインタ</param>
        /// <param name="pszFileName">ファイル名</param>
        /// <returns></returns>
        [DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
        private static extern int MIDIData_SaveAsBinary(IntPtr pMIDIData, string pszFileName);
        #endregion

        #region 列挙型
        public enum CharCode
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
        #endregion

        #region 定数

        //ファイル拡張子
        private const string midiExt = ".mid";
        private const string skjExt = ".skj";
        private const string cherryExt = ".chy";
        private const string midiCsvExt = ".csv";
        private const string cakewalkExt = ".wrk";
        private const string mabinogiMMLExt = ".mmml";

        #endregion

        #region プロパティ
        /// <summary>
        /// MIDIDataオブジェクトのポインタ
        /// </summary>
        private IntPtr MIDIDataInstance { get; set; }

        #endregion

        #region 静的メソッド
        /// <summary>
        /// MIDIDataライブラリのテキストエンコーダで用いるデフォルトの文字コードを設定する。
        /// </summary>
        /// <param name="charCode"></param>
        public static void SetDefaultCharCode(CharCode charCode)
        {
            int err = MIDIDataLib_SetDefaultCharCode((int)charCode);
            if (err == 0)
            {
                throw new MIDIDataLibException("デフォルト文字コードの設定に失敗しました。");
            }
        }

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

            if (File.Exists(fileName))
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

            if (File.Exists(fileName))
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

            if (File.Exists(fileName))
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

            if (File.Exists(fileName))
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

            if (File.Exists(fileName))
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

            if (File.Exists(fileName))
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

        /// <summary>
        /// MIDIデータのポインタを指定して、オブジェクトを初期化します。
        /// </summary>
        /// <param name="midiData">MIDIデータのポインタ</param>
        private MIDIData(IntPtr midiData)
        {
            MIDIDataInstance = midiData;
        }

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
                throw new FileNotFoundException(null, nameof(fileName));
            }

            //拡張子取得
            string extension = Path.GetExtension(fileName);

            //拡張子に応じて分岐
            switch (extension)
            {
                case midiExt:
                    MIDIDataInstance = MIDIData_LoadFromSMF(fileName);
                    break;

                case skjExt:
                    MIDIDataInstance = MIDIData_LoadFromBinary(fileName);
                    break;

                case cherryExt:
                    MIDIDataInstance = MIDIData_LoadFromCherry(fileName);
                    break;

                case midiCsvExt:
                    MIDIDataInstance = MIDIData_LoadFromMIDICSV(fileName);
                    break;

                case cakewalkExt:
                    MIDIDataInstance = MIDIData_LoadFromWRK(fileName);
                    break;

                case mabinogiMMLExt:
                    MIDIDataInstance = MIDIData_LoadFromMabiMML(fileName);
                    break;
                
                default:
                    throw new ArgumentException("非対応の拡張子です。", nameof(fileName));
                    break;
            }

            if (MIDIDataInstance == IntPtr.Zero)
            {
                throw new MIDIDataLibException("ファイル読み込みに失敗しました。");
            }
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
