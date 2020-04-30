using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using MQHandling;
using Shared;

namespace MQLayerDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            MQHandler<PersonenBeschreibung> handler = new MQHandler<PersonenBeschreibung>("entriesDelete");
            Provider prov = new Provider();

            while (true)
            {
                prov.deleteById(handler.Read().Id.ToString());
            }
        }
    }
}
