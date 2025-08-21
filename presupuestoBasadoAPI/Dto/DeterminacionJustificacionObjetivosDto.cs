namespace presupuestoBasadoAPI.Dto
{
    public class DeterminacionJustificacionObjetivosDto
    {
        public int Id { get; set; }
        public string ObjetivosEspecificos { get; set; } = string.Empty;
        public string RelacionOtrosProgramas { get; set; } = string.Empty;
    }
}
