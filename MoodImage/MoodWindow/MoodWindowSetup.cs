using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
namespace MoodImage
{
	public class MoodWindowSetup
	{
		public MoodWindowSetup()
		{
		}

		public void setUp()
		{
			Snapper snap = new Snapper();

			Thread tr = new Thread(new ThreadStart(snap.requestPic));
			tr.IsBackground = true;
			tr.Start();

			MoodImage.Window w = new MoodImage.Window();
			w.Hide();
			var t = new Thread(() => makeSnapWindow(snap, w));
			t.IsBackground = true;
			t.Start();
		}

		private void makeSnapWindow(Snapper snap, MoodImage.Window w)
		{
			snap.waitHandle.WaitOne();
			snap.waitHandle.Reset();

			List<EmotionData> data = snap.data;

			StringBuilder builder = new StringBuilder();
			for (int a = 0; a < data.Count; a++)
			{
				builder.Append(data[a].toString());
				builder.Append('\n');
			}
			if (data.Count > 0)
				w.setInfo(builder.ToString());
			else
			{
				w.setInfo("no faces found");
			}
			w.setImage(snap.pixelBuf);
			w.Show();
		}
	
	}
}
