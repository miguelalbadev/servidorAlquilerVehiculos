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
    public class ReservasController : ApiController
    {
        private IReservasService reservasService;

        public ReservasController(IReservasService reservasService) {
            this.reservasService = reservasService;
        }

        // GET: api/Reservas
        public IQueryable<Reservas> GetReservas()
        {
            return reservasService.ReadAll();
        }

        // GET: api/Reservas/5
        [ResponseType(typeof(Reservas))]
        public IHttpActionResult GetReservas(long id)
        {
            Reservas reservas = reservasService.Read(id);
            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);
        }

        // PUT: api/Reservas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservas(long id, Reservas reservas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservas.Id)
            {
                return BadRequest();
            }
                        
            try
            {
                reservasService.Update(id, reservas);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reservas
        [ResponseType(typeof(Reservas))]
        public IHttpActionResult PostReservas(Reservas reservas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            reservas = reservasService.Create(reservas);
            return CreatedAtRoute("DefaultApi", new { id = reservas.Id }, reservas);
        }

        // DELETE: api/Reservas/5
        [ResponseType(typeof(Reservas))]
        public IHttpActionResult DeleteReservas(long id)
        {
            Reservas reservas;
            try {
                reservas = reservasService.Delete(id);
            }
            catch (NoEncontradoException e) {
                return NotFound();
            }
            return Ok(reservas);
        }

        
    }
}