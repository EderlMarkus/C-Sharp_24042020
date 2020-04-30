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
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IMeinTollerService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IMeinTollerService
    {
        [OperationContract]
        List<Person> getPersonen();

        [OperationContract]
        List<PersonenBeschreibung> getPersonenBeschreibung();

        [OperationContract]
        void deleteById(string Id);


    }
}
