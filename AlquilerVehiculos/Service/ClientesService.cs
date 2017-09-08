using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlquilerVehiculos.Models;
using AlquilerVehiculos.Repository;

namespace AlquilerVehiculos.Service {
    public class ClientesService : IClientesService {

        private IClientesRepository clientesRepository;

        public ClientesService(IClientesRepository clientesRepository) {
            this.clientesRepository = clientesRepository;
        }

        public Clientes Create(Clientes clientes) {
            return clientesRepository.Create(clientes);
        }

        public Clientes Delete(long id) {
            return clientesRepository.Delete(id);
        }

        public Clientes Read(long id) {
            return clientesRepository.Read(id);
        }

        public IQueryable<Clientes> ReadAll() {
            IQueryable<Clientes> cliente;
            cliente = clientesRepository.ReadAll();
            return cliente;
        }

        public void Update(long id, Clientes clientes) {
            clientesRepository.Update(id, clientes);
        }
    }
}