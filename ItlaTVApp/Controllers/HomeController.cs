using ItlaTVApp.Core.Application.Interfaces.Services;
using ItlaTVApp.Core.Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTVApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IProductoraService _productoraService;
        private readonly IGeneroService _generoService;

        public HomeController(ISerieService serieService, IProductoraService productoraService, IGeneroService generoService)
        {
            _serieService = serieService;
            _productoraService = productoraService;
            _generoService = generoService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            ViewBag.Generos = await _generoService.GetAllViewModel();

            ViewBag.BusquedaNombre = vm.Nombre;

            return View(await _serieService.GetAllViewModelWithFilters(vm));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _serieService.GetByIdSaveViewModel(id));
        }
    }
}
