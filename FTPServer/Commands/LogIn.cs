using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;


namespace FTPServer.Commands
{

    class LogIn
    {
        public static void logIn(FtpClient client)
        {
            char continuePrompt = 'Y'; //This flag is used to exit the while loop below by being set to anything other than Y.
            string username = "";
            string password = "";
            string ip = "";

            Console.WriteLine("Al");
            while (continuePrompt == 'Y')
            {
                try
                {
                    Console.WriteLine("DEBUG MSG: Localhost IP is 127.0.0.1");
                    Console.Write("Enter the I.P to connect to and press enter: ");
                    ip = Console.ReadLine(); //read in ip

                    Console.WriteLine(Environment.NewLine + "Leaving username and password field empty attempts to connect with anonymous account." + Environment.NewLine);

                    Console.Write("Enter the username field to connect with and press enter: ");
                    username = Console.ReadLine(); //read in username
                    Console.Write("Enter the password field to connect with and press enter: ");
                    password = Console.ReadLine(); //read in password

                    client = new FtpClient(ip); // create an FTP client using ip
                    client.Credentials = new System.Net.NetworkCredential(username, password); //Create credentials
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
    }
}
