using System;
using System.ComponentModel;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using Gma.System.MouseKeyHook.Implementation;


namespace MoodImage
{
	public class GlobalKeyboardListener
	{
		private Button b;
		private IKeyboardMouseEvents m_Events;

		public GlobalKeyboardListener()
		{
			
		}

		public void subcribe()
		{
			unSubscribe();
			sub(Hook.GlobalEvents());
		}


		private void sub(IKeyboardMouseEvents events)
		{
			m_Events = events;
			m_Events.KeyDown += OnKeyDown;
			m_Events.KeyUp += OnKeyUp;
			m_Events.KeyPress += HookManager_KeyPress;
		}

		public void unSubscribe()
		{
			
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			Console.WriteLine(string.Format("KeyDown  \t\t {0}\n", e.KeyCode));
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			Console.WriteLine("KeyUp  \t\t {0}\n", e.KeyCode);
		}

		private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
		{
			Console.WriteLine("KeyPress \t\t {0}\n", e.KeyChar);
		}
	}
}
