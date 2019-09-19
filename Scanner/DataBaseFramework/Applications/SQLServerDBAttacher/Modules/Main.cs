// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using System.IO;
using UtilitiesLibrary.Configuration;
using UtilitiesLibrary.Configuration.Data;
using System.Text;


namespace SQLServerDBAttacher
{
	sealed class Main
	{
		
		private static string mdfFilePathName;
		private static string ldfFilePathName;
		private static string DBName;
		private static string sqlServerName;
		private static string UserId;
		private static string password;
		private static string mode;
		
		private enum userDeattachResponse
		{
			yes,
			no
		}
		
		private enum userInteractionDeattachMode
		{
			userAck,
			noUserAck,
			undefinedAck
		}
		
		static public void Main_Renamed(string[] args)
		{
			if (args.Length <= 0)
			{
				Console.WriteLine("No parameters specified!");
				return;
			}
			//******************************************************************************
			mode = args[0];
			mode = mode.ToUpper();
			//******************************************************************************
			switch (mode)
			{
				case "/I":
					AttachDataBase(args);
					break;
				case "/U":
					DetachDataBase(args);
					break;
				case "/?":
					ShowModeHelp();
					showAttachParameterReference();
					showDetachParameterReference();
					break;
				default:
					Console.WriteLine();
					Console.WriteLine("Wrong parameters list!");
					Console.WriteLine("Not mode selected!");
					ShowModeHelp();
					return;
			}
			//******************************************************************************
			//PressEnterKey()
		}
		
        #region << DATABASE ATTACHMENT >>
		
		    private static void AttachDataBase(string[] args)
		    {
			    Console.WriteLine();
			    Console.WriteLine("DATABASE INSTALLATION");
			    switch (args.Length)
			    {
				    case 3:
					    //mode + PARAMETERS: MDF FileName , LDF Filename
					    mdfFilePathName = GetFileFullPathName(args[1]);
					    ldfFilePathName = GetFileFullPathName(args[2]);
					    //ask for data base name
					    Console.Write("Database name: ");
					    DBName = Console.ReadLine();
					    //ask for sql server name
					    Console.Write("Server name: ");
					    sqlServerName = Console.ReadLine();
					    //gets the user name and password from configuragion file if not exists ask for them
					    GetUserNameAndPasswordFromConfigurationFile();
					    //makes the attachement
					    MakeDBAttachment();
					    break;
				    case 4:
					    //mode +  PARAMETERS: MDF FileName , LDF Filename, DB name
					    mdfFilePathName = GetFileFullPathName(args[1]);
					    ldfFilePathName = GetFileFullPathName(args[2]);
					    DBName = args[3];
					    //ask for sql server name
					    Console.Write("Server name: ");
					    sqlServerName = Console.ReadLine();
					    //gets the user name and password from configuragion file
					    GetUserNameAndPasswordFromConfigurationFile();
					    //makes the attachement
					    MakeDBAttachment();
					    break;
				    case 5:
					    //mode +  PARAMETERS: MDF FileName , LDF Filename, DB name , SQL SERVER
					    mdfFilePathName = GetFileFullPathName(args[1]);
					    ldfFilePathName = GetFileFullPathName(args[2]);
					    DBName = args[3];
					    //ask for sql server name
					    sqlServerName = args[4];
					    //gets the user name and password from configuragion file
					    GetUserNameAndPasswordFromConfigurationFile();
					    //makes the attachement
					    MakeDBAttachment();
					    break;
				    case 7:
					    //mode +  PARAMETERS: MDF FileName , LDF Filename, DB name , SQL SERVER , USER AND PASSWORD
					    mdfFilePathName = GetFileFullPathName(args[1]);
					    ldfFilePathName = GetFileFullPathName(args[2]);
					    DBName = args[3];
					    sqlServerName = args[4];
					    UserId = args[5];
					    password = args[6];
					    MakeDBAttachment();
					    break;
				    default:
					    Console.WriteLine();
    Console.WriteLine("Error: Wrong parameters list!");
					    Console.WriteLine("");
					    showAttachParameterReference();
					    break;
			    }
		    }
		
		    private static void MakeDBAttachment()
		    {
			    //creates a db attacher instance
			    SQLServerDBAttacher dbatt = new SQLServerDBAttacher(sqlServerName, UserId, password);
			    //starts the DB attachment process
			    string msgStr;
			    msgStr = "Installing Data Base [" + DBName + "] on server [" + sqlServerName + "]";
			    Console.WriteLine();
			    Console.WriteLine("Installing database...");
			    try
			    {
				    if (ldfFilePathName.Length <= 0)
				    {
					    dbatt.Attach(DBName, mdfFilePathName);
				    }
				    else
				    {
					    dbatt.Attach(DBName, mdfFilePathName, ldfFilePathName);
				    }
				
				    Console.WriteLine("Database installed successfully.");
			    }
			    catch (Exception ex)
			    {
				    Console.WriteLine("ERROR : " + ex.Message);
			    }
			    finally
			    {
				    if (!(dbatt == null))
				    {
					    dbatt.Dispose();
				    }
			    }
		    }
		
    #endregion
		
        #region << DATABASE DETACHMENT>>
		
		    private static void DetachDataBase(string[] args)
		    {
			    string deattachMode = "";
			
			    Console.WriteLine();
			    Console.WriteLine("DATABASE UNINSTALL");
			    Console.WriteLine();
			    switch (args.Length)
			    {
				    case 2: //mode + akcMode
					    deattachMode = args[1];
					    userInteractionDeattachMode result_1 = ValidateDeattachUserMode(deattachMode);
					    switch (result_1)
					    {
						    case userInteractionDeattachMode.undefinedAck:
							    Console.WriteLine();
							    Console.WriteLine("Wrong parameters!");
							    showDetachParameterReference();
							    break;
						    default:
							    if (result_1 == userInteractionDeattachMode.undefinedAck)
							    {
								    Console.WriteLine();
								    Console.WriteLine("Wrong user deattachement mode!");
								    showDetachParameterReference();
							    }
							    else
							    {
								    //gets the server name
								    Console.Write("Server name: ");
								    sqlServerName = Console.ReadLine();
								    //gets the database name
								    Console.Write("DataBase Name : ");
								    DBName = Console.ReadLine();
								
								    //gets the user name and password from configuragion file
								    GetUserNameAndPasswordFromConfigurationFile();
								
								    if (result_1 == userInteractionDeattachMode.userAck)
								    {
									    if (GetUserDeAttachentAcknowledge() == userDeattachResponse.yes)
									    {
										    MakeDBDetach();
									    }
								    }
								    else
								    {
									    MakeDBDetach();
								    }
							    }
							    break;
					    }
					    break;
				    case 3: //mode + akcMode + server
					    deattachMode = args[1];
					    userInteractionDeattachMode result_2 = ValidateDeattachUserMode(deattachMode);
					    switch (result_2)
					    {
						    case userInteractionDeattachMode.undefinedAck:
							    Console.WriteLine();
							    Console.WriteLine("Wrong parameters!");
							    showDetachParameterReference();
							    break;
						    default:
							    sqlServerName = args[2];
							    //gets the database name
							    Console.Write("DataBase Name : ");
							    DBName = Console.ReadLine();
							
							    //gets the user name and password from configuragion file
							    GetUserNameAndPasswordFromConfigurationFile();
							
							    if (result_2 == userInteractionDeattachMode.userAck)
							    {
								    if (GetUserDeAttachentAcknowledge() == userDeattachResponse.yes)
								    {
									    MakeDBDetach();
								    }
							    }
							    else
							    {
								    MakeDBDetach();
							    }
							    break;
					    }
					    break;
				    case 4: //mode + akcMode + SERVER NAME  + dbname
					    deattachMode = args[1];
					    userInteractionDeattachMode result_3 = ValidateDeattachUserMode(deattachMode);
					    switch (result_3)
					    {
						    case userInteractionDeattachMode.undefinedAck:
							    Console.WriteLine();
							    Console.WriteLine("Wrong parameters!");
							    showDetachParameterReference();
							    break;
						    default:
							    sqlServerName = args[2];
							    DBName = args[3];
							
							    //gets the user name and password from configuragion file
							    GetUserNameAndPasswordFromConfigurationFile();
							
							    if (result_3 == userInteractionDeattachMode.userAck)
							    {
								    if (GetUserDeAttachentAcknowledge() == userDeattachResponse.yes)
								    {
									    MakeDBDetach();
								    }
							    }
							    else
							    {
								    MakeDBDetach();
							    }
							    break;
					    }
					    break;
				    case 6: //mode + akcMode + SERVER NAME  + dbname + user + password
					    deattachMode = args[1];
					    userInteractionDeattachMode result = ValidateDeattachUserMode(deattachMode);
					    switch (result)
					    {
						    case userInteractionDeattachMode.undefinedAck:
							    Console.WriteLine();
							    Console.WriteLine("Wrong parameters!");
							    showDetachParameterReference();
							    break;
						    default:
							    sqlServerName = args[2];
							    DBName = args[3];
							    UserId = args[4];
							    password = args[5];
							    if (result == userInteractionDeattachMode.userAck)
							    {
								    if (GetUserDeAttachentAcknowledge() == userDeattachResponse.yes)
								    {
									    MakeDBDetach();
								    }
							    }
							    else
							    {
								    MakeDBDetach();
							    }
							    break;
					    }
					    break;
					
					
				    default:
					    Console.WriteLine();
					    Console.WriteLine("Wrong parameters list!");
					    showDetachParameterReference();
					    break;
			    }
			
		    }
		
		    private static void MakeDBDetach()
		    {
			    //creates a db attacher instance
			    SQLServerDBAttacher dbatt = new SQLServerDBAttacher(sqlServerName, UserId, password);
			    //starts the attach DB process
			    string msgStr = "";
			    msgStr = "Removing Data Base [" + DBName + "] from server [" + sqlServerName + "] . . . ";
			    Console.WriteLine();
			    Console.WriteLine(msgStr);
			    try
			    {
				    dbatt.Detach(DBName, true);
				    Console.WriteLine("Database removed succesfully.");
			    }
			    catch (Exception ex)
			    {
				    Console.WriteLine("ERROR : " + ex.Message);
			    }
			    finally
			    {
				    if (!(dbatt == null))
				    {
					    dbatt.Dispose();
				    }
			    }
		    }
		
		    private static userInteractionDeattachMode ValidateDeattachUserMode(string modeStr)
		    {
			    modeStr = modeStr.ToUpper();
			    switch (modeStr)
			    {
				    case "Y":
					    return userInteractionDeattachMode.userAck;
				    case "N":
					    return userInteractionDeattachMode.noUserAck;
				    default:
					    return userInteractionDeattachMode.undefinedAck;
			    }
		    }
		
		    private static userDeattachResponse GetUserDeAttachentAcknowledge()
		    {
			    int trialCounter = 0;
			    string userResponse;
			    bool exitWhile = false;
			
			    while (!exitWhile)
			    {
				    Console.WriteLine();
				    Console.WriteLine("Deattach Data Base :" + DBName + Constants.vbNewLine + "from SQL Server Host : " + sqlServerName + "?" + Constants.vbNewLine + "Type (yes | no) and press enter");
				    Console.WriteLine();
				    string input = Console.ReadLine();
				    input = input.ToUpper();
				    switch (input)
				    {
					    case "YES":
						    return userDeattachResponse.yes;
					    case "NO":
						    return userDeattachResponse.no;
				    }
			    }
			    return default(userDeattachResponse);
		    }
		
    #endregion

        #region < PRIVATE STATIC METHODS >


            private static void showAttachParameterReference()
            {
                Console.WriteLine();
                Console.WriteLine("___________________________________________________");
                Console.WriteLine("INSTALL Parameter list reference");
                Console.WriteLine("     1 \'/i\' = Install dataBase ");
                Console.WriteLine("     2. Database MDF File PathName");
                Console.WriteLine("     3. DataBase LDF File PathName");
                Console.WriteLine("     4. DataBase Name");
                Console.WriteLine("     5. SQL server name");
                Console.WriteLine("     5. User id ");
                Console.WriteLine("     7. user password");
                Console.WriteLine();
            }

            private static void showDetachParameterReference()
            {
                Console.WriteLine();
                Console.WriteLine("___________________________________________________");
                Console.WriteLine("UNINSTALL Parameter list reference");
                Console.WriteLine("      1. \'/u\' = Uninstall database ");
                Console.WriteLine("      2. User Acknowledge (y | n)");
                Console.WriteLine("      3. SQL server name");
                Console.WriteLine("      4. DataBase Name");
                Console.WriteLine("      5. User id");
                Console.WriteLine("      6. user password");
                Console.WriteLine();
            }

            private static void ShowModeHelp()
            {
                Console.WriteLine("First parameter should be:");
                Console.WriteLine("     \'/i\' = Install Database into SQLServer");
                Console.WriteLine("     \'/u\' = Uninstall Database into SQLServer");
            }

            private static void PressEnterKey()
            {
                Console.WriteLine();
                Console.WriteLine("Press <enter> to continue...");
                Console.Read();
            }

            private static void GetUserNameAndPasswordFromConfigurationFile()
            {
                try
                {
                    ConfigurationFileHandler configfileHndlr = default(ConfigurationFileHandler);
                    configfileHndlr = ConfigurationFileHandlerProxyServer.GetInstance().GetFileHandler();
                    KeyValue key = default(KeyValue);
                    key = (KeyValue)(configfileHndlr.GetValue("UTILITIES_FRAMEWORK/SQLSERVER_DB_ATTACHER/USER"));
                    if (!(key == null))
                    {
                        UserId = key.Value;
                    }
                    else
                    {
                        Console.Write("User Name : ");
                        UserId = Console.ReadLine();
                    }

                    key = (KeyValue)(configfileHndlr.GetValue("UTILITIES_FRAMEWORK/SQLSERVER_DB_ATTACHER/PASSWORD"));
                    if (!(key == null))
                    {
                        password = key.Value;
                    }
                    else
                    {
                        Console.Write("Password : ");
                        password = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.Write("User Name : ");
                    UserId = Console.ReadLine();
                    Console.Write("Password : ");
                    password = Console.ReadLine();
                }

            }

            private static string GetFileFullPathName(string FileName)
            {
                string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = "";
                if (baseDir[baseDir.Length - 1] != char.Parse("\\"))
                {
                    fullPath = baseDir + "\\" + FileName;
                }
                else
                {
                    fullPath = baseDir + FileName;
                }
                return fullPath;
            }

        #endregion 

       
		
	}
	
}
