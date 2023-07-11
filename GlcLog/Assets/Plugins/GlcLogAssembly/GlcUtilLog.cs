using System.IO;
using UnityEngine;
using System;
using System.Threading.Tasks;

namespace GlcLogAssembly
{
	public class GlcUtilLog
	{
		private static GlcUtilLog _instance = null;
		private const string LOG_FILE = "logfile";
		private string fileLog = "";
		private ulong sequence;
		private int enabled = 0;
		private object lockThis = new object();

		public static GlcUtilLog Instance
		{
			get
			{
				if (_instance is null)
				{
					_instance = new GlcUtilLog();
				}

				return _instance;
			}
		}

		// usage:
		// var logMessage = string.Format("{0}::{1}::", MethodBase.GetCurrentMethod().DeclaringType, MethodBase.GetCurrentMethod().Name);
		// HLogFile.Instance.Log(logMessage);
		public void LogMessage(string logString = "", string stackTrace = "", LogType type = LogType.Log)
		{
			lock (lockThis)
			{
				if (0 == enabled)
				{
					this.Enable();
				}

				using (TextWriter tw = new StreamWriter(fileLog, true))
				{
					//var cc = DateTime.Now, UnityEngine.Time.realtimeSinceStartup
					var logMessage = string.Format("++++++ {0,10} :: {1}", sequence, logString);
					tw.WriteLine(logMessage);
					tw.Close();
					//Debug.Log(logMessage);
					++sequence;
				}
			}
		}

		public void Enable()
		{
			if (0 < enabled)
				return;
			if (string.IsNullOrEmpty(fileLog))
			{
				var date = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
				var logfile = LOG_FILE + "_" + date + ".log";
				fileLog = Path.Combine(Application.persistentDataPath, logfile);
			}
			++enabled;
			Application.logMessageReceived += LogMessage;
		}

		public void Disable()
		{
			if (0 >= enabled)
				return;
			--enabled;
			Application.logMessageReceived -= LogMessage;
		}

		private GlcUtilLog()
		{
		}
	}
}
