using System;
using System.IO;

namespace FTPServer.Commands
{
    class List
    {
        public static void DirSearch()
        {
            try
            { 
                string working_directory;
                Console.WriteLine("What is the absolute path of the directory you want displayed locally?");
                working_directory = Console.ReadLine();
                foreach (string d in Directory.GetDirectories(working_directory))
                {
                    Console.WriteLine(d);
                }
                foreach (string f in Directory.GetFiles(working_directory))
                {
                    Console.WriteLine(f);
                }
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}