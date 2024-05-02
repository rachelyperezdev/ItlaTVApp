using ItlaTVApp.Core.Domain.Common;

namespace ItlaTVApp.Core.Domain.Entities
{
    public class Productora : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Serie>? Series { get; set; }
    }
}
