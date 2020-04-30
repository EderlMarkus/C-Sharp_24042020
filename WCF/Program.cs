using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Jeder Service muss eigene host.Open Methode haben
            ServiceHost host = new ServiceHost(typeof(MeinTollerService));
            host.Open();

            ServiceHost hostFileWriter = new ServiceHost(typeof(FileWriteService));
            hostFileWriter.Open();

            Console.WriteLine("Service startet ..");
            Console.ReadLine();
        }
    }
}
