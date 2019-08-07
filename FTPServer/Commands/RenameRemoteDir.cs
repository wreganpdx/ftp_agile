using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

/*RenameDIr

BH:Attempting to rename a non existing directory should return the appropriate prompt:
BH: Attempting ro rename an existing directory to another existing directory should return the appropriate prompt:
BH: Attempting to rename an existing directory to a non existing directory should be successful:
BH: Attempting to use invalid characters in either of the two directory names should elicit an error and the appropriate prompt response: BH
BH: Renaming an existing directory to a currently non existing directory is succesfull.
BH: Possible exceptions are handled  gracefullly: Pass
 */
namespace FTPServer.Commands
{
    //This module uploads local files to an ftp server through the putFile function.
    class RenameRemoteDir
    {
        public static void renameDir(FtpClient client)
        {
            string tryagain = "t"; //This is a while loop flag.
            string remoteDirName = null; //This specifies location on server we want t rename.
            string remoteDirNewName = null; // This specifies the name of the directory.
            Console.WriteLine("Rename Remote Directory Utility");

            while (tryagain == "t") // We give the user the option to try as many times as they'd like to get directory name in case of errors.
            {
                Console.Write("Enter the absolute path of the remote Directory to rename and press enter: ");
                remoteDirName = Console.ReadLine(); //get directory to rename location

                if (remoteDirName != "" & client.DirectoryExists(remoteDirName)) // Exit this while loop if directory is found and move to next step of renaming utility.
                {
                    tryagain = "q";
                }
                else //Give user msg that directory is not found and offer them a chance to quit the prompt or try again.
                {
                    remoteDirName = null;
                    Console.Write("Remote dir not found. Enter t to try again or q to quit: ");
                    tryagain = Console.ReadLine();
                }
            }

            if (remoteDirName == null) //If remote dir is null, then user has elected to quit the operation at this point.
            {
                Console.Write("Rename Remote Directory operation aborted. Bye!");
                return; //Early exit from function since user decide to quit.
            }
            else
                tryagain = "t"; // reset the while loop flag for the next phase of the rename function.

            //This while loop gets the new directory  name to rename directory to.
            while (tryagain == "t")
            {
                Console.Write("Enter the new name of the directory and press enter: ");
                remoteDirNewName = Console.ReadLine();
                string parentDir = FluentFTP.FtpExtensions.GetFtpDirectoryName(remoteDirName);
          
                    try
                    {
                       

                        
                        if ( !client.DirectoryExists(parentDir + "//" + remoteDirNewName) && client.MoveDirectory(remoteDirName, parentDir + "//" + remoteDirNewName))//if upload success
                        {
                            Console.Write("Operation completed.\n");
                            return; //exit the function
                        }
                        else
                        {
                          Console.WriteLine(Environment.NewLine + "An error occurred. Make sure there's no typos, and that you're not trying to move the directory to an existing location.\n");
                          Console.Write("Would you like to try another location. Press t to try again or any other key to quit:");
                          Console.WriteLine();
                          tryagain = Console.ReadLine();
                        }
                    }
                    catch (Exception e) //If an exception occurs, then alert user and give them the option to try again or quit.
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        Console.Write("Would you like to try another location. Press t to try again or any other key to quit:");
                        tryagain = Console.ReadLine();
                        Console.WriteLine();

                    }
                }
            }


        }
    }
