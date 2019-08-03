using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTPServer.Commands
{
	class PutMultiple
	{
		static public void putMultiple(FtpClient client)
		{
            string tryagain = "t"; //This is a while loop flag.
            string uploadlocation = null; //This specifies location on server we want to...
            string localfile = null; // upload the local file.
            Console.WriteLine("PutFile utility");

            while (tryagain == "t") // We give the user the option to try as many times as they'd like to get local file name in case of errors.
            {
                Console.WriteLine("Enter the absolute path of the local file to upload and press enter: ");
                localfile = Console.ReadLine(); //get localfile location

                if (File.Exists(localfile)) // Exit this while loop if local file is found.
                {
                    tryagain = "q";
                }
                else //Give user msg that file is not found and offer them a chance to quit the prompt or try again.
                {
                    localfile = null;
                    Console.WriteLine("Local file not found. Enter t to try again or q to quit: ");
                    tryagain = Console.ReadLine();
                }
            }

            if (localfile == null) //If local file is null, then user has elected to quit the operation at this point.
            {
                Console.WriteLine("Put operation aborted. Bye!");
                return; //Early exit from function since user decide to quit.
            }
            else
                tryagain = "t"; // reset the while loop flag for the next phase of the putfile function.

            //This while loop gets the remote resource name to upload localfile to.
            while (tryagain == "t")
            {
                Console.WriteLine("Enter the absolute path to upload the file to and press enter: ");
                uploadlocation = Console.ReadLine();

                if (client.FileExists(uploadlocation)) // If file exists already, let the user know they need to specify a file name that does not exist on server currently.
                {
                    Console.WriteLine("A file already exists in: " + uploadlocation);
                    Console.WriteLine("Would you like to try another location. Press t to try again or any other key to quit:");
                    tryagain = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        if (client.UploadFile(localfile, uploadlocation))//if upload success
                        {
                            Console.WriteLine("Upload completed.\n");
                            return; //exit the function
                        }
                    }
                    catch (Exception e) //If an exception occurs, then alert user and give them the option to try again or quit.
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        Console.WriteLine("Would you like to try another location. Press t to try again or any other key to quit:");
                        tryagain = Console.ReadLine();
                    }
                }
            }

        }
	}
}
