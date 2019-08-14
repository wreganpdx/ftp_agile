using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


/*
 * Tests Berin Hadziabdic
 * Attempting to delete non existing directory returns appropriate message: Pass
 * Attempting to delete an existing directory deletes the directory: Pass
 * Exception Handling is supported and appropriate messages are returned: Pass
 * */
namespace FTPServer.Commands
{
    class DeleteDir
    {
        //This deletes a dir on ftp server.
        public static void deleteDir(FtpClient client)
        {
            string directoryLocation; // This var contains the  dir that we will delete.
            string promptContinue = "t"; //Flag for while loop

            while (promptContinue == "t")
            {
                Console.Write("Enter the directory to delete on the server and press enter: ");
                directoryLocation = Console.ReadLine();

                if (client.DirectoryExists(directoryLocation)) //If dir exists,
                {
                    try
                    {
                        //try to delete it
                        client.DeleteDirectory(directoryLocation);
                        Console.Write(Environment.NewLine + "Directory deleted." + Environment.NewLine);
                        promptContinue = "q";
                        Console.WriteLine();
                    }
                    catch(Exception e)
                    {
                        //If an exception ocurrs offer message and try again prompt
                        Console.WriteLine("An error occurred: " + e.Message);
                        Console.Write("Press t to try again, any other char to quit, and press enter: ");
                        promptContinue = Console.ReadLine();
                        Console.WriteLine();
                    }
                }
                else
                {
                    //Dir not found, ask if user wants to enter another dir name.
                    Console.Write("Directory does not exist on the server. Press t to try again, any other char to quit, and press enter: ");
                    promptContinue = Console.ReadLine();
                    Console.WriteLine();
                }
            }

        }
    }
}
