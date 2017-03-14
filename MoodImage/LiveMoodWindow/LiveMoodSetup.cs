using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Gtk;
namespace MoodImage
{
	public class LiveMoodSetup
	{
		public Boolean go = true;
		private LiveMoodWindow w;
		private Thread tr;

		public LiveMoodSetup()
		{
			w = new LiveMoodWindow();
			w.DeleteEvent += delete_event;

		}

		public void Start()
		{

			tr = new Thread(() => run());
			tr.IsBackground = true;
			tr.Start();

		}

		public void run()
		{
			while (true)
			{

				System.Threading.Thread.Sleep(5000);
				Console.WriteLine("snap");
				snap();
			}
		}

		public void snap()
		{
			Snapper snap = new Snapper();

			Thread tr = new Thread(new ThreadStart(snap.requestPic));
			tr.IsBackground = true;
			tr.Start();


			var t = new Thread(() => makeSnapWindow(snap, w));
			t.IsBackground = true;
			t.Start();


		}

		private void makeSnapWindow(Snapper snap, LiveMoodWindow w)
		{
			snap.waitHandle.WaitOne();
			snap.waitHandle.Reset();

			List<EmotionData> data = snap.data;

			if(data.Count > 0)
				w.addInfo(snap.timeStamp, data[0]);
			w.setImage(snap.pixelBuf);
			 
			w.Show();
		}

		private void delete_event(object obj, DeleteEventArgs args)
		{
			tr.Abort();
		}
	}
}
