namespace ItlaTVApp.Core.Application.ViewModels.Series
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string URLImagen { get; set; }

        public int ProductoraId { get; set; }
        public string Productora { get; set; }
        public int GeneroPrimarioId { get; set; }
        public string GeneroPrimario { get; set; }
        public int? GeneroSecundarioId { get; set; }
        public string? GeneroSecundario { get; set; }
    }
}
