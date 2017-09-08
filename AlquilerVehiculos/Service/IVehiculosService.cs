using AlquilerVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculos.Service {
    public interface IVehiculosService {

        Vehiculos Create(Vehiculos vehiculos);
        Vehiculos Read(long id);
        IQueryable<Vehiculos> ReadAll();
        void Update(long id, Vehiculos vehiculos);
        Vehiculos Delete(long id);
    }
}
