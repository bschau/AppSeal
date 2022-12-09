using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace AppSeal.DomainModel
{
	class State
	{
		public string DefaultProfileName { get; set; }
		public string DefaultFolder { get; set; }

		public static State Load()
		{
			try
			{
				var stateFilePath = GetStateFilePath();
				if (File.Exists(stateFilePath))
				{
					var json = File.ReadAllText(stateFilePath);
					return JsonConvert.DeserializeObject<State>(json);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return new State();
		}

		static string GetStateFilePath()
		{
			return string.Format(@"{0}\AppSeal.json", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
		}

		public static void Save(State state)
		{
			var settingsFilePath = GetStateFilePath();
			var json = JsonConvert.SerializeObject(state);
			File.WriteAllText(settingsFilePath, json);
		}
	}
}
