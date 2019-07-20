using System;
using System.IO;
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
        static char save_credientals;
       

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

                    //Console.WriteLine(Environment.NewLine + "Leaving username and password field empty attempts to connect with anonymous account." + Environment.NewLine);

                    Console.Write("Enter the username field to connect with and press enter: ");
                    Program.username = Console.ReadLine(); //read in username
                    Console.Write("Enter the password field to connect with and press enter: ");
                    Program.password = Console.ReadLine(); //read in password
                    Console.Write("Would you like to save this connection info? (Y/N): ");
                    Program.save_credientals = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.Write("\n====================\n");
                    if (save_credientals == 'Y')
                    {
                        Commands.SaveLoginInfo.saveLoginInfo(ip, username, password);
                    }
                 

                    client = new FtpClient(Program.ip); // create an FTP client using ip
                    client.Credentials = new System.Net.NetworkCredential(Program.username, Program.password); //Create credentials
                    client.Connect(); //Connect to client

                    if (client.IsConnected) //If connect success
                    { 
                        continuePrompt = 'N'; //Setting continuePrompt flag to N ensures we escape for loop.
                        Console.WriteLine("FTP is connected");
                        while (client.IsConnected)
                        {
                            Program.OptionPrompt(); //give option prompt          
                            Console.ReadLine();
                        }
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

        private static char ToUpper(char v)
        {
            throw new NotImplementedException();
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
            Console.Write("8. Put multiple files on remote server\n");



            newAction = Console.ReadLine(); //read in ip
            int action = Convert.ToInt32(newAction);
            switch (action)
            {
                case 1:
                    break;
                case 2:
                    Commands.LogOff.logOff(client);
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
                    break;
                case 8:
                    Commands.PutMultiple.putMultiple();
                    break;
            }

        }
        static void Main(string[] args)
        {
            Program.LogIn();
        }
    }
}
