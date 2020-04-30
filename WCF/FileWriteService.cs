using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "FileWriteService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    public class FileWriteService : IFileWriteService
    {
        public void WriteInFile(string data)
        {

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@".\data.txt", true))
            {
                file.WriteLine(data);
            }


        }
    }
}
