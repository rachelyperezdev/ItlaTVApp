using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Core.Application.Interfaces.Services;
using ItlaTVApp.Core.Application.ViewModels.Series;
using ItlaTVApp.Core.Domain.Entities;

namespace ItlaTVApp.Core.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task Add(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Nombre = vm.Nombre;
            serie.URLImagen = vm.URLImagen;
            serie.URLVideo = vm.URLVideo;
            serie.ProductoraId = vm.ProductoraId;
            serie.GeneroPrimarioId = vm.GeneroPrimarioId;
            serie.GeneroSecundarioId = vm.GeneroSecundarioId == 0 ? null : vm.GeneroSecundarioId;

            await _serieRepository.AddAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Productora", "GeneroPrimario", "GeneroSecundario" });

            return serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Nombre = serie.Nombre,
                URLImagen = serie.URLImagen,
                Productora = serie.Productora.Nombre,
                GeneroPrimario = serie.GeneroPrimario.Nombre,
                GeneroSecundario = serie.GeneroSecundario != null ? serie.GeneroSecundario.Nombre : null
            }).ToList();
        }

        public async Task<List<SerieViewModel>> GetAllViewModelWithFilters(FilterSerieViewModel filters)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Productora", "GeneroPrimario", "GeneroSecundario" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Nombre = serie.Nombre,
                URLImagen = serie.URLImagen,
                ProductoraId = serie.ProductoraId,
                Productora = serie.Productora.Nombre,
                GeneroPrimarioId = serie.GeneroPrimarioId,
                GeneroPrimario = serie.GeneroPrimario.Nombre,
                GeneroSecundarioId = serie.GeneroSecundarioId,
                GeneroSecundario = serie.GeneroSecundario != null ? serie.GeneroSecundario.Nombre : null
            }).ToList();

            if (filters.ProductoraId != null)
            {
                listViewModels = listViewModels.Where(serie => serie.ProductoraId == filters.ProductoraId.Value).ToList();
            }

            if (filters.GeneroId != null)
            {
                listViewModels = listViewModels.Where(serie => serie.GeneroPrimarioId == filters.GeneroId.Value || serie.GeneroSecundarioId == filters.GeneroId.Value).ToList();
            }

            if (filters.Nombre != null)
            {
                listViewModels = listViewModels.Where(serie => serie.Nombre.ToUpper() == filters.Nombre.ToUpper()).ToList();
            }

            return listViewModels;
        }

        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            SaveSerieViewModel vm = new();
            vm.Id = serie.Id;
            vm.Nombre = serie.Nombre;
            vm.URLImagen = serie.URLImagen;
            vm.URLVideo = serie.URLVideo;
            vm.ProductoraId = serie.ProductoraId;
            vm.GeneroPrimarioId = serie.GeneroPrimarioId;
            vm.GeneroSecundarioId = serie.GeneroSecundarioId;

            return vm;
        }

        public async Task Update(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Id = vm.Id;
            serie.Nombre = vm.Nombre;
            serie.URLImagen = vm.URLImagen;
            serie.URLVideo = vm.URLVideo;
            serie.ProductoraId = vm.ProductoraId;
            serie.GeneroPrimarioId = vm.GeneroPrimarioId;
            serie.GeneroSecundarioId = vm.GeneroSecundarioId == 0 ? null : vm.GeneroSecundarioId;

            await _serieRepository.UpdateAsync(serie);
        }
    }
}
