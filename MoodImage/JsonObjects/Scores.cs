using System;
using System.Text;
namespace MoodImage
{
	public class Scores
	{
		public float Anger { get; set; }
		public float Contempt { get; set; }
		public float Disgust { get; set; }
		public float Fear { get; set; }
		public float Happiness { get; set; }
		public float Neutral { get; set; }
		public float Sadness { get; set; }
		public float Surprise { get; set; }
	
		public Scores()
		{
		}

		public String toString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("Anger: " + Anger + "\n");
			builder.Append("Contempt: " + Contempt + "\n");
			builder.Append("Disgust: " + Disgust + "\n");
			builder.Append("Fear: " + Fear + "\n");
			builder.Append("Happiness: " + Happiness + "\n");
			builder.Append("Neutral: " + Neutral + "\n");
			builder.Append("Sadness: " + Sadness + "\n");
			builder.Append("Surprise: " + Surprise + "\n");
			return builder.ToString();

		}
	}
}
