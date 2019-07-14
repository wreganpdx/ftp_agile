using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
namespace FTPServer.Commands
{


    public class GetFile
    {
        static FtpClient client;

        public GetFile()
        {
            Console.WriteLine("Request to obtain a file using the command 'get <file_name>'");

            String fileToGet = Console.ReadLine(); // read in the command
            String [] command = fileToGet.Split(' '); //split so i can ensure the command is in the correct form
            int length = command.Length;//length of the array

            if (command.Length != 2)
            {
                Console.WriteLine("Invalid Command");
            }
            else
            {
                if(command[0] != "get")
                {
                    Console.WriteLine("Invalid Command. Must be in the form 'get <file_name>");
                }
                else
                {
                    
                }
            }
        }
    }
}