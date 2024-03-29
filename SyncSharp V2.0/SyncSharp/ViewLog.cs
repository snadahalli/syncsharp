﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SyncSharp.Business;
using SyncSharp.Storage;
using System.IO;

namespace SyncSharp.GUI
{
    /// <summary>
    /// Written by Guo Jiayuan
    /// </summary>
	public partial class ViewLog : Form
	{
		#region Attributes
		private string _logFile; 
		#endregion

		#region Constructor
		public ViewLog(string taskName, string logFile)
		{
			InitializeComponent();
			this.Text = "[" + taskName + "]" + " log file";
			this._logFile = logFile;
		} 
		#endregion

		#region Methods
		private void ViewLog_Load(object sender, EventArgs e)
		{
			try
			{
                lblStatus.Text = Directory.GetCurrentDirectory().Substring(0,3) + "...\\" + _logFile.Substring(2);
                lblStatus.ToolTipText = lblStatus.Text;
				string logContents = Logger.ReadLog(_logFile);
				//txtLog.MaxLength = (logContents.Length > txtLog.MaxLength) ? logContents.Length : txtLog.MaxLength;
				txtLog.Text = (String.IsNullOrEmpty(logContents)) ? "Log file is empty" : logContents;
				txtLog.Select(0, 0);
			}
			catch
			{
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Delete the log file?", "Confirm",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Logger.DeleteLog(_logFile);
					txtLog.Clear();
                    lblStatus.Text = "";
                    this.Close();
				}
			}
			catch
			{
			}
		} 
		#endregion
	}
}