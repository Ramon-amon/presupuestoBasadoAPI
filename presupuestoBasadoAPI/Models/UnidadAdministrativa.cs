namespace presupuestoBasadoAPI.Models
{
    public class UnidadAdministrativa
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string? Unidad { get; set; }

        public ICollection<ApplicationUser> Usuarios { get; set; }
    }
}
