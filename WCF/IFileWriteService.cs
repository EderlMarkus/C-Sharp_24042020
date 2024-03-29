﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IFileWriteService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IFileWriteService
    {
        [OperationContract]
        void WriteInFile(string data);
    }
}
