using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. create socket
            Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2. initiate to build the connection's request
            IPAddress ipaddress = IPAddress.Parse("192.168.1.86");
            EndPoint point = new IPEndPoint(ipaddress, 7788);
            tcpClient.Connect(point);//via ip & port number, locate a server to connect
            byte[] data = new byte[1024];
            int length = tcpClient.Receive(data); // byte[], to receive the data
            //length return how many byte of data its return;
            string message = Encoding.UTF8.GetString(data, 0, length); //convert received data into string
            Console.WriteLine(message);


            //send msg to server
            string messge2 = Console.ReadLine(); //read user input
            tcpClient.Send(Encoding.UTF8.GetBytes(messge2)); //convert string to Byte[] then send to server

            Console.ReadKey();
        }
    }
}
