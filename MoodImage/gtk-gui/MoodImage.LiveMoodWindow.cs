
// This file has been generated by the GUI designer. Do not modify.
namespace MoodImage
{
	public partial class LiveMoodWindow
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Image Plot;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget MoodImage.LiveMoodWindow
			this.Name = "MoodImage.LiveMoodWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("LiveMoodWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MoodImage.LiveMoodWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.Plot = new global::Gtk.Image();
			this.Plot.Name = "Plot";
			this.vbox1.Add(this.Plot);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.Plot]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
