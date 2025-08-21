using System;

namespace presupuestoBasadoAPI.Models
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public int DisenoIntervencionPublicaId { get; set; }
        public DisenoIntervencionPublica DisenoIntervencionPublica { get; set; }

        public ICollection<Accion> Acciones { get; set; } = new List<Accion>();
        public ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
    }
}