using System;

namespace FTPServer.Commands
{
	class PutMultiple
	{
		static public void putMultiple()
		{
			Console.Write("list files to put on remote server:\n");
			string files = Console.ReadLine();
            // test condition
            if(1==1)
			{
				// if file exists on local machine put on remote server
				Console.Write("test");
			}

            // loop back to prompt
			//Program.OptionPrompt();
			
		}
	}
}
