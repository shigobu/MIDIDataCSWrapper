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


}
