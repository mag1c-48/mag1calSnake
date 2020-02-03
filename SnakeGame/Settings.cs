using System;
using System.Runtime.CompilerServices;

namespace SnakeGame
{
	internal class Settings
	{
		public static Directions direction
		{
			get;
			set;
		}

		public static bool GameOver
		{
			get;
			set;
		}

		public static int Height
		{
			get;
			set;
		}

		public static int HighScore
		{
			get;
			set;
		}

		public static int Points
		{
			get;
			set;
		}

		public static int Score
		{
			get;
			set;
		}

		public static int Speed
		{
			get;
			set;
		}

		public static int Width
		{
			get;
			set;
		}

		public Settings()
		{
			Settings.Width = 16;
			Settings.Height = 16;
			Settings.Speed = 20;
			Settings.Score = 0;
			Settings.HighScore = 0;
			Settings.Points = 100;
			Settings.GameOver = false;
			Settings.direction = Directions.Down;
		}
	}
}