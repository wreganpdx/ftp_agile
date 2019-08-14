using System;
using FluentFTP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FTPServer.Commands
{
    public class UseLogin
    {
        static string path = "";
        static public string [] useLogin(string ip, string username, string password)
        {
            Console.Write("enter path where login info is saved: ");
            path = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(path);
            //ip = lines[0];
            //username = lines[1];
            //password = lines[2];
            return lines;
        }
    }
    
}