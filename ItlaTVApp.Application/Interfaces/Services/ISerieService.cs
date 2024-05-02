using ItlaTVApp.Core.Application.ViewModels.Series;

namespace ItlaTVApp.Core.Application.Interfaces.Services
{
    public interface ISerieService : IGenericService<SaveSerieViewModel, SerieViewModel>
    {
        Task<List<SerieViewModel>> GetAllViewModelWithFilters(FilterSerieViewModel filters);
    }
}
