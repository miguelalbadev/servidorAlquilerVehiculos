using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculos.Models {
    public class Clientes {
               
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCarnet { get; set; }
        public int PuntosCarnet { get; set; }

        //public virtual ICollection<Reservas> Reservas { get; set; }

    }
}