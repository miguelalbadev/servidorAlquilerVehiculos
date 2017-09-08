using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlquilerVehiculos.Models;
using AlquilerVehiculos.Repository;

namespace AlquilerVehiculos.Service {
    public class ReservasService : IReservasService {

        private IReservasRepository reservasRepository;

        public ReservasService (IReservasRepository reservasRepository) {
            this.reservasRepository = reservasRepository;
        }
        public Reservas Create(Reservas reservas) {
            return reservasRepository.Create(reservas);
        }

        public Reservas Delete(long id) {
            return reservasRepository.Delete(id);
        }

        public Reservas Read(long id) {
            return reservasRepository.Read(id);
        }

        public IQueryable<Reservas> ReadAll() {
            IQueryable<Reservas> reservas;
            reservas = reservasRepository.ReadAll();
            return reservas;
        }

        public void Update(long id, Reservas reservas) {
            reservasRepository.Update(id, reservas);
        }
    }
}