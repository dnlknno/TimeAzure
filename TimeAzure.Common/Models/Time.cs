using System;

namespace TimeAzure.Common.Models
{
    public class Time
    {
        public int IdEmpleado { get; set; }

        public DateTime FechaHora { get; set; }

        public int Tipo { get; set; }

        public bool Consolidado { get; set; }
    }
}
