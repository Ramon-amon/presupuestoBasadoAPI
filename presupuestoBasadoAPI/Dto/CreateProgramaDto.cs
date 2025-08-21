namespace presupuestoBasadoAPI.Dto
{
    public class CreateProgramaDto
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string UnidadResponsable { get; set; }
        public string UnidadesIntegrantes { get; set; }
    }
}
