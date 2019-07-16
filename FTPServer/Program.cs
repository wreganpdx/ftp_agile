using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using FTPServer.Commands;
using System.IO;


namespace FTPServer
{
    class DeleteModule
    {
        public static void deleteDir(FtpClient client)
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
    }

     class LogIn
    {
        public static void logIn(FtpClient client)
        {
            char continuePrompt = 'Y'; //This flag is used to exit the while loop below by being set to anything other than Y.
            string username = "";
            string password = "";
            string ip = "";

            Console.WriteLine("Al");
            while (continuePrompt == 'Y')
            {
                try
                {
                    Console.WriteLine("DEBUG MSG: Localhost IP is 127.0.0.1");
                    Console.Write("Enter the I.P to connect to and press enter: ");
                    ip = Console.ReadLine(); //read in ip

                    Console.WriteLine(Environment.NewLine + "Leaving username and password field empty attempts to connect with anonymous account." + Environment.NewLine);

                    Console.Write("Enter the username field to connect with and press enter: ");
                    username = Console.ReadLine(); //read in username
                    Console.Write("Enter the password field to connect with and press enter: ");
                    password = Console.ReadLine(); //read in password

                    client = new FtpClient(ip); // create an FTP client using ip
                    client.Credentials = new System.Net.NetworkCredential(username, password); //Create credentials
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


     class LogOff
    {
        static public void logOff()
        {
            Console.Write("Are you sure you want to log off? Y/N \n");
            string ans = Console.ReadLine();
            if (ans.Equals("Y") || ans.Equals("y"))
            {
                Console.Write("Logging off");
            }
            else
            {
                Program.OptionPrompt();
            }
        }
    }

    class UploadModule
    {
        //This function is used to validate local file Paths and remote directories. It returns null if the local file path or remote directory is not found. Otherwise, it returns the absolute path of the resource.
        private static string getAndCheckLocalRemotePath(bool local, FtpClient client) //Pass true in for local or false in remote checks
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

                if ((local && File.Exists(resourcePath)) || (!local && client.DirectoryExists(resourcePath)))
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

        //uploadFile is used to upload files from local to remote.
        public static void uploadFile(FtpClient client)
        {
            string filePathLocal = null; //file location on local machine
            string directoryPathRemote = null; //location to write the local file to

            filePathLocal = getAndCheckLocalRemotePath(true,client);
            directoryPathRemote = getAndCheckLocalRemotePath(false,client);

            if (filePathLocal != null && directoryPathRemote != null)
            {
                client.UploadFile(filePathLocal, directoryPathRemote);
            }
            else
            {
                Console.WriteLine("Upload file operation has been cancelled by user.");
            }

        }


        public void makeDir(FtpClient client)
        {
            string parentDirectoryRemote = getAndCheckLocalRemotePath(false,client);

            if (parentDirectoryRemote != null)
            {
                client.CreateDirectory(parentDirectoryRemote);
            }


        }
    }

  
    class Program
    {
        static FtpClient client;

        public static void OptionPrompt()
        {
            string newAction;
            Console.Write("Please enter a command\n");
            Console.Write("1. Get file from remote server\n");
            Console.Write("2. Log off from remote server\n");
            Console.Write("3. Get multiple files\n");
            Console.Write("4. List directories and files on local machine\n");
            Console.Write("5. Delete directory on remote server\n");
            Console.Write("6. Create directory on remote server\n");
            Console.Write("7. Put file on remote server\n");



            newAction = Console.ReadLine(); //read in ip
            int action = Convert.ToInt32(newAction);

            switch (action)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    DeleteModule.deleteDir(client);
                    break;
                case 6:
                    break;
                case 7:
                    UploadModule.uploadFile(client);
                    break;
            }

        }
        static void Main(string[] args)
        {
           LogIn.logIn(client);
        }
    }
}
