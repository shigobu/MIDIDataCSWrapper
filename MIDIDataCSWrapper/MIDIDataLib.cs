using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	public class MIDIDataLib
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

		//文字列バッファのサイズ
		internal static int BufferSize { get; } = 256;

	}
}
