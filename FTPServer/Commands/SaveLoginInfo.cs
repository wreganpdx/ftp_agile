using System;
using FluentFTP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FTPServer.Commands
{

    static public class SaveLoginInfo
    {
        static string path = "";

        static public void saveLoginInfo(string ip, string username, string password)
        { 
                Console.Write("enter full path to to blank file to save login info: ");
                path = Console.ReadLine();
                string[] createText = { ip, username, password };
                File.WriteAllLines(path, createText);
        }
    }
}
