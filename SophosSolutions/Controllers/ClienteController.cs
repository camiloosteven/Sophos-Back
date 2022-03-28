﻿using Microsoft.AspNetCore.Mvc;
using SophosSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SophosSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly SophosDBContext _context;
        public ClienteController(SophosDBContext context)
        {
            _context = context;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SophosDBContext db = new SophosDBContext())
                {
                    var listaClientes = db.Clientes.ToList();
                    return Ok(listaClientes);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id != cliente.IdCliente)
                {
                    return NotFound();
                }
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cliente actualizado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cliente eliminado" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
