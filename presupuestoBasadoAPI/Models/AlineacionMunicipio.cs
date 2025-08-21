﻿namespace presupuestoBasadoAPI.Models
{
    public class AlineacionMunicipio
    {
        public int Id { get; set; }
        public string Acuerdo { get; set; }
        public string Objetivo { get; set; }
        public string Estrategia { get; set; }
        public string LineaAccion { get; set; }
        public string Ramo { get; set; } = string.Empty;

    }
}
