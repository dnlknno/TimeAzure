using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeAzure.Functions.Entities
{
    public class TimeEntity : TableEntity
    {
        public int IdEmpleado { get; set; }

        public DateTime FechaHora { get; set; }

        public int Tipo { get; set; }

        public bool Consolidado { get; set; }
    }
}
