using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlquilerVehiculos.Models;
using AlquilerVehiculos.Excepciones;
using System.Data.Entity;

namespace AlquilerVehiculos.Repository {
    public class ReservasRepository : IReservasRepository {

        public Reservas Create(Reservas reservas) {
            return ApplicationDbContext.applicationDbContext.Reservas.Add(reservas);
        }

        public Reservas Delete(long id) {
            Reservas reserva = ApplicationDbContext.applicationDbContext.Reservas.Find(id);
            if (reserva == null) {
                throw new NoEncontradoException("No se ha encontrado la entidad a eliminar");
            }
            ApplicationDbContext.applicationDbContext.Reservas.Remove(reserva);
            return reserva;
        }

        public Reservas Read(long id) {
            return ApplicationDbContext.applicationDbContext.Reservas.
                Include(r => r.Cliente).
                Include(r => r.Vehiculo).Where(r => r.Id == id).FirstOrDefault<Reservas>();
            
        }

        public IQueryable<Reservas> ReadAll() {
            IList<Reservas> reservas = new List<Reservas>(ApplicationDbContext.applicationDbContext.Reservas.
                Include(r => r.Cliente).
                Include(r => r.Vehiculo).ToList<Reservas>());
            return reservas.AsQueryable();
        }

        public void Update(long id, Reservas reservas) {
            if (ApplicationDbContext.applicationDbContext.Reservas.Count(e => e.Id == reservas.Id) == 0) {
                throw new NoEncontradoException("No se ha encontrado la entidad a actualizar");
            }
            ApplicationDbContext.applicationDbContext.Entry(reservas).State = EntityState.Modified;
        }
    }
    
}