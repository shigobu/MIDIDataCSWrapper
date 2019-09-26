using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	/// <summary>
	/// ライブラリ全体の設定
	/// </summary>
	public static class MIDIDataLib
	{
		[DllImport("MIDIData.dll", CharSet = CharSet.Unicode)]
		private static extern int MIDIDataLib_SetDefaultCharCode(int lCharCode);

		/// <summary>
		/// MIDIDataライブラリのテキストエンコーダで用いるデフォルトの文字コードを設定する。
		/// </summary>
		/// <param name="charCode">文字コード</param>
		public static void SetDefaultCharCode(MIDIEvent.CharCodes charCode)
		{
			int err = MIDIDataLib_SetDefaultCharCode((int)charCode);
			if (err == 0)
			{
				throw new MIDIDataLibException("デフォルト文字コードの設定に失敗しました。");
			}
		}

		/// <summary>
		/// MIDIDataライブラリ内で使用する文字列バッファのサイズ。
		/// </summary>		
		internal const int BufferSize = 1024;

		internal const string MessageChannelOutOfRange = "チャンネル番号は0～15の範囲内である必要があります。";
		internal const string MessageKeyOutOfRange = "キー値は0～127の範囲内である必要があります。";

	}
}
