namespace presupuestoBasadoAPI.Models
{
    public class EfectoSuperior
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
