using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculos.Models {
    public class Vehiculos {
                
        public long Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoVehiculo { get; set; }
        public string TipoCombustible { get; set; }
        public string NumeroPlazas { get; set; }
        public string TipoCambio { get; set; }
        public bool AireAcondicionado { get; set; }
        public float TarifaDiaria { get; set; }

        //public virtual ICollection<Reservas> Reservas { get; set; }
    }
}