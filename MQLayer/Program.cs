using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using MQHandling;
using Shared;

namespace MQLayer
{
    class Program
    {
        static void Main(string[] args)
        {

            //Namen der MessageQueue beim Constructor mitgeben (sollte einzigartiger Name sein)
            MQHandler<PersonenBeschreibung> handler = new MQHandler<PersonenBeschreibung>("entries");
            //Kommt aus der DataLayer Klasse
            Provider prov = new Provider();

            while (true)
            {
                //Methode der DataLayerklasse die auf Datenbank zugreift
                prov.Insert(handler.Read());
            }
        }
    }
}
