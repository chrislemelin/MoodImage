using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using Gdk;
namespace MoodImage
{
	public partial class LiveMoodWindow : Gtk.Window
	{
		private DateTime lowest;

		private DateTime highest;
		private OxyPlot.GtkSharp.PlotView plotView;
		private LineSeries anger;
		private LineSeries happiness;
		private LineSeries neutral;
		private LineSeries contempt;
		private LineSeries disgust;
		private LineSeries surprise;
		private LineSeries fear;
		private LineSeries sadness;

		private LinearAxis xAxis;
		private DateTimeAxis dateAxis;

		private PlotModel plottingModel;
		int counter = 1;


		public LiveMoodWindow() :base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			lowest = DateTime.Now;
			highest = DateTime.Now.AddMinutes(10);

			Console.WriteLine(lowest + "" + highest);

			plottingModel = new PlotModel
			{
				Title = "Trigonometric functions",
				Subtitle = "Example using the FunctionSeries",
				PlotType = PlotType.Cartesian,
				Background = OxyColors.White,
		
			};

			plottingModel.Axes.Add(new LinearAxis { Title = "asdf", Position = AxisPosition.Left, AbsoluteMinimum = -.1, AbsoluteMaximum = 1.1 });


			plottingModel.Axes.Add(xAxis = new LinearAxis { Title = "Bot", Position = AxisPosition.Bottom, 
				Minimum = 0, Maximum = 10});




			plotView = new OxyPlot.GtkSharp.PlotView { Model = plottingModel, Visible = true };

			anger = new LineSeries();
			anger.Color = OxyColors.Red;
			plottingModel.Series.Add(anger);
			anger.Title = "Anger";

			happiness = new LineSeries();
			happiness.Color = OxyColors.Yellow;
			plottingModel.Series.Add(happiness);
			happiness.Title = "Happines";

			neutral = new LineSeries();
			neutral.Color = OxyColors.Gray;
			plottingModel.Series.Add(neutral);
			neutral.Title = "Neutral";

			contempt = new LineSeries();
			contempt.Color = OxyColors.Purple;
			plottingModel.Series.Add(contempt);
			contempt.Title = "Contempt";

			fear = new LineSeries();
			fear.Color = OxyColors.Black;
			plottingModel.Series.Add(fear);
			fear.Title = "Fear";

			surprise = new LineSeries();
			surprise.Color = OxyColors.DeepPink;
			plottingModel.Series.Add(surprise);
			surprise.Title = "Surprise";

			sadness = new LineSeries();
			sadness.Color = OxyColors.Blue;
			plottingModel.Series.Add(sadness);
			sadness.Title = "Sadness";

			disgust = new LineSeries();
			disgust.Color = OxyColors.Green;
			plottingModel.Series.Add(disgust);
			disgust.Title = "Disgust";




			alignment2.Add(plotView);

		}

		public void setImage(Pixbuf pixelBuf)
		{
			Plot.Pixbuf = pixelBuf;
		}

		public void addInfo(DateTime time, EmotionData data)
		{


			if (counter++ > 5)
			{
				xAxis.AbsoluteMaximum = counter + 4;
				xAxis.AbsoluteMinimum = counter - 6;
			}



			anger.Points.Add(new DataPoint(counter, data.Scores.Anger));
			happiness.Points.Add(new DataPoint(counter, data.Scores.Happiness));
			neutral.Points.Add(new DataPoint(counter, data.Scores.Neutral));
			disgust.Points.Add(new DataPoint(counter, data.Scores.Disgust));
			surprise.Points.Add(new DataPoint(counter, data.Scores.Surprise));
			contempt.Points.Add(new DataPoint(counter, data.Scores.Contempt));


			plottingModel.InvalidatePlot(true);
			plotView.InvalidatePlot(true);
			//anger.Points.Count();

			//this.Add(plotView);
			//alignment2.Remove(plotView);
			//alignment2.Add(plotView);

			Console.WriteLine(time + "__"+data.Scores.Happiness);

			//this.Add(plotModel);






			/*
			Console.Out.WriteLine("time" + time + " data: " + data);
			NPlot.Bitmap.PlotSurface2D surface = new NPlot.Bitmap.PlotSurface2D(500, 500);

			surface.Clear();
			surface.Title = "Line Graph";
			surface.BackColor = System.Drawing.Color.White;

			List<DateTime> times = new List<DateTime>();
			times.Add(time);
			times.Add(time.AddSeconds(5));

			List<float> scores = new List<float>();
			scores.Add(data.Scores.Anger);


			plot.AbscissaData = times;
			plot.DataSource = scores;

			surface.Add(plot, NPlot.PlotSurface2D.XAxisPosition.Bottom,
				  NPlot.PlotSurface2D.YAxisPosition.Left);

			scores.Add(data.Scores.Anger + .1f);

			surface.Add(plot, NPlot.PlotSurface2D.XAxisPosition.Bottom,
			  NPlot.PlotSurface2D.YAxisPosition.Left);

			surface.XAxis1.Label = "Time";
			surface.XAxis1.NumberFormat = "hh:mm:ss";

			surface.YAxis1.Label = "Emotion";
			surface.YAxis1.NumberFormat = "{0:####0.00}";
			surface.Refresh();





			MemoryStream memStream = new MemoryStream();
			surface.Bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
			byte[] byteArray = memStream.ToArray();



			Gdk.Pixbuf pixelBuf = new Gdk.Pixbuf(byteArray);
			Plot.Pixbuf = pixelBuf;
			*/

			}




	}
}
