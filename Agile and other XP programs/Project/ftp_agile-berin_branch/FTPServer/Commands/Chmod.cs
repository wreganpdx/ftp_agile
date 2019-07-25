using System;
using FluentFTP;

namespace FTPServer.Commands
{
    class Chmod
    {
        public static void change_Permissions(FtpClient client)
        {
            string file_Path;
            try
            {
                Console.WriteLine("What is the file name of the permissions " +
                    "you wish to change(e.g. file.txt)?");
                // auto adds the current working directory path, if removed, user must enter
                // entire file path
                file_Path = "./" + Console.ReadLine();
                Console.WriteLine("What is the new permission value (e.g. 777)?");
                int new_Permission = Convert.ToInt32(Console.ReadLine());
                client.Chmod(file_Path, new_Permission);
            }
            catch (Exception e)
            {
                Console.WriteLine(Environment.NewLine + e.Message + Environment.NewLine);
            }
        }
    }
}
