using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTPServer.Commands
{ 
    public class GetMultiple
    {
        public static void getmpFile(FtpClient client)
        {
            Console.WriteLine("To obtain multiple files, enter the command 'getmp absolute/path/to/put/files/ absolute/path/to/get/files/from/'");
            String fileToGet = Console.ReadLine(); // read in the command
            String[] command = fileToGet.Split(' '); //split so i can ensure the command is in the correct form
            int length = command.Length;//length of the array
            int numDownloaded=0;


            //just check we have the command, src file and dest file
            if (command.Length != 3)
            {
                Console.WriteLine("Invalid Command");
                Program.OptionPrompt();
            }
            else
            {
                //if the command is not rename, throw restart.
                bool result = command[0].Equals("getmp");
                if (!command[0].Equals("getmp"))
                {

                    Console.WriteLine("Invalid Command. Must be in the form 'getmp /absolute/path/to/put/files/ /absolute/path/to/get/files/from/'");
                    Program.OptionPrompt();
                }
                else
                {
                    //verify the / is at the end or weird things happen...

                        
                        Console.WriteLine("File names to obtain ex: <file_name1> <file_name2> ... ...");
                        String allfiles = Console.ReadLine();

                        String[] files = allfiles.Split(' ');//split to obtain each file
                        
                        int filelength = files.Length;//length of the array

                        for (int i =0; i<filelength; i++) {
                            files[i]=command[2]+files[i];//append the file name to the absolute path
                        }

                        try
                        { 
                            numDownloaded = client.DownloadFiles(command[1], files,FtpLocalExists.Skip,FtpVerify.Delete);
                        }
                        catch (Exception getmpFileException)
                        {
                               Console.WriteLine(Environment.NewLine + getmpFileException.Message + Environment.NewLine);
                        }
                    //Check if all the files were downloaded.
                        if(numDownloaded == filelength){
                            Console.WriteLine("All files downloaded");
                        }
                        else{//will output how many files couldnt be downloaded
                            Console.WriteLine("Downloaded "+numDownloaded+ " files. Could not download "+ (filelength-numDownloaded) + " files");
                        }

                    }
                }
            
        }
    }
}

