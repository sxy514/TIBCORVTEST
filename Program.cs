using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TIBCO.Rendezvous;

namespace TIBCOSend
{
    /// <summary>
    ///  测试TIBCO Rendezvous 发送消息de 
    /// </summary>
    internal class Program
    {
        public void Run()
        {
            TIBCO.Rendezvous.Environment.Open();
            var subject = "ME.TEST";
            var network = "192.168.43.1";
            var port = "7500";
            var transport = new NetTransport(port, network, port);
            Console.WriteLine("Server running..");
            Console.WriteLine("Press x to exit or any other key to send message");
            int i = 0;
            while (true)
            {
                var m = new Message();
                m.SendSubject = subject;
                m.AddField("Test", "TestValue" + i++);
                transport.Send(m);
                var line = Console.ReadLine();
                if (line.ToUpper().Equals("X")) break;
            }
            TIBCO.Rendezvous.Environment.Close();
        }
        static void Main(string[] args)
        {
            new Program().Run();
        }


    }
}
