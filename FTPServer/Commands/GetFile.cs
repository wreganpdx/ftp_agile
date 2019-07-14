using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTPServer.Commands
{



    class GetFile
    {
        
        public static void getFile(FtpClient client)
        {
            
            Console.WriteLine("Request to obtain a file using the command 'get path/to/<file_name> path/to/put/<file_name>'");

            String fileToGet = Console.ReadLine(); // read in the command
            String [] command = fileToGet.Split(' '); //split so i can ensure the command is in the correct form
            int length = command.Length;//length of the array

            //just check we have the command, src file and dest file
            if (command.Length != 3)
            {
                Console.WriteLine("Invalid Command");
                Program.OptionPrompt();
            }
            else
            {
                //if the command is not get, throw restart.
                bool result = command[0].Equals("get");
                if(!command[0].Equals("get"))
                {
                    Console.WriteLine("Invalid Command. Must be in the form 'get <file_name>");
                    Program.OptionPrompt();
                }
                else
                {
                    Console.WriteLine("Obtaining file");
                    //command[1] = "./"+command[1];


                    //download the file from the server to the local directory. FtpLocalExists.Append resumes a partial upload.
                    try{
                        //currently hard written file names for testing
                        //put file on the server
                        client.UploadFile(@"C:\User\amand\AgileFiles\fileofnothing.txt", "./AgileFilesInner/fileofnothing.txt");

                        //rename it so i can redownload it
                        //client.Rename("./AgileFilesInner/fileofnothing.txt", "./AgileFilesInner/fileofnothing2.txt");
                        //downloads the file... but this but isnt working. AgileFiles2 is empty.
                        bool response = client.DownloadFile(@"C:\User\amand\AgileFiles\fileofnothing.txt", "./AgileFilesInner/fileofnothing.txt",FtpLocalExists.Overwrite);
                        
                        //if the download was successful
                        if(response == true){
                            Console.WriteLine("File Downloaded");
                        }
                        else{
                            Console.WriteLine("Could Not Download File");
                        }
                        //client.DownloadFile(@command[1],command[2]);
                    }
                    catch(Exception downloadException){
                        Console.WriteLine(Environment.NewLine + downloadException.Message + Environment.NewLine);
                    }
                    //logic
                }
            
            }
        }
    }
        
}   