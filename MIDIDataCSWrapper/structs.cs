using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDIDataCSWrapper
{
	/// <summary>
	/// 小節：拍：ティックを表します
	/// </summary>
	public struct MeasureBeatTick
	{
		/// <summary>
		/// 小節：拍：ティックを指定して、オブジェクトの初期化をします。
		/// </summary>
		/// <param name="measure">小節</param>
		/// <param name="beat">拍</param>
		/// <param name="tick">ティック</param>
		public MeasureBeatTick(int measure, int beat, int tick) : this()
		{
			Measure = measure;
			Beat = beat;
			Tick = tick;
		}
		/// <summary>
		/// 小節
		/// </summary>
		public int Measure { get; set; }
		/// <summary>
		/// 拍
		/// </summary>
		public int Beat { get; set; }
		/// <summary>
		/// ティック
		/// </summary>
		public int Tick { get; set; }
	}

	/// <summary>
	/// 拍子記号を表します。
	/// </summary>
	public struct TimeSignature
	{
		/// <summary>
		/// 具体的な数値を指定して、オブジェクトを初期化します。
		/// </summary>
		/// <param name="nn">拍子記号の分子</param>
		/// <param name="dd">拍子記号の分母の指数部分</param>
		/// <param name="cc">1拍あたりのMIDIクロック数</param>
		/// <param name="bb">1拍の長さを32分音符の数で表す</param>
		public TimeSignature(int nn, int dd, int cc, int bb) : this()
		{
			this.nn = nn;
			this.dd = dd;
			this.cc = cc;
			this.bb = bb;
		}

		/// <summary>
		/// 拍子記号の分子
		/// </summary>
		public int nn { get; set; }
		/// <summary>
		/// 拍子記号の分母の指数部分
		/// </summary>
		public int dd { get; set; }
		/// <summary>
		/// 1拍あたりのMIDIクロック数
		/// </summary>
		public int cc { get; set; }
		/// <summary>
		/// 1拍の長さを32分音符の数で表す
		/// </summary>
		public int bb { get; set; }
	}
}
