using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


namespace FTPServer.Commands
{
        public static void deleteDir()
        {
            string directoryLocation;
            char promptContinue = 'T';

            while (promptContinue == 'T')
            {
                Console.Write("Enter the directory to delete on the server and press enter: ");
                directoryLocation = Console.ReadLine();

                if (client.DirectoryExists(directoryLocation))
                {
                    client.DeleteDirectory(directoryLocation);
                    promptContinue = 'F';
                }
                else
                {
                    Console.WriteLine("Directory does not exist on the server. Press T to try again, any other char to quit, and smash that enter key: ");
                    promptContinue = Char.ToUpper(Console.ReadKey().KeyChar);
                }
            }

        }

           //uploadFile is used to upload files from local to remote.

        //This function is used to validate local file Paths and remote directories. It returns null if the local file path or remote directory is not found. Otherwise, it returns the absolute path of the resource.
        public static string getAndCheckLocalRemotePath(bool local) //Pass true in for local or false in remote checks
        {
            char continuePrompt = 't';
            string retVal = null;
            
            
            string resourcePath = null;

            while (continuePrompt == 't') //This loop is used to present the request prompt more than once in case the user makes a mistake such as a file location typo.
            {

                if (local)
                    Console.Write("Enter the path of the local file and press enter Enter: ");
                else
                    Console.Write("Enter the path of the remote directory and press Enter: ");

                resourcePath = Console.ReadLine();

                if ( (local && File.Exists(resourcePath)) || (!local && client.DirectoryExists(resourcePath)))
                {
                    retVal = resourcePath;
                    continuePrompt = 'q';
                }
                else 
                {
                    Console.Write("Resource not found. Type t  to try again or q to quit  and press enter: ");
                    continuePrompt = Char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                }
            }

            return retVal;
        }
        public static void uploadFile()
        { 
            string filePathLocal = null; //file location on local machine
            string directoryPathRemote = null; //location to write the local file to

            filePathLocal = getAndCheckLocalRemotePath(true);
            directoryPathRemote = getAndCheckLocalRemotePath(false);

            if(filePathLocal != null && directoryPathRemote != null)
            {
                client.UploadFile(filePathLocal, directoryPathRemote);
            }
            else
            {
                Console.WriteLine("Upload file operation has been cancelled by user.");
            }
            
        }

        public static void makeDir()
        {
            string parentDirectoryRemote = getAndCheckLocalRemotePath(false);

            if(parentDirectoryRemote != null)
            {
                client.CreateDirectory(parentDirectoryRemote);
            }


        }

        public static void LogIn()
        {
            char continuePrompt = 'Y'; //This flag is used to exit the while loop below by being set to anything other than Y.

            while (continuePrompt == 'Y')
            {
                try
                {
                    Console.WriteLine("DEBUG MSG: Localhost IP is 127.0.0.1");
                    Console.Write("Enter the I.P to connect to and press enter: ");
                    Program.ip = Console.ReadLine(); //read in ip

                    Console.WriteLine(Environment.NewLine + "Leaving username and password field empty attempts to connect with anonymous account." + Environment.NewLine);

                    Console.Write("Enter the username field to connect with and press enter: ");
                    Program.username = Console.ReadLine(); //read in username
                    Console.Write("Enter the password field to connect with and press enter: ");
                    Program.password = Console.ReadLine(); //read in password

                    client = new FtpClient(Program.ip); // create an FTP client using ip
                    client.Credentials = new System.Net.NetworkCredential(Program.username, Program.password); //Create credentials
                    client.Connect(); //Connect to client

                    if (client.IsConnected) //If connect success
                    {
                        continuePrompt = 'N'; //Setting continuePrompt flag to N ensures we escape for loop.
                        Program.OptionPrompt(); //give option prompt
                        Console.WriteLine("FTP is connected");
                        Console.ReadLine();
                    }
                }
                catch (Exception connectionException)
                {
                    //print exception to console since we don't have a log file
                    Console.WriteLine(Environment.NewLine + connectionException.Message + Environment.NewLine);
                }
                finally //finally, we ask user if they'd like to try another log in attempt.
                {
                    Console.WriteLine("A connection exception has occurred. Would you like to try again? Type in Y to continue or N to exit.");
                    continuePrompt = Char.ToUpper(Console.ReadKey().KeyChar);
                }


            }
        }
}
