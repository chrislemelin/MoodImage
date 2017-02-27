using System;
namespace MoodImage
{
	public partial class LiveMoodWindow : Gtk.Window
	{
		public LiveMoodWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
	}
}
