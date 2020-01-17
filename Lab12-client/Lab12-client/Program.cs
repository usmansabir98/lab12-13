using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;


namespace Lab12_client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 2055);
            try
            {
                Stream s = client.GetStream();
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                Console.WriteLine(sr.ReadLine());
                while (true)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    sw.WriteLine(name);
                    if (name == "") break;
                    Console.WriteLine(sr.ReadLine());
                }
                s.Close();
            }
            finally
            {
                // code in finally block is guranteed 
                // to execute irrespective of 
                // whether any exception occurs or does 
                // not occur in the try block
                client.Close();
            }

        }
    }
}
