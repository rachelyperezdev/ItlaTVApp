using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Core.Application.Interfaces.Services;
using ItlaTVApp.Core.Application.ViewModels.Productoras;
using ItlaTVApp.Core.Domain.Entities;

namespace ItlaTVApp.Core.Application.Services
{
    public class ProductoraService : IProductoraService
    {
        private readonly IProductoraRepository _productoraRepository;
        public ProductoraService(IProductoraRepository productoraRepository)
        {
            _productoraRepository = productoraRepository;
        }
        public async Task Add(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Nombre = vm.Nombre;

            await _productoraRepository.AddAsync(productora);
        }

        public async Task Delete(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);
            await _productoraRepository.DeleteAsync(productora);
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var productoraList = await _productoraRepository.GetAllAsync();

            return productoraList.Select(productora => new ProductoraViewModel
            {
                Id = productora.Id,
                Nombre = productora.Nombre
            }).ToList();
        }

        public async Task<SaveProductoraViewModel> GetByIdSaveViewModel(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);

            SaveProductoraViewModel vm = new();

            vm.Id = productora.Id;
            vm.Nombre = productora.Nombre;

            return vm;
        }

        public async Task Update(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Id = vm.Id;
            productora.Nombre = vm.Nombre;

            await _productoraRepository.UpdateAsync(productora);
        }
    }
}
