using System;
using System.Text;
namespace MoodImage
{
	public class FaceRectangle
	{
		public String Left { get; set; }
		public String Top { get; set; }
		public String Width { get; set; }
		public String Height { get; set; }

		public FaceRectangle()
		{
		}

		public String toString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("Left: " + Left + "\n");
			builder.Append("Top: " + Top + "\n");
			builder.Append("Width: " + Width + "\n");
			builder.Append("Height: " + Height + "\n");
			return builder.ToString();
		}
	}

}
