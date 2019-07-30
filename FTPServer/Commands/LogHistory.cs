using System;
using FluentFTP;
using System.Diagnostics;

namespace FTPServer.Commands
{
    class LogHistory
    {
        public static void log_History()
        {
            try
            {
                // log file is located at /FTPServer/bin/Debug/log_file.txt
                FtpTrace.AddListener(new TextWriterTraceListener("log_file.txt"));

                FtpTrace.LogUserName = false;   // hide FTP user names
                FtpTrace.LogPassword = false;   // hide FTP passwords
                FtpTrace.LogIP = false; 	// hide FTP server IP addresses
                Console.WriteLine("Logging history in /FTPServer/bin/Debug/log_file.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(Environment.NewLine + e.Message + Environment.NewLine);
            }
        }
    }
}
