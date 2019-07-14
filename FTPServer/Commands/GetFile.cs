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
        static FtpClient client;

        static public void getFile()
        {
            Console.WriteLine("Request to obtain a file using the command 'get path/to/<file_name> path/to/put/<file_name>'");

            String fileToGet = Console.ReadLine(); // read in the command
            String [] command = fileToGet.Split(' '); //split so i can ensure the command is in the correct form
            int length = command.Length;//length of the array

            if (command.Length != 3)
            {
                Console.WriteLine("Invalid Command");
                Program.OptionPrompt();
            }
            else
            {
                bool result = command[0].Equals("get");
                if(!command[0].Equals("get"))
                {
                    Console.WriteLine("Invalid Command. Must be in the form 'get <file_name>");
                    Program.OptionPrompt();
                }
                else
                {
                    Console.WriteLine("Obtaining file");
                    
                    //download the file from the server to the local directory. FtpLocalExists.Append resumes a partial upload.
                    client.DownloadFile(@command[1],command[2], FtpLocalExists.Append);
                    //logic
                }
            }
        }
    }
}