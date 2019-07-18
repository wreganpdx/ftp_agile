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
            Console.WriteLine("To obtain multiple files, enter the command 'getmp absolute/path/to/<original_file> absolute/path/to/<updated_file>'");
            String fileToGet = Console.ReadLine(); // read in the command
            String[] command = fileToGet.Split(' '); //split so i can ensure the command is in the correct form
            int length = command.Length;//length of the array

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

                    Console.WriteLine("Invalid Command. Must be in the form 'rename absolute/path/to/<original_file> absolute/path/to/<updated_file>'");
                    Program.OptionPrompt();
                }
                else
                {
                    Console.WriteLine("Obtaining files");

                    try
                    {


                       // client.DownloadFiles();

                    }
                    catch (Exception renameException)
                    {
                        Console.WriteLine(Environment.NewLine + renameException.Message + Environment.NewLine);
                    }

                }

            }
        }
    }
}

