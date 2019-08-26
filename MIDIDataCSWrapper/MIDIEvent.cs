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

		#endregion

		#region プロパティ
		internal IntPtr UnManagedObjectPointer { get; private set; }
		#endregion

	}
}
