using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT");
            TcpClient client = new TcpClient();

            while (true)
                try
                {

                    client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
                    string str;
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    sw.AutoFlush = true;
                    str = Console.ReadLine();

                    Console.WriteLine("You : " + str);
                    sw.WriteLine(str);

                    //StreamReader sr = new StreamReader(client.GetStream());
                    //Console.WriteLine("Companion : " + sr.ReadLine());

                    //Console.WriteLine("Client : Пока");
                    //sw.WriteLine("Пока");
                    //Console.WriteLine("Server : " + sr.ReadLine());
                    


                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Connection error:\n" + ex.ToString());
                }
                catch (System.IO.IOException io)
                {
                    Console.WriteLine("IOException:\n" + io.ToString());
                }
                finally
                {
                    Console.ReadKey();
                    client.Close();
                }
        }
    }
}
