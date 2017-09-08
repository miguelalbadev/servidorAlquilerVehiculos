using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AlquilerVehiculos.Models;
using AlquilerVehiculos.Service;
using AlquilerVehiculos.Excepciones;
using System.Web.Http.Cors;

namespace AlquilerVehiculos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehiculosController : ApiController
    {
        private IVehiculosService vehiculosService;

        public VehiculosController (IVehiculosService vehiculosService) {
            this.vehiculosService = vehiculosService;
        }

        // GET: api/Vehiculos
        public IQueryable<Vehiculos> GetVehiculos()
        {
            return vehiculosService.ReadAll();
        }

        // GET: api/Vehiculos/5
        [ResponseType(typeof(Vehiculos))]
        public IHttpActionResult GetVehiculos(long id)
        {
            Vehiculos vehiculos = vehiculosService.Read(id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return Ok(vehiculos);
        }

        // PUT: api/Vehiculos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculos(long id, Vehiculos vehiculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiculos.Id)
            {
                return BadRequest();
            }

            try
            {
                vehiculosService.Update(id, vehiculos);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehiculos
        [ResponseType(typeof(Vehiculos))]
        public IHttpActionResult PostVehiculos(Vehiculos vehiculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vehiculos = vehiculosService.Create(vehiculos);

            return CreatedAtRoute("DefaultApi", new { id = vehiculos.Id }, vehiculos);
        }

        // DELETE: api/Vehiculos/5
        [ResponseType(typeof(Vehiculos))]
        public IHttpActionResult DeleteVehiculos(long id)
        {
            Vehiculos vehiculo;
            try {
                vehiculo = vehiculosService.Delete(id);
            }
            catch (NoEncontradoException e) {
                return NotFound();
            }
            return Ok(vehiculo);
        }
                
    }
}