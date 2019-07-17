using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


namespace FTPServer.Commands
{
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

            filePathLocal = getAndCheckLocalRemotePath(true, client);

            if(filePathLocal != null)
                directoryPathRemote = getAndCheckLocalRemotePath(false, client);

            if (directoryPathRemote != null)
            {
                try
                {
                    client.UploadFile(filePathLocal, directoryPathRemote);
                }
                catch(Exception e)
                {
                    Console.WriteLine(Environment.NewLine + e.Message + Environment.NewLine);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Upload file operation has been cancelled by user.");
            }

        }


        public static void makeDir(FtpClient client)
        {

            string parentDirectoryRemote = null;

            Console.WriteLine("Enter directory to add and press enter: ");
            parentDirectoryRemote = Console.ReadLine();

            if (parentDirectoryRemote != null)
            {
                client.CreateDirectory(parentDirectoryRemote);
            }
        }
    }
}
