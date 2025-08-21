namespace presupuestoBasadoAPI.Models
{
    public class ProgramaSocialCategoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; // Ej: Alimentación, Salud
        public string Tipo { get; set; } = string.Empty;   // Directo o Indirecto

        // Relación con ProgramaSocial
        public int ProgramaSocialId { get; set; }
        public ProgramaSocial ProgramaSocial { get; set; }
    }
}
