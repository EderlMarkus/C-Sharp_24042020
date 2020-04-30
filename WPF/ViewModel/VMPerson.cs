using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.TeamFoundation.Server;
using MQHandling;
using Shared;
using WPF.Command;

namespace WPF.ViewModel
{

            

              
              
    class VMPerson
    {
        public MVVMCommand BtnWrite { get; set; }

        public MVVMCommand MyProperty { get; set; }

        public MVVMCommand BtnUpdate { get; set; }
        public MVVMCommand BtnDeleteById { get; set; }
        public MVVMCommand BtnUpdateById { get; set; }

        
        public string Name { get; set; }
        public int Alter { get; set; }
        public System.Guid Id { get; set; }
        public string Wohnort { get; set; }
        public string Blutgruppe { get; set; }
        public int isEinLanger { get; set; }

        public ObservableCollection<PersonenBeschreibung> Personen { get; set; }
        MQHandler<PersonenBeschreibung> handler;
        MQHandler<PersonenBeschreibung> handlerDelete;
        MQHandler<PersonenBeschreibung> handlerUpdate;

        ServiceReference1.MeinTollerServiceClient client;
        FileWriterService.FileWriteServiceClient clientFileWriter;

        public VMPerson()

        {
            
            handler = new MQHandler<PersonenBeschreibung>("entries");
            handlerDelete = new MQHandler<PersonenBeschreibung>("entriesDelete");
            handlerUpdate = new MQHandler<PersonenBeschreibung>("entriesUpdate");

            client = new ServiceReference1.MeinTollerServiceClient();
            clientFileWriter = new FileWriterService.FileWriteServiceClient();

            this.Personen = client.getPersonenBeschreibung();

            BtnWrite = new MVVMCommand((param) => { WriteToQueue(); }, (param) => { return true; });

            BtnUpdate = new MVVMCommand((param) => { updatePersonen(); }, (param) => { return true; });
            BtnDeleteById = new MVVMCommand((param) => { deleteById(param); }, (param) => { return true; });
            BtnUpdateById = new MVVMCommand((param) => { updateById(param); }, (param) => { return true; });


        }

        private void updateById(object param) {

            PersonenBeschreibung temp = new PersonenBeschreibung();

            if (param.GetType() == temp.GetType())
            {
                temp = (PersonenBeschreibung) param;

                MessageBox.Show("Updating " + temp.Name);
                //todo: schicke update an message queue
                handlerUpdate.Send(temp);

                //Write Update in File
                clientFileWriter.WriteInFile("Updated " + temp.Id);
            }



        }

        private void deleteById(object param)
        {
            MessageBox.Show("Deleting " + param.ToString());

            //Delete directly by calling WCF
            //client.deleteById(param.ToString());
            

            //Delete with MQ
            PersonenBeschreibung temp = getPersonById(param.ToString());
            handlerDelete.Send(temp);

            //remove from Observablecollection for WPF
            removePersonById(param.ToString());


        }

        private PersonenBeschreibung getPersonById(string Id)
        {
            foreach (var person in Personen)
            {
                string personId = person.Id.ToString();
                if (personId == Id)
                {
                    return person;
                }
            }

            return null;

        }
        private void removePersonById(string Id)
        {
            foreach (var person in Personen)
            {
                if (person.Id.ToString() == Id)
                {
                    Personen.Remove(person);
                    return;
                }
            }
        }

        private void WriteToQueue()
        {
            MessageBox.Show("Wird abgeschickt!");
            handler.Send(new PersonenBeschreibung()
            {
                Alter = this.Alter,
                Name = this.Name,
                Blutgruppe = this.Blutgruppe,
                Id = Guid.NewGuid(),
                isEinLanger = this.isEinLanger,
                Wohnort = this.Wohnort
            });
            updatePersonen();
        }

        private void updatePersonen()
        {
            this.Personen.Clear();
            ObservableCollection<PersonenBeschreibung> tempPersBesch = client.getPersonenBeschreibung();
            foreach (var item in tempPersBesch)
            {
                this.Personen.Add(item);
            }
        }


    }
}
