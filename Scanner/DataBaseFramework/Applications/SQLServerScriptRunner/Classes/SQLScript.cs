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

using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace SQLServerScriptRunner
{
	namespace SQLServerScripting
	{
		
		public class SQLScript
		{
			private System.Collections.Queue _scriptBatchContents;
			private string _filename;
			private string _filePathName;
			
			public SQLScript(string fileName)
			{
				try
				{
					//gets the filename
					FileInfo file = new FileInfo(fileName);
					this._filename = file.Name;
					this._filePathName = file.FullName;
					GetFileContents(this._filePathName);
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}
			
public Queue ScriptBatchContents
			{
				get
				{
					return this._scriptBatchContents;
				}
			}
			
public string FileName
			{
				get
				{
					return this._filename;
				}
			}
			
			private void GetFileContents(string fileName)
			{
				try
				{
					if (this._scriptBatchContents == null)
					{
						this._scriptBatchContents = new System.Collections.Queue();
					}
					
					StreamReader fileReader = new StreamReader(fileName);
					StringBuilder currentScript = new StringBuilder();
					string currentLine = "";
					Regex rexLn = new Regex("--", RegexOptions.Singleline);
					Regex rexGo = new Regex("^go$", RegexOptions.IgnoreCase);
					bool insertionFlag = false;
					
					currentLine = fileReader.ReadLine();
					
					while (!(currentLine == null))
					{
						if (!rexLn.Match(currentLine).Success)
						{
							if (rexGo.Match(currentLine).Success)
							{
								_scriptBatchContents.Enqueue(currentScript.ToString());
								insertionFlag = true;
								currentScript = new StringBuilder();
							}
							else
							{
								currentScript.Append(currentLine);
								currentScript.Append("\r\n");
							}
						}
						currentLine = fileReader.ReadLine();
					}
					
					if (!insertionFlag)
					{
						_scriptBatchContents.Enqueue(currentScript.ToString());
					}
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}
			
		}
	}
}
