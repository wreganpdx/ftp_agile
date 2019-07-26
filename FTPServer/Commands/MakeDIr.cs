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
            string cont = "t";

            while (cont == "t")
            {
                Console.WriteLine("");
                Console.WriteLine("Enter directory to add and press enter: ");
                newDirectoryRemote = Console.ReadLine();
                Console.WriteLine("");

                if (client.DirectoryExists(newDirectoryRemote))
                {
                    Console.WriteLine("The directory already exist.");
                    Console.WriteLine("Press t to try again or any other char to quit: ");
                    cont = Console.ReadLine();
                }
                else //The directory does not exist. Attempt to make it.
                {
                  try
                  {
                    client.CreateDirectory(newDirectoryRemote);
                    cont = "q";
                  }
                  catch(Exception e)
                  {
                    Console.WriteLine("An error ocurred: " + e.Message);
                    Console.WriteLine("Would you like to try again. Type t to try again or any other char to quit and press enter: ");
                    cont = Console.ReadLine();
                  }
                }
            }
        }
    }
};
