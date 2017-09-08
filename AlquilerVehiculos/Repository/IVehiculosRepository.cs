using AlquilerVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculos.Repository {
    public interface IVehiculosRepository {

        Vehiculos Create(Vehiculos vehiculos);
        Vehiculos Read(long id);
        IQueryable<Vehiculos> ReadAll();
        void Update(long id, Vehiculos vehiculos);
        Vehiculos Delete(long id);
    }
}
