using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlquilerVehiculos.Models;
using AlquilerVehiculos.Excepciones;
using System.Data.Entity;

namespace AlquilerVehiculos.Repository {
    public class ClientesRespository : IClientesRepository {

        public Clientes Create(Clientes clientes) {
            return ApplicationDbContext.applicationDbContext.Clientes.Add(clientes);
        }

        public Clientes Delete(long id) {
            Clientes cliente = ApplicationDbContext.applicationDbContext.Clientes.Find(id);
            if (cliente == null) {
                throw new NoEncontradoException("No se ha encontrado la entidad a eliminar");
            }
            ApplicationDbContext.applicationDbContext.Clientes.Remove(cliente);
            return cliente;
        }

        public Clientes Read(long id) {
            return ApplicationDbContext.applicationDbContext.Clientes.Find(id);
        }

        public IQueryable<Clientes> ReadAll() {
            IList<Clientes> clientes = new List<Clientes>(ApplicationDbContext.applicationDbContext.Clientes);
            return clientes.AsQueryable();
        }

        public void Update(long id, Clientes clientes) {
            if (ApplicationDbContext.applicationDbContext.Clientes.Count(e => e.Id == clientes.Id) == 0) {
                throw new NoEncontradoException("No se ha encontrado la entidad a actualizar");
            }
            ApplicationDbContext.applicationDbContext.Entry(clientes).State = EntityState.Modified;
        }
    }
}