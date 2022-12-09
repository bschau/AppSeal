using AppSeal.DomainModel;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace AppSeal
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			var appSealConfig = LoadConfig();
			if (appSealConfig == null)
			{
				return;
			}

			if (!VerifyConfig(appSealConfig))
			{
				return;
			}

			var argv = Environment.GetCommandLineArgs();
			var filename = string.Empty;
			if (argv.Length > 1)
			{
				if (File.Exists(argv[1]))
				{
					filename = argv[1];
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(appSealConfig, filename));
		}

		static AppSealConfig LoadConfig()
		{
			try
			{
				var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AppSeal.json");
				var text = File.ReadAllText(file);
				return JsonConvert.DeserializeObject<AppSealConfig>(text);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Failed to load the AppSeal.json configuration file.\r\nMake sure the file exists in your Documents folder\r\nand that it is readable by you.\r\n\r\n{ex.Message}", "Configuration Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		static bool VerifyConfig(AppSealConfig config)
		{
			if (string.IsNullOrWhiteSpace(config.SignTool))
			{
				MessageBox.Show("SignTool path is missing or empty in the AppSeal.json configuration file.", "SignTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (!File.Exists(config.SignTool))
			{
				MessageBox.Show("SignTool path is incorrect the AppSeal.json configuration file.", "SignTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
	}
}
