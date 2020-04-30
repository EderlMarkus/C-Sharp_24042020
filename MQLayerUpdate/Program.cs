using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using MQHandling;
using Shared;

namespace MQLayerUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            MQHandler<PersonenBeschreibung> handler = new MQHandler<PersonenBeschreibung>("entriesUpdate");
            Provider prov = new Provider();

            while (true)
            {
                prov.updateById(handler.Read());
            }
        }
    }
}
