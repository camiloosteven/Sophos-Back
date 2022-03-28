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
    public class VentaController : ControllerBase
    {
        private readonly SophosDBContext _context;
        public VentaController(SophosDBContext context)
        {
            _context = context;
        }
        // GET: api/<VentaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (SophosDBContext db = new SophosDBContext())
                {
                    var listVenta = db.Venta.ToList();
                    return Ok(listVenta);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            try
            {
                venta.FechaVenta = DateTime.Now;
                _context.Add(venta);
                await _context.SaveChangesAsync();
                DetalleVentum detalle = new DetalleVentum();
                detalle.IdVenta = venta.IdVenta;
                detalle.IdCliente = venta.IdCliente;
                detalle.IdProducto = venta.IdProducto;
                detalle.Cantidad = venta.Cantidad;
                detalle.Fecha = DateTime.Now;
                _context.Add(detalle);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Venta creada con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Venta venta)
        {
            try
            {
                if (id != venta.IdVenta)
                {
                    return NotFound();
                }
                _context.Update(venta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Venta actualizada con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var venta = await _context.Venta.FindAsync(id);
                if (venta == null)
                {
                    return NotFound();
                }
                _context.Venta.Remove(venta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Venta eliminada" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
