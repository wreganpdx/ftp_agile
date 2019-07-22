using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


/* TESTS RAN
 * 
 * 
 * COPYFILE
BH:Copy an existing file to a valid directory that does not contain a file with the same name: Pass
BH:Copy an existing file to a valid directory that does contain a file with the same name.The prompt should ask the user to rename the file:Pass
BH:Attempt to copy a non existent file. Prompt should return file not found message and try again message:Pass
BH:Attempt to copy an existing file to a non-existent directory. Prompt should alert user that dir does not exist: Pass
BH:Attempt to put invalid characters in filename. Should get a try again prompt: Pass
BH:Attempt to put invalid chars in directory path. Should get try again prompt: Pass
BH:CopyFile correctly reports success and exit status: Pass
BH:Exceptions don't cause program crash: Pass
 * 
 */





namespace FTPServer.Commands
{
    class UploadModule
    {

        public static void copyFile()
        {
            string filepath = null;
            string directorypathtocopy = null;
            string filenamecopy = null;
            Console.WriteLine("To use the copyfile utility, you must have R/W to files and folders you wish to read and write to.");
         
            filepath = checkLocalFile();
           
            if(filepath != null)
            {
                Console.WriteLine("Directory To Copy To");
                directorypathtocopy = UploadModule.checkLocalDirectory();
            }
           
            if(directorypathtocopy != null)
              { 
                filenamecopy = UploadModule.checkFileName();
              }
            if(filenamecopy != null)
            {
                while(File.Exists(directorypathtocopy + filenamecopy))
                {
                    Console.WriteLine("A file exists in the specified location.Change the file name and try again.");
                    filenamecopy = UploadModule.checkFileName();
                }
            }
            try
            {
                if(filepath != null && directorypathtocopy!=null && filenamecopy != null)
                {
                    File.Copy(filepath, directorypathtocopy + filenamecopy);
                    Console.WriteLine("Copy operation completed!");

                }
                else
                {
                    Console.WriteLine("Copy operation not completed!");
                }
           }
          catch(Exception e)
          {
                Console.WriteLine(e.Message);
          }               
        }

        private static string checkFileName()
        {
            string tryagain = "t";
            string filename = null;
            
            while(tryagain == "t")
            {
                Console.WriteLine("Enter the name of the file, path excluded and press enter: ");
                filename = Console.ReadLine();

                if(ResourcePathCheck.checkPathCharacters(filename))
                {
                    Console.WriteLine("Filename is valid!");
                    tryagain = "q";
                }
                else
                {
                    filename= null;
                    Console.Write("Type t to try again or any other char to quit and press enter: ");
                    tryagain = Console.ReadLine();
                }
            }

            return filename;
        }

        private static string checkLocalDirectory()
        {
            string tryagain = "t";
            string directory = null;
            
            while(tryagain == "t")
            {
                Console.Write("Enter local directory location press enter: ");
                directory = Console.ReadLine();

                if(Directory.Exists(directory))
                  {
                    Console.WriteLine("Directory found");
                    tryagain="q";
                  }
                else
                  {
                    directory = null; // reset directory in case user quits.
                    Console.Write("Directory not found. Type t to try again or any other char to quit:");
                    tryagain = Console.ReadLine();
                  }
            }

            return directory;

        }

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
                    Console.WriteLine("File found!");
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

                if(ResourcePathCheck.checkDirectoryPath(DirPathRemote) && client.DirectoryExists(DirPathRemote))
                 {
                    cont = "q";
                    retVal = DirPathRemote;
                 }
                else
                 {
                    Console.WriteLine("Remote directory not found. Press t to try again or any other character to quit: ");
                    cont = Console.ReadLine();
                    Console.WriteLine();
                 }
               }

              return retVal;
            }
            
        //uploadFile is used to upload files from local to remote.
        public static void uploadFile(FtpClient client)
        {
            string directoryPathRemote = null;
            string filePathLocal = null;
            string filename = "saved";
    
            filePathLocal = UploadModule.checkLocalFile(); //file location on local machine
            
            if(filePathLocal != null)
             {
                directoryPathRemote = UploadModule.checkRemoteDirectory(client); //location to write the local file to
             }

            if(directoryPathRemote != null)
               filename = UploadModule.getNewFileName();

            if(filePathLocal != null && filename != null && directoryPathRemote != null)
              {
                client.UploadFile(filePathLocal,directoryPathRemote + filename);
                Console.WriteLine("File uploaded!");
                Console.WriteLine("");
              }
            else
                Console.WriteLine(Environment.NewLine + "Upload operation not completed!" + Environment.NewLine);
        }

        public static string getNewFileName()
        {

            string filename = null;
            string contFlag = "t";


            while(contFlag =="t")
            {
               Console.WriteLine("Enter the name you'd like to save the file as on server and press enter: ");
               filename = Console.ReadLine();
               Console.WriteLine("");

               if(ResourcePathCheck.checkPathCharacters(filename))
               {
                    contFlag = "q";
               }
               else
               {
                    filename = null;
                    Console.WriteLine("Type t to try again or any other character to quit: ");
                    contFlag = Console.ReadLine();
                    Console.WriteLine("");
               }

               
            }

            return filename;
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

            if(client.DirectoryExists(newDirectoryRemote))
            {
                Console.WriteLine("The directory already exist.");
                Console.WriteLine("Press t to try again or any other char to quit: ");
                cont = Console.ReadKey().KeyChar;
            }
            else if(FTPServer.Commands.ResourcePathCheck.checkPathCharacters(newDirectoryRemote))
            {
                Console.WriteLine("Creating directory with the name " + newDirectoryRemote);
                Console.WriteLine("___________________________________________");
                client.CreateDirectory(newDirectoryRemote);
                cont = 'q';
            }
            else
            {
               Console.WriteLine("Press t to try again or any other char to quit: ");
               cont = Console.ReadKey().KeyChar;
            }
            
        }
      }
    }
  }


