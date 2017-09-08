using AlquilerVehiculos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlquilerVehiculos.Models;

namespace AlquilerVehiculos.Service {
    public class VehiculosService :IVehiculosService{

        private IVehiculosRepository vehiculosRepository;

        public VehiculosService(IVehiculosRepository vehiculosRepository) {
            this.vehiculosRepository = vehiculosRepository;
        }

        public Vehiculos Create(Vehiculos vehiculos) {
            return vehiculosRepository.Create(vehiculos);
        }

        public Vehiculos Delete(long id) {
            return vehiculosRepository.Delete(id);
        }

        public Vehiculos Read(long id) {
            return vehiculosRepository.Read(id);
        }

        public IQueryable<Vehiculos> ReadAll() {
            IQueryable<Vehiculos> vehiculos;
            vehiculos = vehiculosRepository.ReadAll();
            return vehiculos;
        }

        public void Update(long id, Vehiculos vehiculos) {
            vehiculosRepository.Update(id, vehiculos);
        }
    }
}