namespace AppSeal
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.CbProfile = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TbFilename = new System.Windows.Forms.TextBox();
			this.BtnBrowse = new System.Windows.Forms.Button();
			this.BtnSeal = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.TbSignTool = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Profile:";
			// 
			// CbProfile
			// 
			this.CbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbProfile.FormattingEnabled = true;
			this.CbProfile.Location = new System.Drawing.Point(109, 20);
			this.CbProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.CbProfile.Name = "CbProfile";
			this.CbProfile.Size = new System.Drawing.Size(519, 24);
			this.CbProfile.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 93);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Filename:";
			// 
			// TbFilename
			// 
			this.TbFilename.Location = new System.Drawing.Point(109, 90);
			this.TbFilename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TbFilename.Name = "TbFilename";
			this.TbFilename.Size = new System.Drawing.Size(411, 22);
			this.TbFilename.TabIndex = 3;
			// 
			// BtnBrowse
			// 
			this.BtnBrowse.Location = new System.Drawing.Point(528, 87);
			this.BtnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.BtnBrowse.Name = "BtnBrowse";
			this.BtnBrowse.Size = new System.Drawing.Size(100, 28);
			this.BtnBrowse.TabIndex = 4;
			this.BtnBrowse.Text = "Browse...";
			this.BtnBrowse.UseVisualStyleBackColor = true;
			this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
			// 
			// BtnSeal
			// 
			this.BtnSeal.Location = new System.Drawing.Point(273, 157);
			this.BtnSeal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.BtnSeal.Name = "BtnSeal";
			this.BtnSeal.Size = new System.Drawing.Size(100, 28);
			this.BtnSeal.TabIndex = 5;
			this.BtnSeal.Text = "Seal";
			this.BtnSeal.UseVisualStyleBackColor = true;
			this.BtnSeal.Click += new System.EventHandler(this.BtnSeal_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "SignTool:";
			// 
			// TbSignTool
			// 
			this.TbSignTool.Location = new System.Drawing.Point(109, 55);
			this.TbSignTool.Name = "TbSignTool";
			this.TbSignTool.ReadOnly = true;
			this.TbSignTool.Size = new System.Drawing.Size(519, 22);
			this.TbSignTool.TabIndex = 7;
			this.TbSignTool.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 208);
			this.Controls.Add(this.TbSignTool);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BtnSeal);
			this.Controls.Add(this.BtnBrowse);
			this.Controls.Add(this.TbFilename);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CbProfile);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox CbProfile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TbFilename;
		private System.Windows.Forms.Button BtnBrowse;
		private System.Windows.Forms.Button BtnSeal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TbSignTool;
	}
}

