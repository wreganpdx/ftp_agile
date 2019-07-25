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
        static public void useLogin(FtpClient client)
        {
            string[] lines = System.IO.File.ReadAllLines("/Users/iobrien/ftp_agile/login_info.txt");
            string ip = lines[0];
            string username = lines[1];
            string password = lines[2];
            client = new FtpClient(ip); // create an FTP client using ip
            client.Credentials = new System.Net.NetworkCredential(username, password); //Create credentials
            client.Connect(); //Connect to client
        }
    }
    
}