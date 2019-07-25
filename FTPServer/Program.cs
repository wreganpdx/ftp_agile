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

            while(newAction != "0" && client.IsConnected)
            {
                Console.WriteLine("");
                Console.Write("Please enter a command\n");
                Console.Write("1. Get file from remote server\n");
                Console.Write("2. Log off from remote server\n");
                Console.Write("3. Get multiple files\n");
                Console.Write("4. List directories and files on local machine\n");
                Console.Write("5. List directories and files on remote machine\n");
                Console.Write("6. Delete directory on remote server\n");
                Console.Write("7. Create directory on remote server\n");
                Console.Write("8. Put file on remote server\n");
                Console.Write("9. Rename a local file.\n");
                Console.Write("10. Put multiple files on remote server\n");
                Console.Write("11. Change permissions of a file\n");
                Console.Write("12. Rename a local file.\n");


                newAction = Console.ReadLine(); //read in ip
                int action = Convert.ToInt32(newAction);

                switch (action)
                {
                    case 1:
                        Commands.GetFile.getFile(client);
                        break;
                    case 2:
                        Commands.LogOff.logOff(client);
                        break;
                    case 3:
                        Commands.GetMultiple.getmpFile(client);
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        Commands.RemoteLs.remote_Ls(client);
                        break;
                    case 6:
                        Commands.DeleteModule.deleteDir(client);
                        break;
                    case 7:
                        Commands.MakeDir.makeDir(client);
                        break;
                    case 8:
                        Commands.UploadModule.uploadFile(client);
                        break;
                    case 9:
                        Commands.UploadModule.renameFile();
                        break;
                    case 10:
                        Commands.PutMultiple.putMultiple();
                        break;
                    case 11:
                        Commands.Chmod.change_Permissions(client);
                        break;
                    case 12:
                        Commands.Rename.rename(client);
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
