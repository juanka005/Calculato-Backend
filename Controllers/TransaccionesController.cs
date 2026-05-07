using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calculato.Api.Data;

namespace Calculato.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TransaccionesController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> Get() => await _context.Transacciones.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Transaccion>> Post(Transaccion t)
        {
            _context.Transacciones.Add(t);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = t.Id }, t);
        }
    }
}