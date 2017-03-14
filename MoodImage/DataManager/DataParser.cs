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
 			return d;
		}

	}
}
