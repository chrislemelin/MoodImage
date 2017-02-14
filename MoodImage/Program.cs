using System;
using Gtk;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MoodImage
{
class MainClass
	{
		static System.Drawing.Image screen; 

		public static void Main(string[] args)
		{
			/*
			screen = Pranas.ScreenshotCapture.TakeScreenshot(true);
			screen.Save("PrimaryDisplay.png");
			byte[] map;
			using (var ms = new MemoryStream())
			{
				screen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				map = ms.ToArray();
			}
			*/


			Task.Run(() => MainAsync());

			Console.ReadLine();
			Gtk.Application.Init();
			MainWindow win = new MainWindow();
			win.Show();
			Gtk.Application.Run();





		}

		static async Task MainAsync()
		{
			System.Threading.Thread.Sleep(3000);
			Console.WriteLine("starting");
			screen = Pranas.ScreenshotCapture.TakeScreenshot(true);

			byte[] map;
			using (var ms = new MemoryStream())
			{
				screen.Save(ms, screen.RawFormat);
				map = ms.ToArray();
			}

			Console.WriteLine(System.Text.Encoding.Default.GetString(map));
			WebRequest request = WebRequest.Create("https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize");
			// Set the Method property of the request to POST.
			request.Method = "POST";
			request.Headers.Add("Ocp-Apim-Subscription-Key", "89b424d4445548eead8652bcc0f15ef2");
			// Create POST data and convert it to a byte array.

			byte[] byteArray = map;
			// Set the ContentType property of the WebRequest.
			request.ContentType = "application/octet-stream";
			// Set the ContentLength property of the WebRequest.
			request.ContentLength = byteArray.Length;
			// Get the request stream.
			Stream dataStream = request.GetRequestStream();
			// Write the data to the request stream.
			dataStream.Write(byteArray, 0, byteArray.Length);
			// Close the Stream object.
			dataStream.Close();
			// Get the response.
			WebResponse response = request.GetResponse();
			// Display the status.
			Console.WriteLine(((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader(dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();
			// Display the content.
			Console.WriteLine(responseFromServer);
			// Clean up the streams.
			reader.Close();
			dataStream.Close();
			response.Close();


			/*
			var client = new HttpClient();
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "89b424d4445548eead8652bcc0f15ef2");
			//client.DefaultRequestHeaders.Remove("Content-Type");
			//client.DefaultRequestHeaders.Accept.Add(
			//	   new MediaTypeWithQualityHeaderValue("application/octet-stream"));
			

			//client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type","application/octet-stream");



			//string json = JsonConvert.SerializeObject(product);
			//String url = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";
			String url = "http://requestb.in/1cmsa0v1";


			var response = await client.PostAsync(url, new StringContent(System.Text.Encoding.Unicode.GetString(map),null,"application/octet-stream"));
			//var response = await client.PostAsync(url, new StringContent("{ \"url\": \"http://www.uni-regensburg.de/Fakultaeten/phil_Fak_II/Psychologie/Psy_II/beautycheck/english/durchschnittsgesichter/m(01-32)_gr.jpg\" }", Encoding.UTF8, "application/json"));
			var contents = await response.Content.ReadAsStringAsync();
			Console.WriteLine(response.StatusCode);
			Console.WriteLine(contents);
			*/


		}
	}
}
