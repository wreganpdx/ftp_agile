using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FTPServer.Commands
{
     class LogOff
    {
        static public void logOff(FtpClient client)
        {
            Console.Write("Are you sure you want to log off? Y/N \n");
            string ans = Console.ReadLine();
            if (ans.Equals("Y") || ans.Equals("y"))
            {
                client.Disconnect();
                if (!client.IsConnected)
                {
                    Console.Write("Client got disconnected from the FTP server.\n\rPress any key to exit...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Client could not disconnect, try again");
                }
            }
            else
            {
                return;
            }
        }
    }

}


