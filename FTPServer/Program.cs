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
        public static void LogIn()
        {
            char continuePrompt = 'Y'; //This flag is used to exit the while loop below by being set to anything other than Y.

            while (continuePrompt == 'Y')
            {
                try
                {
                    Console.WriteLine("DEBUG MSG: Localhost IP is 127.0.0.1");
                    Console.Write("Enter the I.P to connect to and press enter: ");
                    Program.ip = Console.ReadLine(); //read in ip

                    Console.WriteLine(Environment.NewLine + "Leaving username and password field empty attempts to connect with anonymous account." + Environment.NewLine);

                    Console.Write("Enter the username field to connect with and press enter: ");
                    Program.username = Console.ReadLine(); //read in username
                    Console.Write("Enter the password field to connect with and press enter: ");
                    Program.password = Console.ReadLine(); //read in password

                    client = new FtpClient(Program.ip); // create an FTP client using ip
                    client.Credentials = new System.Net.NetworkCredential(Program.username, Program.password); //Create credentials
                    client.Connect(); //Connect to client

                    if (client.IsConnected) //If connect success
                    {
                        continuePrompt = 'N'; //Setting continuePrompt flag to N ensures we escape for loop.
                        Program.OptionPrompt(); //give option prompt
                        Console.WriteLine("FTP is connected");
                        Console.ReadLine();
                    }
                }
                catch (Exception connectionException)
                {
                    //print exception to console since we don't have a log file
                    Console.WriteLine(Environment.NewLine + connectionException.Message + Environment.NewLine);
                }
                finally //finally, we ask user if they'd like to try another log in attempt.
                {
                    Console.WriteLine("A connection exception has occurred. Would you like to try again? Type in Y to continue or N to exit.");
                    continuePrompt = Char.ToUpper(Console.ReadKey().KeyChar);
                }


            }
        }
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
            Console.Write("8. Rename file on remote server\n");



            newAction = Console.ReadLine(); //read in ip
            int action = Convert.ToInt32(newAction);
            switch (action)
            {
                case 1:
                    Commands.GetFile.getFile(client);
                    break;
                case 2:
                    Commands.LogOff.logOff();
                    break;
                case 3:
                    Commands.GetMultiple.getmpFile(client);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    Commands.Rename.rename(client);
                    break;
            }

        }
        static void Main(string[] args)
        {
            Program.LogIn();
        }
    }
}
