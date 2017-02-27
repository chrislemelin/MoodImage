using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoodImage
{
	public class DataParser
	{
		
		public DataParser()
		{
		}

		public List<EmotionData> parse(String data)
		{
			List<EmotionData> d = JsonConvert.DeserializeObject<List<EmotionData>>(data);

			//Console.WriteLine("Face rect: "+d[0].FaceRectangle.top.ToString());
			//Console.WriteLine("Face rect: " + d[0].Scores.Anger.ToString());
			return d;
		}

	}
}
