﻿namespace presupuestoBasadoAPI.Dto
{
    public class AntecedenteDto
    {
        public int Id { get; set; }
        public string DescripcionPrograma { get; set; } = string.Empty;
        public string ContextoHistoricoNormativo { get; set; } = string.Empty;
        public string ProblematicaOrigen { get; set; } = string.Empty;
        public string ExperienciasPrevias { get; set; } = string.Empty;
    }
}
