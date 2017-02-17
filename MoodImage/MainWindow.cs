using System;
using Gdk;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Threading;

using MoodImage;

public partial class MainWindow : Gtk.Window
{
	public Snapper snapper;
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		snapper = new Snapper();
	}



	protected void OnSnapClicked(object sender, EventArgs e)
	{
		snapper.requestPic();
	}
}
