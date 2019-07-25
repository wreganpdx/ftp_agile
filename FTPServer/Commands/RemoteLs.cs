using System;
using FluentFTP;

namespace FTPServer.Commands
{
    class RemoteLs 
    {
        public static void remote_Ls(FtpClient client)
        {
            try
            {
                string current_directory;
                current_directory = client.GetWorkingDirectory();
                Console.WriteLine("Current directory path: " + current_directory);
                string working_directory;
                Console.WriteLine("What is the absolute path of the directory you want displayed?");
                working_directory = Console.ReadLine();

                client.SetWorkingDirectory(working_directory);

                //string[] files;
                //files = client.GetNameListing();
                //foreach (var item in files)
                //{
                //    Console.WriteLine(item + "\n");
                //}

                FtpListItem[] currentDirectoryFiles;
                string chmod_value;

                currentDirectoryFiles = client.GetListing(working_directory);
                if (currentDirectoryFiles != null)
                {
                    foreach (var item in currentDirectoryFiles)
                    {
                        chmod_value = calculate_Chmod(item.Chmod);
                        Console.WriteLine(chmod_value + "\t" + item.Size + "\t" + item.Modified + "\t" + item.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Environment.NewLine + e.Message + Environment.NewLine);
            }
        }
        public static string calculate_Chmod(int chmod)
        {
            string owner;
            string group;
            string others;

            owner = bit_Converter(chmod / 100);
            group = bit_Converter((chmod % 100) / 10);
            others = bit_Converter(chmod % 10);
            return owner + group + others;
        }
        public static string bit_Converter(int chmod)
        {
            switch (chmod)
            {
                case 7:
                    return "WRX";
                case 6:
                    return "RW-";
                case 5:
                    return "R-X";
                case 4:
                    return "R--";
                case 3:
                    return "-WX";
                case 2:
                    return "-W-";
                case 1:
                    return "--X";
                default:
                    return "---";
            }
        }
    }
}
