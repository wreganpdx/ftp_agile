using System;
using FluentFTP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FTPServer.Commands
{
    public class SaveLoginInfo
    {
        static string path = "/Users/iobrien/ftp_agile/login_info.txt";

        static public void saveLoginInfo(string ip, string username, string password)
        {
            if (!File.Exists(path))
            {
                Console.Write("\n file " + path + " does not exist\n");
            }
            string[] createText = { ip, username, password };
            File.WriteAllLines(path, createText);
        }
    }
}
