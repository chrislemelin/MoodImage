
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Button snap;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.Resizable = false;
		this.DefaultWidth = 300;
		this.DefaultHeight = 300;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.snap = new global::Gtk.Button();
		this.snap.WidthRequest = 150;
		this.snap.HeightRequest = 100;
		this.snap.CanFocus = true;
		this.snap.Name = "snap";
		this.snap.UseUnderline = true;
		this.snap.Label = global::Mono.Unix.Catalog.GetString("Snap");
		this.Add(this.snap);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.Show();
		this.snap.Clicked += new global::System.EventHandler(this.OnSnapClicked);
	}
}
