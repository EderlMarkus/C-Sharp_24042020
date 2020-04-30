using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer;
using Shared;

namespace WCF
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "MeinTollerService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    public class MeinTollerService : IMeinTollerService
    {
        Provider prov = new Provider();

        public void deleteById(string Id)
        {
            prov.deleteById(Id);
        }

        public List<Person> getPersonen()
        {
            return prov.getPersonen();
        }

        public List<PersonenBeschreibung> getPersonenBeschreibung()
        {
            List<Person> persons = getPersonen();
            List<PersonenBeschreibung> retList = new List<PersonenBeschreibung>();

            foreach (var person in persons)
            {
                List<PersonenDetails> tempDetails = prov.getDetailsForPerson(person.Id);
                retList.Add(new PersonenBeschreibung()
                {
                    Alter = person.Alter,
                    Blutgruppe = tempDetails.First().Blutgruppe,
                    Id = person.Id,
                    isEinLanger = tempDetails.First().isEinLanger,
                    Name = person.Name,
                    Wohnort = tempDetails.First().Wohnort
                });

            }

            return retList;


        }
    }
}
