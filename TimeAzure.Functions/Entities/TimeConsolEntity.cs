using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace TimeAzure.Functions.Entities
{
    public class TimeConsolEntity : TableEntity
    {
        public int IdEmpleado { get; set; }

        public DateTime FechaHora { get; set; }

        public int Minutos { get; set; }
    }
}
