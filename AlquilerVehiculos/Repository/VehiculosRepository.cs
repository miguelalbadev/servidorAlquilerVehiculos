using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlquilerVehiculos.Models;
using AlquilerVehiculos.Excepciones;
using System.Data.Entity;

namespace AlquilerVehiculos.Repository {
    public class VehiculosRepository : IVehiculosRepository {

        public Vehiculos Create(Vehiculos vehiculos) {
            return ApplicationDbContext.applicationDbContext.Vehiculos.Add(vehiculos);
        }

        public Vehiculos Delete(long id) {
            Vehiculos vehiculo = ApplicationDbContext.applicationDbContext.Vehiculos.Find(id);
            if (vehiculo == null) {
                throw new NoEncontradoException("No se ha encontrado la entidad a eliminar");
            }
            ApplicationDbContext.applicationDbContext.Vehiculos.Remove(vehiculo);
            return vehiculo;
        }

        public Vehiculos Read(long id) {
            return ApplicationDbContext.applicationDbContext.Vehiculos.Find(id);
        }

        public IQueryable<Vehiculos> ReadAll() {
            IList<Vehiculos> vehiculos = new List<Vehiculos>(ApplicationDbContext.applicationDbContext.Vehiculos);
            return vehiculos.AsQueryable();
        }

        public void Update(long id, Vehiculos vehiculos) {
            if (ApplicationDbContext.applicationDbContext.Vehiculos.Count(e => e.Id == vehiculos.Id) == 0) {
                throw new NoEncontradoException("No se ha encontrado la entidad a actualizar");
            }
            ApplicationDbContext.applicationDbContext.Entry(vehiculos).State = EntityState.Modified;
        }
    }
}