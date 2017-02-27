using System;
using Gtk;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Threading;


namespace MoodImage
{
class MainClass
	{

		public static void Main()
		{
			Application.Init();
			MainWindow win = new MainWindow();

			win.Show();
			win.DeleteEvent += delete_event;
			Application.Run();
			Application.Quit();

		}

		static void delete_event(object obj, DeleteEventArgs args)
		{
			Application.Quit();
		}

	}
}
