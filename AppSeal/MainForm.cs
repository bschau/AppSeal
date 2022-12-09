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
		readonly AppSealConfig _appSealConfig;

		public MainForm(AppSealConfig appSealConfig, string filename)
		{
			_appSealConfig = appSealConfig;
			InitializeComponent();
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			Text = string.Format("AppSeal {0}", version);

			AddProfiles();
			CbProfile.SelectedIndex = 0;

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
				Filter = "Application Files (*.EXE,*.MSI)|*.exe;*.msi|All files (*.*)|*.*",
			})
			{
				if (ofd.ShowDialog() != DialogResult.OK)
				{
					return string.Empty;
				}

				return ofd.FileName;
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
