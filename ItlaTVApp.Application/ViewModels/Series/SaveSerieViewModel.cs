using ItlaTVApp.Core.Application.ViewModels.Generos;
using ItlaTVApp.Core.Application.ViewModels.Productoras;
using System.ComponentModel.DataAnnotations;

namespace ItlaTVApp.Core.Application.ViewModels.Series
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El enlace de la imagen es requerido.")]
        public string URLImagen { get; set; }
        [Required(ErrorMessage = "El enlace del video es requerido.")]
        public string URLVideo { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar la productora.")]
        public int ProductoraId { get; set; }
        public List<ProductoraViewModel>? Productora { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el género primario de la serie.")]
        public int GeneroPrimarioId { get; set; }
        public List<GeneroViewModel>? GenerosPrimarios { get; set; }

        public int? GeneroSecundarioId { get; set; }
        public List<GeneroViewModel>? GenerosSecundarios { get; set; }
    }
}
