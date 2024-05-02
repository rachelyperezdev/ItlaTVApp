using ItlaTVApp.Core.Domain.Common;

namespace ItlaTVApp.Core.Domain.Entities
{
    public class Genero : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Serie>? SeriesPrimarias { get; set; }
        public ICollection<Serie>? SeriesSecundarias { get; set; }
    }
}
