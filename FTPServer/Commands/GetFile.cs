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
            //User must be VERY specific with path to file. 
            Console.WriteLine("Request to obtain a file using this example 'get absolute/path/to/<file_name> absolutepath/to/put/<file_name>'");
            Console.WriteLine("Be aware of where the ftp client was set up. If it is set to search a certain directory, it can only look for files within specified directory");
            //for example, I had the path C:/users/amanda/AgileFiles set as my ftp server's path. I could only search for files/folders from AgileFiles. 


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
                    
                    Console.WriteLine("Invalid Command. Must be in the form 'get absolute/path/to/put/<file_name> absolute/path/to/<file_name>'");
                    Program.OptionPrompt();
                }
                else
                {
                    Console.WriteLine("Obtaining file");
                    //command[1] = "./"+command[1];


                    //download the file from the server to the local directory. FtpLocalExists.Append resumes a partial upload.
                    try{
                        

                        bool response = client.DownloadFile(command[1], command[2]);
                        
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
                   
                }
            
            }
        }
    }
        
}   