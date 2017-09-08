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
    public class ClientesController : ApiController
    {
        private IClientesService clientesService;

        public ClientesController(IClientesService clientesService) {
            this.clientesService = clientesService;
        }

        // GET: api/Clientes
        public IQueryable<Clientes> GetClientes()
        {
            return clientesService.ReadAll();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult GetClientes(long id)
        {
            Clientes clientes = clientesService.Read(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientes(long id, Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.Id)
            {
                return BadRequest();
            }
            
            try
            {
                clientesService.Update(id, clientes);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                return NotFound();
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult PostClientes(Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            clientes = clientesService.Create(clientes);            

            return CreatedAtRoute("DefaultApi", new { id = clientes.Id }, clientes);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult DeleteClientes(long id)
        {
            Clientes cliente;
            try {
                cliente = clientesService.Delete(id);
            }
            catch (NoEncontradoException e) {
                return NotFound();
            }
            return Ok(cliente);
        }

       
    }
}