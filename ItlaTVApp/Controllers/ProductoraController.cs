using ItlaTVApp.Core.Application.Interfaces.Services;
using ItlaTVApp.Core.Application.ViewModels.Productoras;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTVApp.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly IProductoraService _productoraService;

        public ProductoraController(IProductoraService productoraService)
        {
            _productoraService = productoraService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productoraService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            SaveProductoraViewModel vm = new();
            return View("SaveProductora", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }

            await _productoraService.Add(vm);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            SaveProductoraViewModel vm = await _productoraService.GetByIdSaveViewModel(id);
            return View("SaveProductora", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }

            await _productoraService.Update(vm);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            SaveProductoraViewModel vm = await _productoraService.GetByIdSaveViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productoraService.Delete(id);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }
    }
}
