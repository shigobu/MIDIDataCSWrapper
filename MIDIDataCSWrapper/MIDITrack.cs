using System;
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
		#endregion

		#region プロパティ
		internal IntPtr UnManagedObjectPointer { get; private set; }
		#endregion

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
		#endregion

		#region ファイナライザー
		~MIDITrack()
		{
			Delete();
		}
		#endregion
	}
}
