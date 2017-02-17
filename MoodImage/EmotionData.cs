using System;
using Newtonsoft.Json.Serialization;

namespace MoodImage
{
	public class EmotionData
	{
		public EmotionData()
		{

		}

		public FaceRectangle FaceRectangle { get; set;}

		public Scores Scores { get; set; }

		public String toString()
		{
			return FaceRectangle.toString() + Scores.toString();
		}

	}
}
