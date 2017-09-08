using AlquilerVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculos.Repository {
    public interface IReservasRepository {

        Reservas Create(Reservas reservas);
        Reservas Read(long id);
        IQueryable<Reservas> ReadAll();
        void Update(long id, Reservas reservas);
        Reservas Delete(long id);
    }
}
