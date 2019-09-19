// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

//using UtilitiesLibrary.Configuration;
	//using UtilitiesLibrary.Configuration.Data;
		
		
		namespace SQLServerScriptRunner
		{
			sealed class StartModule
			{
				
				private static string _userName;
		private static string _password;
		private static string _SQLServeName;
		private static string _DBname;
		private static string _scriptsFilePath;
		private static SortedList _scriptsFilePathList;
		
		private static SQLServerScripting.SQLScriptRunner _SQLServerScriptsRunner;
		
		static public void Main(string[] args)
		{
			try
			{
				if (args.Length <= 0)
				{
					Console.WriteLine("No parameters specified!");
					showParametersUsageHelp();
					return;
				}
				//PARAMETERS FORMAT
				if (args.Length < 2 | args.Length > 5)
				{
					Console.WriteLine("Wrong number of Parameters");
					showParametersUsageHelp();
					return;
				}
				switch (args.Length)
				{
					case 5: //_SQLServeName
						//load the scripts from the location specified in _scriptsFilePath
						_SQLServeName = args[0];
						_DBname = args[1];
						_userName = args[2];
						_password = args[3];
						_scriptsFilePath = args[4];
						_scriptsFilePathList = GetScriptFiles(_scriptsFilePath);
						break;
					case 4:
						//load the scripts from the current location
						_SQLServeName = args[0];
						_DBname = args[1];
						_userName = args[2];
						_password = args[3];
						_scriptsFilePathList = GetScriptFiles();
						break;
					case 3:
						//load the scripts from the location specified in _scriptsFilePath
						//and looks for user ans passworf from a configuration file
						_SQLServeName = args[0];
						_DBname = args[1];
						_scriptsFilePath = args[4];
						GetUserNameAndPasswordFromConfigurationFile();
						_scriptsFilePathList = GetScriptFiles(_scriptsFilePath);
						break;
					case 2:
						//load the scripts from the current location
						//and looks for user and password in a configuratio file
						_SQLServeName = args[0];
						_DBname = args[1];
						GetUserNameAndPasswordFromConfigurationFile();
						_scriptsFilePathList = GetScriptFiles();
						break;
				}
				_SQLServerScriptsRunner = new SQLServerScripting.SQLScriptRunner(_SQLServeName, _DBname, _userName, _password, _scriptsFilePathList);
				Console.WriteLine("Running Scripts, please wait . . . ");
				_SQLServerScriptsRunner.Run();
				Console.WriteLine("Running Scripts finish!");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
		}
		
		private static void showParametersUsageHelp()
		{
			Console.WriteLine();
			Console.WriteLine("___________________________________________________");
			Console.WriteLine("USAGE Parameter list reference");
			Console.WriteLine("usage mode 1");
			Console.WriteLine("     1. SQLServer Name");
			Console.WriteLine("     2. DataBase Name");
			Console.WriteLine("     3. User");
			Console.WriteLine("     4. Password");
			Console.WriteLine("     5. SQL Scripts file path");
			Console.WriteLine();
			Console.WriteLine("usage mode 2");
			Console.WriteLine("     1. SQLServer Name");
			Console.WriteLine("     2. DataBase Name");
			Console.WriteLine("     3. User");
			Console.WriteLine("     4. Password");
			Console.WriteLine();
			Console.WriteLine("usage mode 3");
			Console.WriteLine("     1. SQLServer Name");
			Console.WriteLine("     2. DataBase Name");
			Console.WriteLine("     5. SQL Scripts file path");
			Console.WriteLine();
			Console.WriteLine("usage mode 4");
			Console.WriteLine("     1. SQLServer Name");
			Console.WriteLine("     2. DataBase Name");
		}
		
		private static void GetUserNameAndPasswordFromConfigurationFile()
		{
			ConfigurationFileHandler configfileHndlr = default(ConfigurationFileHandler);
			configfileHndlr = ConfigurationFileHandlerProxyServer.GetInstance.GetFileHandler;
			KeyValue key = default(KeyValue);
			key = (KeyValue) (configfileHndlr.GetValue("UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/USER"));
			if (!(key == null))
			{
				_userName = System.Convert.ToString(key.Value);
			}
			else
			{
				throw (new Exception("No configuration found on UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/USER"));
			}
			
			key = (KeyValue) (configfileHndlr.GetValue("UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/PASSWORD"));
			if (!(key == null))
			{
				_password = System.Convert.ToString(key.Value);
			}
			else
			{
				throw (new Exception("No configuration found on UTILITIES_FRAMEWORK/SQLSERVER_SCRIPT_RUNNER/PASSWORD"));
			}
		}
		
		private static SortedList GetScriptFiles()
		{
			string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
			return GetScriptFiles(currentPath);
		}
		
		private static SortedList GetScriptFiles(string PathName)
		{
			try
			{
				
				System.IO.DirectoryInfo dir = default(System.IO.DirectoryInfo);
				
				if (!System.IO.Directory.Exists(PathName))
				{
					throw (new Exception("The directory don\'t exists : " + PathName));
				}
				else
				{
					dir = new System.IO.DirectoryInfo(PathName);
					
					SortedList _fileList = new SortedList();
					
					foreach (System.IO.FileInfo fInfo in dir.GetFiles("*.sql"))
					{
						_fileList.Add(fInfo.Name, fInfo.FullName);
					}
					
					return _fileList;
				}
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
	}
	
}
