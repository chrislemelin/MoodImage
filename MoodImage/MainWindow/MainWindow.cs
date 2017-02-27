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
using System.Resources;

using MoodImage;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

	}

	protected void OnSnapShotButtonClicked(object sender, EventArgs e)
	{
		MoodWindowSetup setup = new MoodWindowSetup();
		setup.setUp();

	}


}
