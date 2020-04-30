using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PersonenBeschreibung
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Alter { get; set; }
        public string Wohnort { get; set; }
        public string Blutgruppe { get; set; }
        public Nullable<int> isEinLanger { get; set; }
    }
}
