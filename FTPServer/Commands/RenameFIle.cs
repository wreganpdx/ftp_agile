using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

/* Test Records Berin Hadziabdic
 *Attempting to rename a non existing file returns appropriate prompt: Pass
 *Attempting to rename a non existing file returns appropriate prompt: Pass 
 * Attempting ro rename to existing file returns appropriate prompt: Pass
 * Attempting to rename a file with invalid chars, including supplying an empty string, returns appropriate prompt: Pass
 * Attempting to rename an existing file to a valid new name actually succeeds: Pass
 */


namespace FTPServer.Commands
{
    class RenameFile
    {
        public static void renameFile(FtpClient client)
        {

            string fileToRenamePath = null;
            string newfilename = null;
            string cont = "t";

            while (cont == "t")
            {
                Console.WriteLine("");
                Console.WriteLine("Enter the absolute path of the file to rename location and press enter: ");
                fileToRenamePath = Console.ReadLine();
                Console.WriteLine("");

                if (File.Exists(fileToRenamePath))
                {
                     cont = "q"; 
                    Console.WriteLine("File found");
                }
                else
                {
                   Console.WriteLine("The local filepath is not valid. Type t to try another path or any other char to quit: ");
                   cont = Console.ReadLine();

                   if(cont != "t")
                   {
                        Console.WriteLine("Exiting! Bye!");
                        return;
                   }
                }
              
            }

            cont = "t";

            while (cont == "t")
            {
                Console.WriteLine("");
                Console.WriteLine("Enter the name to rename the file to and press enter: ");
                newfilename = Console.ReadLine();
                
                

                if (!File.Exists(System.IO.Path.GetDirectoryName(fileToRenamePath) + "\\" + newfilename))
                {
                    try
                    {
                        File.Move(fileToRenamePath,System.IO.Path.GetDirectoryName(fileToRenamePath) + "\\" + newfilename);
                        Console.WriteLine("Operation completed!");
                        return;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("An error ocurred: " + e.Message);
                        Console.WriteLine("Would you to try again? Type t to try again or any other char to exit: ");
                        cont = Console.ReadLine();
                    }
                }
                else
                {
                     Console.WriteLine("The file aread exists on your local machine.");
                     Console.WriteLine("Would you to try again? Type t to try again or any other char to exit: ");
                     cont = Console.ReadLine();
                }

            }
        }
    }
};
