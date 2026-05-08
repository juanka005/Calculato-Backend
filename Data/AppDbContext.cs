using Microsoft.EntityFrameworkCore;

namespace Calculato.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Producto> Productos { get; set; }
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

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoBarras { get; set; } = string.Empty;
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}