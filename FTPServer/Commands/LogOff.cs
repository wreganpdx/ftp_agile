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
        static public void logOff()
        {
            Console.Write("Are you sure you want to log off? Y/N \n");
            string ans = Console.ReadLine();
            if (ans.Equals("Y") || ans.Equals("y"))
            {
                Console.Write("Logging off");
            }
            else
            {
                Program.OptionPrompt();
            }
        }
    }

}


