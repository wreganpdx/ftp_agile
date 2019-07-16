using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


namespace FTPServer.Commands
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
                    Console.WriteLine(Environment.NewLine + "Directory deleted." + Environment.NewLine);
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
}
