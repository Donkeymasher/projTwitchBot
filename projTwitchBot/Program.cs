using System;
using System.Collections.Generic;
using System.Media;
using WMPLib;

namespace projTwitchBot
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            System.IO.TextReader input;
            System.IO.TextWriter output;

            int port;
            string buf, nick, server, chan;

            //Get pass, nick, owner, server, port, and channel from user
            Console.Write("Enter bot nick: " + "\n");
            //nick = Console.ReadLine();
            nick = "GoldenCarrotBot";
            Console.Write("Enter server: " + "\n");
            //server = Console.ReadLine();
            server = "irc.twitch.tv";
            Console.Write("Enter port number: " + "\n");
            //port = Convert.ToInt32(Console.ReadLine());
            port = Convert.ToInt32(6667);
            Console.Write("Channel: " + "\n");
            //chan = Console.ReadLine();
            chan = "#dexteritybonus";

            Connection Alpha = new Connection();
            System.Net.Sockets.TcpClient sock = Alpha.Con(port, nick, server, chan);
            input = new System.IO.StreamReader(sock.GetStream());
            output = new System.IO.StreamWriter(sock.GetStream());

            //Starting USER and NICK login commands
                                //Twitch key required
            Console.Write("Twitch oauth key required: ");
            output.Write("PASS " + (Console.ReadLine()) + "\r\n" + "NICK " + nick + "\r\n" );
            output.Flush();

            //Process each line received from irc server
            for (buf = input.ReadLine(); ; buf = input.ReadLine())
            {
                //Display received irc message
                Console.WriteLine(buf);
                StreamCommands delta = new StreamCommands();
                delta.PingPong(buf, output);
                delta.Ding(buf);
                delta.Dong(buf);
               
                if (buf[0] != ':') continue;

                /* IRC commands come in one of these formats:
                 * :NICK!USER@HOST COMMAND ARGS ... :DATA\r\n
                 * :SERVER COMAND ARGS ... :DATA\r\n
                 */

                //After server sends 001 command, we can set mode to bot and join a channel
                if (buf.Split(' ')[1] == "001")
                {
                    output.Write(
                        "MODE " + nick + " +B\r\n" +
                        "JOIN " + chan + "\r\n"
                    );
                    output.Flush();
                }
            }
        }
    }
}
