using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;



namespace FTPServer
{

  
    class Program
    {
        static string ip; // ip will be a string type
        static string username;
        static string password;
        static FtpClient client;
       

        public static void OptionPrompt()
        {
            string newAction;
            Console.Write("Please enter a command\n");
            Console.Write("1. Get file from remote server\n");
            Console.Write("2. Log off from remote server\n");
            Console.Write("3. Get multiple files\n");
            Console.Write("4. List directories and files on local machine\n");
            Console.Write("5. Delete directory on remote server\n");
            Console.Write("6. Create directory on remote server\n");
            Console.Write("7. Put file on remote server\n");



            newAction = Console.ReadLine(); //read in ip
            int action = Convert.ToInt32(newAction);
            switch (action)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    
                    break;
                case 6:
                    break;
                case 7:
                    FTPServer.Commands.UploadModule.uploadFile(client);
                    break;
            }

        }
        static void Main(string[] args)
        {
            FTPServer.Commands.LogIn.LogIn(client);
        }
    }
}
