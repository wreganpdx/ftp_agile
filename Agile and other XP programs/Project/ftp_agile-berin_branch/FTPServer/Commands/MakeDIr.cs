using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


namespace FTPServer.Commands
{
    class MakeDir
    {
        public static void makeDir(FtpClient client)
        {

            string newDirectoryRemote = null;
            char cont = 't';

            while (cont == 't')
            {
                Console.WriteLine("");
                Console.WriteLine("Enter directory to add and press enter: ");
                newDirectoryRemote = Console.ReadLine();
                Console.WriteLine("");

                if (client.DirectoryExists(newDirectoryRemote))
                {
                    Console.WriteLine("The directory already exist.");
                    Console.WriteLine("Press t to try again or any other char to quit: ");
                    cont = Console.ReadKey().KeyChar;
                }
                else if (FTPServer.Commands.ResourcePathCheck.checkPathCharacters(newDirectoryRemote))
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
};
