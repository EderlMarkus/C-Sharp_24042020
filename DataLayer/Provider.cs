using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataLayer
{
    //Hinzufügen -> Neues Element -> ADO.NET Entity Data Model
    //EF Designer aus Datenbank
    // Neue Verbindung
    // Servername: (localdb)\MSSQLLocalDB

    public class Provider
    {
        //Findet man in App.Config
        //<add name="MeineHeutigenEntities" ...
        MeineHeutigenEntities db = new MeineHeutigenEntities();

        public List<Person> getPersonen()
        {
            var query = (from Person in db.Person
                         select Person);

            return query.ToList();
        }

        public List<PersonenDetails> getPersonenDetails()
        {
            var query = (from PersonenDetail in db.PersonenDetails
                         select PersonenDetail);
            return query.ToList();
        }

        public List<PersonenDetails> getDetailsForPerson(Guid id)
        {
            var query = (from PersonenDetail in db.PersonenDetails
                         where PersonenDetail.Id == id
                         select PersonenDetail);

            return query.ToList();
        }

        public void updateById(PersonenBeschreibung data)
        {
            Person tempPerson = getPersonById(data.Id.ToString());
            PersonenDetails tempDetails = getPersonDetailsById(data.Id.ToString());

            tempPerson.Alter = data.Alter;
            tempPerson.Name = data.Name;

            tempDetails.Blutgruppe = data.Blutgruppe;
            tempDetails.isEinLanger = data.isEinLanger;
            tempDetails.Wohnort = data.Wohnort;

            db.SaveChanges();
        }

        public void deleteById(string Id)
        {
            db.Person.Remove(getPersonById(Id));
            db.PersonenDetails.Remove(getPersonDetailsById(Id));
            db.SaveChanges();
        }

        private Person getPersonById(string Id)
        {
            foreach (var Person in db.Person)
            {
                if (Person.Id.ToString() == Id)
                {
                    return Person;
                }
            }

            return null;
        }

        private PersonenDetails getPersonDetailsById(string Id)
        {
            foreach (var PersonenDetail in db.PersonenDetails)
            {
                if (PersonenDetail.Id.ToString() == Id)
                {
                    return PersonenDetail;
                }
            }

            return null;
        }
        public void Insert(PersonenBeschreibung entry)
        {
            Guid id = Guid.NewGuid();
            db.Person.Add(new Person()
            {
                Id = id,
                Name = entry.Name,
                Alter = entry.Alter,
               
            });
            db.SaveChanges();

            db.PersonenDetails.Add(new PersonenDetails()
            {
                Id = id,
                Blutgruppe = entry.Blutgruppe,
                Wohnort = entry.Wohnort,
                isEinLanger = entry.isEinLanger
            });

            db.SaveChanges();
        }
    }
}
