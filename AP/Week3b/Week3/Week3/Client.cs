using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Week3
{
    public class Client
    {
        private Socket sender;
        private IPAddress ip;
        private readonly IPEndPoint _remoteEP;

        public Client(string ipAdress, int port)
        {
            ip = IPAddress.Parse(ipAdress);
            _remoteEP = new IPEndPoint(ip, port);
        }

        public void OpenConnection()
        {
            sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(_remoteEP);
        }

        public void CloseConnection()
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        public void Send(string message)
        {
            var msg = Encoding.ASCII.GetBytes(message);
            sender.Send(msg);
        }

        public string ReceiveTemp()
        {
            var bytes = new byte[1024];
            Send("<TEMP>");
            var bytesReceived = sender.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        }

        public string GetTemp()
        {
            OpenConnection();
            var t = ReceiveTemp();
            CloseConnection();
            return t;
        }

        public string GetHTML()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 80);
            string GETrequest = "GET / HTTP/1.1\r\nHost: 127.0.0.1\r\nConnection: keep-alive\r\nAccept: text/html\r\nUser-Agent: CSharpTests\r\n\r\n";
            socket.Send(Encoding.ASCII.GetBytes(GETrequest));

            var buffer  = new byte(1024);

            int bytesReceived = socket.Receive(new byte[1024]);
           
            socket.Close();
            return Encoding.ASCII.GetString(new byte[1024], 0, bytesReceived);
        }
    }
}