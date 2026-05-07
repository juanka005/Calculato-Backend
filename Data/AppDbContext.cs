using Microsoft.EntityFrameworkCore;

namespace Calculato.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Transaccion> Transacciones { get; set; }
    }

    public class Transaccion
    {
        public int Id { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal ItbisPagado { get; set; }
        public decimal Ganancia { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string MetodoPago { get; set; } = "Efectivo";
        public string Ncf { get; set; } = string.Empty;
        public string RncCliente { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool EstaAnulada { get; set; } = false;
        public string MotivoAnulacion { get; set; } = string.Empty;
    }
}