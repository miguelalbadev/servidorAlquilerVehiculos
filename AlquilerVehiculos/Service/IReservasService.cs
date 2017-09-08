using AlquilerVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculos.Service {
    public interface IReservasService {

        Reservas Create(Reservas reservas);
        Reservas Read(long id);
        IQueryable<Reservas> ReadAll();
        void Update(long id, Reservas reservas);
        Reservas Delete(long id);
    }
}
