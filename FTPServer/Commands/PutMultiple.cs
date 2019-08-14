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
            string [] localfile = null; // upload the local file.
            Console.WriteLine("PutFile utility");

            while (tryagain == "t") // We give the user the option to try as many times as they'd like to get local file name in case of errors.
            {
                Console.WriteLine("Enter the absolute path(s) of the local files(s) to upload and press enter (LIMIT = 2)");
                for(int i = 0; i < 2; i++)
                {
                    Console.WriteLine("enter path for file#" + i);
                    localfile[i] = Console.ReadLine(); //get localfile location
                    if (File.Exists(localfile[i])) // Exit this while loop if local file is found.
                    {
                        tryagain = "q";
                    }
                    else //Give user msg that file is not found and offer them a chance to quit the prompt or try again.
                    {
                        localfile[i] = null;
                        Console.WriteLine("Local file not found. Enter t to try again or q to quit: ");
                        tryagain = Console.ReadLine();
                    }
                }
      
            }

            tryagain = "t";
            //This while loop gets the remote resource name to upload localfile to.
            while (tryagain == "t")
            {
                Console.WriteLine("Enter the absolute path to upload the file(s) to and press enter: ");
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
                        for (int i = 0; i < 2; i++)
                        {
                            if (client.UploadFile(localfile[i], uploadlocation))//if upload success
                            {
                                Console.WriteLine("Upload of file #" + i +" completed.\n");
                                return; //exit the function
                            }
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
