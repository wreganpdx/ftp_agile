using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using FTPServer.Commands;
using System.IO;

/*
 *BH: Attempting to rename a non existing directory returns the appropriate prompt: Pass 
 * BH: Attempting to enter invalid chars or empty strings returns the appropriaye prompt: Pass
 * BH: Attempting to rename a directory to an existing directory returns the appropriayte prompt: 
 */
namespace FTPServer
{

    class Program
    {
        static FtpClient client;

        public static void OptionPrompt()
        {
            string newAction = null;
            int action;          
  
            while (newAction != "0")
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
                Console.Write("9. Rename a remote directory.\n");




                newAction = Console.ReadLine(); //read in ip

                try{
                   action = Int32.Parse(newAction);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Unexpected input. Please enter a number between 0 and Y");
                    continue;
                }

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
                        Commands.RenameRemoteDir.renameDir(client);
                        break;
                    default:
                        Console.WriteLine("You selected an unsupported option.");
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
            //192.168.1.11
            Console.WriteLine("FTP CLIENT" + Environment.NewLine);

            client = Commands.LogIn.logIn();

            if (client != null && client.IsConnected)
                Program.OptionPrompt();
        }
    }
}