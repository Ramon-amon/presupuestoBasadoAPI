namespace presupuestoBasadoAPI.DTOs
{
    public class ComponenteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public List<string> Acciones { get; set; } = new();
        public List<string> Resultados { get; set; } = new();
    }
}
