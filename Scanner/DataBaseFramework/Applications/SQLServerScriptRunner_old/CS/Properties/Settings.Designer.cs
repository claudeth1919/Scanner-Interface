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

using System.Threading;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace SQLServerScriptRunner
{
	namespace My
	{
		
		[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute(), 
		global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), 
		global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
		{
			
			private static Settings defaultInstance = (My.Settings) (global::System.Configuration.ApplicationSettingsBase.Synchronized(new My.Settings()));
			
#region My.Settings Auto-Save Functionality
#if _MyType
			private static bool addedHandler;
			
			private static object addedHandlerLockObject = new object();
			
			[global::System.Diagnostics.DebuggerNonUserCodeAttribute(), global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]private static void AutoSaveSettings(global::System.Object sender, global::System.EventArgs e)
			{
				if ((new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).SaveMySettingsOnExit)
				{
					My.Settings.Default.Save();
				}
			}
#endif
#endregion
			
public static Settings Default
			{
				get
				{
					
#if _MyType
					if (!addedHandler)
					{
						lock(addedHandlerLockObject)
						{
							if (!addedHandler)
							{
								(new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase).Shutdown += new System.EventHandler(AutoSaveSettings);
								addedHandler = true;
							}
						}
					}
#endif
					return defaultInstance;
				}
			}
		}
	}
	
	namespace My
	{
		
		[global::Microsoft.VisualBasic.HideModuleNameAttribute(), 
		global::System.Diagnostics.DebuggerNonUserCodeAttribute(), 
		global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]internal sealed class MySettingsProperty
		{
			
[global::System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]internal static global::SQLServerScriptRunner.My.Settings Settings
			{
				get
				{
					return global::SQLServerScriptRunner.My.Settings.Default;
				}
			}
		}
	}
	
}
