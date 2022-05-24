using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. create socket
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2. bind ip and port number 192.168.1.86
            IPAddress ipaddress = new IPAddress(new byte[] { 192,168,1,86});
            EndPoint point = new IPEndPoint(ipaddress,7788);
            tcpServer.Bind(point);//Apply to the operating system for an available ip and port number for communication
            //3. Start to listen (Waiting for client to connect)
            tcpServer.Listen(100);
            Console.WriteLine("start listening");

            Socket clientSocket = tcpServer.Accept(); //pause the current thread, until next client connected, then execute the code below

            Console.WriteLine("Client connected");
            //using return socket to communicate with client
            string message = "hello 欢迎您";
            byte[] data = Encoding.UTF8.GetBytes(message); //convert string into byte array
            clientSocket.Send(data);
            Console.WriteLine("Sent msg to client");

            byte[] data2 = new byte[1024]; // create a byte array as container
            int length = clientSocket.Receive(data2); //receive data from client
            string message2 = Encoding.UTF8.GetString(data2,0,length); // convert byte[] to string

            Console.WriteLine("Message from client "+ message2);
            Console.ReadKey();

        }
    }
}
