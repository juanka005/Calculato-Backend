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
    }
}