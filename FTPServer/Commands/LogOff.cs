using System;
using FluentFTP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write("Logging off");
                client.Disconnect();
            }
            else
            {
                Program.OptionPrompt();
            }
        }
    }
}
