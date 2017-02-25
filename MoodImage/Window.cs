﻿using System;
using Gdk;
namespace MoodImage
{
	public partial class Window : Gtk.Window
	{		
		public Window() :base(Gtk.WindowType.Toplevel)
		{
			Build();
		}
		public void setInfo(String s)
		{
			info.Buffer.Text = s;
		}

		public void setImage(Pixbuf pixelBuf)
		{
			displayImage.Pixbuf = pixelBuf;

		}
	}
}
