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
        private static string checkLocalFile()
        {
            string filePathLocal = null;
            string retVal = null;
            string cont ="t";

              while(cont == "t")
            {
                Console.Write("Enter the path of the local file and press enter: ");

                filePathLocal = Console.ReadLine();

                if(File.Exists(filePathLocal))
                 {
                    cont = "q";
                    retVal = filePathLocal;
                 }
                else
                 {
                    Console.WriteLine("File not found. Press t to try again or any other character to quit: ");
                    cont = Console.ReadLine();
                 }
            }

            return retVal;
        }

        private static string checkRemoteDirectory(FtpClient client)
        {
            string DirPathRemote = null;
            string retVal = null;
            string cont = "t";
              while(cont == "t")
              {
                Console.Write("Enter the path of the remote directory and press enter: ");

                DirPathRemote = Console.ReadLine();

                if(client.DirectoryExists(DirPathRemote))
                 {
                    cont = "q";
                    retVal = DirPathRemote;
                 }
                else
                 {
                    Console.WriteLine("Remote directory not found. Press t to try again or any other character to quit: ");
                    cont = Console.ReadLine();
                 }
               }

              return retVal;
            }
            
        //uploadFile is used to upload files from local to remote.
        public static void uploadFile(FtpClient client)
        {
            string directoryPathRemote = null;
            string filePathLocal = null;
    
            filePathLocal = UploadModule.checkLocalFile(); //file location on local machine
            
            if(filePathLocal != null)
                directoryPathRemote = UploadModule.checkRemoteDirectory(client); //location to write the local file to
            
            if(filePathLocal != null && directoryPathRemote != null)
                client.UploadFile(filePathLocal,directoryPathRemote);
            else
                Console.WriteLine(Environment.NewLine + "Upload operation not completed!" + Environment.NewLine);
        }


        public static void makeDir(FtpClient client)
        {

            string newDirectoryRemote = null;
            char cont = 't';

            while(cont == 't')
            {     
                Console.WriteLine("");
                Console.WriteLine("Enter directory to add and press enter: ");
                newDirectoryRemote = Console.ReadLine();
                Console.WriteLine("");

             if (newDirectoryRemote == "")
            {
                Console.WriteLine("Enter a name, please! Isn't that what you are here for?");
                Console.WriteLine("Type t to try again or any other character to quit and press enter: ");
                cont = Console.ReadKey().KeyChar;
            }
            else if (newDirectoryRemote.IndexOfAny("<>:\"/\\|?*".ToCharArray()) != -1)
            {
                Console.WriteLine("No forbidden character!");
                Console.WriteLine("________________________");
                Console.WriteLine("Type t to try again or any other character to quit and press enter: ");
                cont = Console.ReadKey().KeyChar;
            }
            else if (newDirectoryRemote.EndsWith("."))
            {
                Console.WriteLine("The last character in the name can't be \".\"!");
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Type t to try again or any other character to quit and press enter: ");
                cont = Console.ReadKey().KeyChar;
            }
            else
            {
                Console.WriteLine("Creating directory with the name " + newDirectoryRemote);
                Console.WriteLine("___________________________________________");
                client.CreateDirectory(newDirectoryRemote);
                cont = 'q';
            }
            
        }
      }
    }
  }


