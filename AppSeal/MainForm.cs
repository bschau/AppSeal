using AppSeal.DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AppSeal
{
	public partial class MainForm : Form
	{
		readonly State _state = State.Load();
		readonly AppSealConfig _appSealConfig;

		public MainForm(AppSealConfig appSealConfig, string filename)
		{
			_appSealConfig = appSealConfig;
			InitializeComponent();
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			Text = string.Format("AppSeal {0}", version);

			AddProfiles();

			var index = CbProfile.FindString(_state.DefaultProfileName);
			CbProfile.SelectedIndex = index < 0 ? 0 : index;

			TbSignTool.Text = appSealConfig.SignTool;

			if (string.IsNullOrWhiteSpace(filename))
			{
				return;
			}

			TbFilename.Text = filename;
		}

		void AddProfiles()
		{
			foreach (var sealProfile in _appSealConfig.SealProfiles)
			{
				CbProfile.Items.Add(sealProfile);
			}
		}

		void BtnBrowse_Click(object sender, EventArgs e)
		{
			var file = PickFile();
			if (string.IsNullOrWhiteSpace(file))
			{
				return;
			}

			TbFilename.Text = file;
		}

		string PickFile()
		{
			using (var ofd = new OpenFileDialog
			{
				Filter = "Exe files|*.exe",
			})
			{
				if (!string.IsNullOrWhiteSpace(_state.DefaultFolder))
				{
					ofd.InitialDirectory = _state.DefaultFolder;
				}

				if (ofd.ShowDialog() != DialogResult.OK)
				{
					return string.Empty;
				}

				var file = ofd.FileName;
				_state.DefaultFolder = Path.GetDirectoryName(file);
				return file;
			}
		}

		void BtnSeal_Click(object sender, EventArgs e)
		{
			var file = TbFilename.Text;
			if (string.IsNullOrWhiteSpace(file))
			{
				return;
			}

			Seal(file.Trim());
		}

		void Seal(string file)
		{
			var profile = (SealProfile) CbProfile.Items[CbProfile.SelectedIndex];
			_state.DefaultProfileName = profile.Name;
			State.Save(_state);

			var builder = new StringBuilder();
			builder.AppendLine("@echo off");
			builder.AppendFormat(@"""{0}"" sign -a", _appSealConfig.SignTool);
			builder.AppendFormat(" -sha1 {0}", profile.Thumbprint);
			builder.AppendFormat(" -tr {0}", profile.TimeStampUrl);
			builder.AppendFormat(" -td {0}", profile.TimeStampHash);
			builder.AppendFormat(@" -d ""{0}""", profile.Description);
			builder.AppendFormat(" -du {0}", profile.DescriptionUrl);
			builder.AppendFormat(@" -v ""{0}""", file);
			builder.AppendLine();
			builder.AppendLine("pause");

			var tmpFile = string.Empty;
			try
			{
				tmpFile = Path.Combine(Path.GetTempPath(), string.Format("appseal-{0}.bat", Guid.NewGuid()));
				File.WriteAllText(tmpFile, builder.ToString());
				var processStartInfo = new ProcessStartInfo("cmd.exe", string.Format(@"/c ""{0}""", tmpFile));
				var process = Process.Start(processStartInfo);
				process.WaitForExit();
			}
			finally
			{
				if (!string.IsNullOrWhiteSpace(tmpFile))
				{
					File.Delete(tmpFile);
				}
			}
		}
	}
}
