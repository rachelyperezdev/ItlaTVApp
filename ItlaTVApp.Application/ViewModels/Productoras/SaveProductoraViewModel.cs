using System.ComponentModel.DataAnnotations;

namespace ItlaTVApp.Core.Application.ViewModels.Productoras
{
    public class SaveProductoraViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la productora es requerido.")]
        public string Nombre { get; set; }
    }
}
