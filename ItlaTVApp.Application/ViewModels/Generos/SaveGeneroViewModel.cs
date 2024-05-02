using System.ComponentModel.DataAnnotations;

namespace ItlaTVApp.Core.Application.ViewModels.Generos
{
    public class SaveGeneroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del género es requerido.")]
        public string Nombre { get; set; }
    }
}
