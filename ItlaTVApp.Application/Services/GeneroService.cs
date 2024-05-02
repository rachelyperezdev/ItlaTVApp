using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Core.Application.Interfaces.Services;
using ItlaTVApp.Core.Application.ViewModels.Generos;
using ItlaTVApp.Core.Domain.Entities;

namespace ItlaTVApp.Core.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly ISerieRepository _serieRepository;
        public GeneroService(IGeneroRepository generoRepository, ISerieRepository serieRepository)
        {
            _generoRepository = generoRepository;
            _serieRepository = serieRepository;
        }
        public async Task Add(SaveGeneroViewModel vm)
        {
            Genero genero = new();
            genero.Nombre = vm.Nombre;

            await _generoRepository.AddAsync(genero);
        }

        public async Task Delete(int id)
        {
            var serieList = await _serieRepository.GetAllAsync();
            var seriesConGeneroSecundario = serieList.Where(serie => serie.GeneroSecundarioId == id);

            foreach (var serie in seriesConGeneroSecundario)
            {
                serie.GeneroSecundarioId = null;
                await _serieRepository.UpdateAsync(serie);
            }

            var genero = await _generoRepository.GetByIdAsync(id);
            await _generoRepository.DeleteAsync(genero);
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generoList = await _generoRepository.GetAllAsync();

            return generoList.Select(genero => new GeneroViewModel
            {
                Id = genero.Id,
                Nombre = genero.Nombre
            }).ToList();
        }

        public async Task<SaveGeneroViewModel> GetByIdSaveViewModel(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);

            SaveGeneroViewModel vm = new();

            vm.Id = genero.Id;
            vm.Nombre = genero.Nombre;

            return vm;
        }

        public async Task Update(SaveGeneroViewModel vm)
        {
            Genero genero = new();
            genero.Id = vm.Id;
            genero.Nombre = vm.Nombre;

            await _generoRepository.UpdateAsync(genero);
        }
    }
}
