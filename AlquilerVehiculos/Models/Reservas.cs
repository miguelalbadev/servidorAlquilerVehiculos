using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculos.Models {
    public class Reservas {
        
        public long Id { get; set; }
        public DateTime FechaRecogida { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string LugarRecogida { get; set; }
        public string LugarEntrega { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Vehiculos Vehiculo { get; set; }
        public long ClienteId { get; set; }
        public long VehiculoId { get; set; }

    }
}