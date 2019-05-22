using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Week3
{
    public class Client
    {
        public static void GetTemp()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("10.211.55.5");
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.Connect(new IPEndPoint(ipAddress, 11000));

                    byte[] msg = Encoding.ASCII.GetBytes("Test message, wooh! :D");
                    sender.Send(msg);
                    int bytesRec = sender.Receive(new byte[1024]);
                    Console.WriteLine(
                        Encoding.ASCII.GetString(new byte[1024], 0, bytesRec));
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}