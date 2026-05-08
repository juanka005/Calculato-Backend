using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calculato.Api.Data;

namespace Calculato.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductosController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get() => await _context.Productos.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto p)
        {
            _context.Productos.Add(p);
            await _context.SaveChangesAsync();
            return Ok(p);
        }

        // En ProductosController.cs
        [HttpPut("actualizar-stock")]
        public async Task<IActionResult> UpdateStock([FromBody] StockUpdateDto data)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Nombre == data.Nombre);
            if (producto == null) return NotFound();

            producto.Stock -= data.Cantidad; // Restamos lo vendido
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        // Clase de apoyo (puedes ponerla al final del archivo)
        public class StockUpdateDto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("sumar-stock")]
        public async Task<IActionResult> AddStock([FromBody] StockUpdateDto data)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Nombre == data.Nombre);
            if (producto == null) return NotFound();

            producto.Stock += data.Cantidad; // 🚀 AQUÍ SUMAMOS
            await _context.SaveChangesAsync();
            return Ok(producto);
        }
    }
}