namespace presupuestoBasadoAPI.Models
{
    public class ProgramaSocial
    {
        public int Id { get; set; }

        // ¿Es programa social? (true/false)
        public bool EsProgramaSocial { get; set; }

        // Lista de categorías seleccionadas
        public ICollection<ProgramaSocialCategoria> Categorias { get; set; } = new List<ProgramaSocialCategoria>();
    }
}
