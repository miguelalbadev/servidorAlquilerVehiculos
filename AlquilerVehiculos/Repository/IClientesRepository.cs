using AlquilerVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculos.Repository {
    public interface IClientesRepository {

        Clientes Create(Clientes clientes);
        Clientes Read(long id);
        IQueryable<Clientes> ReadAll();
        void Update(long id, Clientes clientes);
        Clientes Delete(long id);
    }
}
