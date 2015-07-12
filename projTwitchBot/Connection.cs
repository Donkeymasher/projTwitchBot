using System;

namespace projTwitchBot
{
    class Connection
    {
        public System.Net.Sockets.TcpClient Con(int port, string nick, string server, string chan)
        {
            //Connect to irc server and get input and output text streams from TcpClient.
            System.Net.Sockets.TcpClient sock = new System.Net.Sockets.TcpClient();
            sock.Connect(server, port);
            if (!sock.Connected)
            {
                Console.WriteLine("Failed to connect!");
            }
            return sock;
        }
    }
}
