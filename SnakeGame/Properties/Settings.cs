using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace SnakeGame.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static SnakeGame.Properties.Settings defaultInstance;

		public static SnakeGame.Properties.Settings Default
		{
			get
			{
				return SnakeGame.Properties.Settings.defaultInstance;
			}
		}

		static Settings()
		{
			SnakeGame.Properties.Settings.defaultInstance = (SnakeGame.Properties.Settings)SettingsBase.Synchronized(new SnakeGame.Properties.Settings());
		}

		public Settings()
		{
		}
	}
}