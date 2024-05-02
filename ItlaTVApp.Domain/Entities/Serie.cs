using ItlaTVApp.Core.Domain.Common;

namespace ItlaTVApp.Core.Domain.Entities
{
    public class Serie : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public string URLImagen { get; set; }
        public string URLVideo { get; set; }
        public Productora? Productora { get; set; }
        public Genero? GeneroPrimario { get; set; }
        public Genero? GeneroSecundario { get; set; }
        public int ProductoraId { get; set; }
        public int GeneroPrimarioId { get; set; }
        public int? GeneroSecundarioId { get; set; }
    }
}
