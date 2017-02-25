using System;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Threading;
using Gtk;

using System.Resources;

namespace MoodImage
{
	public class Snapper
	{
		Window w;
		Image snap;
		Gdk.Pixbuf pixelBuf;

		public Snapper()
		{
	
		}

		public void requestPic()
		{
			w = new Window();
			w.Hide();

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Resources.URL);
			request.Headers.Add("Ocp-Apim-Subscription-Key", Resources.APIKEY);
			request.ContentType = "application/octet-stream";

			request.Method = "POST";
			request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
		}

		private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
		{
			System.Drawing.Image screen = Pranas.ScreenshotCapture.TakeScreenshot(true);
			byte[] byteArray;

			using (var ms = new MemoryStream())
			{
				screen.Save(ms, screen.RawFormat);
				byteArray = ms.ToArray();
				pixelBuf =  new Gdk.Pixbuf(byteArray,screen.Width/3,screen.Height/3);
			}

			HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

			// End the operation
			Stream postStream = request.EndGetRequestStream(asynchronousResult);

			postStream.Write(byteArray, 0, byteArray.Length);
			postStream.Close();

			// Start the asynchronous operation to get the response
			request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
		}

		private void GetResponseCallback(IAsyncResult asynchronousResult)
		{
			HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

			// End the operation
			HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
			Stream streamResponse = response.GetResponseStream();
			StreamReader streamRead = new StreamReader(streamResponse);
			string responseString = streamRead.ReadToEnd();
			Console.WriteLine(responseString);
			// Close the stream object
			streamResponse.Close();
			streamRead.Close();

			response.Close();

			parseData(responseString);

		}
		private void parseData(String s)
		{
			w.Show();
			DataParser parser = new DataParser();
			List<EmotionData> data = parser.parse(s);

			StringBuilder builder = new StringBuilder();
			for (int a = 0; a < data.Count; a++)
			{
				builder.Append(data[a].toString());
				builder.Append('\n');
			}
			if (data.Count > 0)
				w.setInfo(builder.ToString());
			else
			{
				w.setInfo("no faces found");
			}
		
			w.setImage(pixelBuf);
		}
	}
}
