using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
    }
}