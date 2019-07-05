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
            FtpClient client;

            
            Console.WriteLine("DEBUG MSG: Localhost IP is 127.0.0.1");
            Console.WriteLine("Enter the I.P to connect to and press enter: ");
            ip = Console.ReadLine(); //read in ip

            client = new FtpClient(ip); // create an FTP client using ip
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
            Console.Write("This is a place holder! Connection success!");
        }
        static void Main(string[] args)
        {
            Program.LogIn();
        }
    }
}
