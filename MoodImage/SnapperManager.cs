using System;
namespace MoodImage
{
	public class SnapperManager
	{
		public SnapperManager()
		{
		}

		public void requestPic()
		{
			Snapper sp = new Snapper();
			sp.requestPic();
		}
	}
}
