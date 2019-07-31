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
                Console.Write("9. Log history to file.\n");
                Console.Write("10. List files on remote server.\n");



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
                        LogOff.logOff(client);
                        break;
                    case 3:
                        break;
                    case 4:
                        Commands.List.DirSearch();
                        break;
                    case 5:
                        Commands.DeleteDir.deleteDir(client);
                        break;
                    case 6:
                        Commands.MakeDir.makeDir(client);
                        break;
                    case 7:
                        Commands.PutFile.putFile(client);
                        break;
                    case 8:
                        Commands.RenameFile.renameFile(client);
                        break;
                    case 9:
                        Commands.LogHistory.log_History();
                        break;
                    case 10:
                        Commands.RemoteLs.remote_Ls(client);
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