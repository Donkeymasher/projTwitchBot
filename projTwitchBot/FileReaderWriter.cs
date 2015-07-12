using System;
using System.IO;

namespace projTwitchBot
{
    class FileReaderWriter
    {
        public void main(int port, string nick, string server, string chan)
        {
            try 
			    {
				    //Pass the filepath and filename to the StreamWriter Constructor
				    StreamWriter sw = new StreamWriter("Test.txt");

				    //Write a line of text
				    sw.WriteLine(port);
                    sw.WriteLine(nick);
                    sw.WriteLine(server);
                    sw.WriteLine(chan);
				   
                    //Write a second line of text
				    sw.WriteLine("From the StreamWriter class");

				    //Close the file
				    sw.Close();
			    }
			    catch(Exception e)
			    {
				    Console.WriteLine("Exception: " + e.Message);
			    }
			    finally 
			    {
				    Console.WriteLine("Executing finally block.");
			    }
        }
    }
}
