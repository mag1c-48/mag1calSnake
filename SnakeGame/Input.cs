using System;
using System.Collections;
using System.Windows.Forms;

namespace SnakeGame
{
	internal class Input
	{
		private static Hashtable keyTable;

		static Input()
		{
			Input.keyTable = new Hashtable();
		}

		public Input()
		{
		}

		public static void changeState(Keys key, bool state)
		{
			Input.keyTable[key] = state;
		}

		public static bool KeyPress(Keys key)
		{
			bool flag;
			flag = (Input.keyTable[key] != null ? (bool)Input.keyTable[key] : false);
			return flag;
		}
	}
}