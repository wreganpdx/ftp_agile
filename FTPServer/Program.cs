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
        public static void LogIn()
        {
            string ip; // ip will be a string type
            string username;
            string password;
            FtpClient client;

            
            Console.WriteLine("DEBUG MSG: Localhost IP is 127.0.0.1");
            Console.Write("Enter the I.P to connect to and press enter: ");
            ip = Console.ReadLine(); //read in ip

            Console.WriteLine(""); //spacing for console
            Console.WriteLine("Leaving username and password field empty attempts to connect with anonymous account.");
            Console.WriteLine(""); //spacing for console

            Console.Write("Enter the username field to connect with and press enter: ");
            username = Console.ReadLine(); //read in username
            Console.Write("Enter the password field to connect with and press enter: ");
            password = Console.ReadLine(); //read in password

            client = new FtpClient(ip); // create an FTP client using ip
            client.Credentials = new System.Net.NetworkCredential(username, password); //Create credentials
            client.Connect(); //Connect to client

            if(client.IsConnected) //If connect success
            {
                Program.OptionPrompt(); //give option prompt
            }
            else
            {
                Console.Write("Connection failed. The server may not be running or connection fields like IP or credentials may be invalid.");//display error
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



            newAction = Console.ReadLine(); //read in ip
            int action = Convert.ToInt32(newAction);
            switch (action)
            {
                case 1:
                    break;
                case 2:
                    Commands.LogOff.logOff();
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
            }

        }
        static void Main(string[] args)
        {
            Program.LogIn();
        }
    }
}
