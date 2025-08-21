namespace presupuestoBasadoAPI.Dto
{
    public class ProgramaSocialDto
    {
        public bool EsProgramaSocial { get; set; }
        public List<CategoriaDto> Categorias { get; set; } = new();
    }
}
