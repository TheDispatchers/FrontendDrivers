using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace iTaxApp
{
    public class SynchronousSocketClient
    {
        
        public static object StartClient(string function, object o)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            Console.WriteLine("Start!");
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPAddress ipAddress = new IPAddress(new byte[] { 86, 52, 212, 76 });
                //   IPAddress ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8113);
                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);
                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
                    // Encode the data string into a byte array.
                    switch (function)
                    {
                        case "login":
                            User user;
                            user = (User)o;
                            string json = JsonConvert.SerializeObject(user);
                            Console.WriteLine(json);
                            byte[] login = Encoding.ASCII.GetBytes(json);
                            int bytesSent = sender.Send(login);
                            int bytesRec = sender.Receive(bytes);
                            string sessionKey = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            Console.WriteLine(sessionKey);
                            user.sessionKey = sessionKey;
                            o = user;
                            break;
                        case "register":
                            /*user = (User)o;
                            string json = JsonConvert.SerializeObject(user);
                            Console.WriteLine(json);
                            byte[] login = Encoding.ASCII.GetBytes(json);
                            int bytesSent = sender.Send(login);
                            int bytesRec = sender.Receive(bytes);
                            string sessionKey = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            Console.WriteLine(sessionKey);
                            user.sessionKey = sessionKey;
                            o = user;*/
                            break;
                    }
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    return o;
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    return false;
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ErrorCode);
                    Console.WriteLine("SocketException : {0}", se.SocketErrorCode);
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public void Login()
        {

        }

    }
}