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
		//Image snap;
		public Gdk.Pixbuf pixelBuf;
		public EventWaitHandle waitHandle = new AutoResetEvent(false);

		public List<EmotionData> data;
		public DateTime timeStamp;

		public Snapper()
		{
	
		}

		public void requestPic()
		{

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Resources.URL);
			request.Headers.Add("Ocp-Apim-Subscription-Key", Resources.APIKEY);
			request.ContentType = "application/octet-stream";

			request.Method = "POST";
			request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
		}

		private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
		{
			System.Drawing.Image screen = Pranas.ScreenshotCapture.TakeScreenshot(true);
			timeStamp = DateTime.Now;
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
			DataParser parser = new DataParser();
			List<EmotionData> faceData = parser.parse(s);

	
			this.data = faceData;
			waitHandle.Set();
		}
	}
}
