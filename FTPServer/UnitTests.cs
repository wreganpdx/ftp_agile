using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Xunit;

using FluentFTP;
using System.IO;
using Xunit.Abstractions;
using Xunit.Sdk;
using System.Collections.Concurrent;

namespace FTPServer
{
    public class ClientInstance
    {
        private static FtpClient client = null;

        public static FtpClient getInstance()
        {
            if (client == null)
            {
                client = Commands.LogIn.logIn();
            }
            return client;
        }
    }
    public class UnitTests
    {

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void SignOnTest()
        {
            ClientInstance.getInstance();
            Assert.True(ClientInstance.getInstance().IsConnected); //If connect success
        }

        [Fact]
        public void makeDirTest()
        {
            String s = RandomString(8);
            var sr = new StringReader(s);

            Console.SetIn(sr);
            Commands.MakeDir.makeDir(ClientInstance.getInstance());
            Assert.True(ClientInstance.getInstance().DirectoryExists(s));
        }

        [Fact]
        public void delDirTest()
        {
            String s = RandomString(8);

            var sr = new StringReader(s);
            Console.SetIn(sr);
            Commands.MakeDir.makeDir(ClientInstance.getInstance());
            Assert.True(ClientInstance.getInstance().DirectoryExists(s));

            sr = new StringReader(s);
            Console.SetIn(sr);
            Commands.DeleteModule.deleteDir(ClientInstance.getInstance());
            Assert.False(ClientInstance.getInstance().DirectoryExists(s));
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

      


        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
