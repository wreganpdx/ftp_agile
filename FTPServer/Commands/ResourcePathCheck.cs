using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


namespace FTPServer.Commands
{
    class ResourcePathCheck
    {

        public static bool checkDirectoryPath(string directorypath)
        {
            bool valid = false;


            if (directorypath == "")
            {
                Console.WriteLine("Enter a name, please! Isn't that what you are here for?");
                Console.WriteLine("________________________");
            }
            else if (directorypath.IndexOfAny("<>/|?*".ToCharArray()) != -1)
            {
                Console.WriteLine("No forbidden character!");
                Console.WriteLine("________________________");
            }
            else if (directorypath.EndsWith("."))
            {
                Console.WriteLine("The last character in the name can't be \".\"!");
                Console.WriteLine("______________________________________________");
            }
            else if(!directorypath.EndsWith("\\"))
            {
                Console.WriteLine("");
                Console.WriteLine("The directory path must end with \\ for Windows systems.");
                Console.WriteLine("");
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        //This function  returns true if a resources name character set is valid, and false if it is not.
        public static bool checkPathCharacters(string path)
        {

            bool valid = false;


            if (path == "")
            {
                Console.WriteLine("Enter a name, please! Isn't that what you are here for?");
                Console.WriteLine("________________________");
            }
            else if (path.IndexOfAny("<>:\"/\\|?*".ToCharArray()) != -1)
            {
                Console.WriteLine("No forbidden character!");
                Console.WriteLine("________________________");
            }
            else if (path.EndsWith("."))
            {
                Console.WriteLine("The last character in the name can't be \".\"!");
                Console.WriteLine("______________________________________________");
            }
            else
            {
                valid = true;
            }

            return valid;
        }
    }
}


