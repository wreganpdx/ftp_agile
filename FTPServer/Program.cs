using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using FTPServer.Commands;
using System.IO;


namespace FTPServer
{

    class Program
    {
        static FtpClient client;

        public static void OptionPrompt()
        {
            string newAction = null;

            while(newAction != "0")
            {
                Console.WriteLine("");
                Console.Write("Please enter a command\n");
                Console.Write("0. Exit application.\n");
                Console.Write("1. Get file from remote server\n");
                Console.Write("2. Log off from remote server\n");
                Console.Write("3. Get multiple files\n");
                Console.Write("4. List directories and files on local machine\n");
                Console.Write("5. Delete directory on remote server\n");
                Console.Write("6. Create directory on remote server\n");
                Console.Write("7. Put file on remote server\n");
                Console.Write("8. Rename a local file.\n");



                newAction = Console.ReadLine(); //read in ip
                int action = Convert.ToInt32(newAction);

                switch (action)
                {
                    case 0:
                        Console.WriteLine("Bye!");
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Commands.DeleteModule.deleteDir(client);
                        break;
                    case 6:
                        Commands.UploadModule.makeDir(client);
                        break;
                    case 7:
                        Commands.UploadModule.uploadFile(client);
                        break;
                    case 8:
                        Commands.UploadModule.renameFile();
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
           //192.168.1.11
           Console.WriteLine("FTP CLIENT" + Environment.NewLine);

           client = Commands.LogIn.logIn();
           
          if(client != null && client.IsConnected)
             Program.OptionPrompt();
        }
    }
}
