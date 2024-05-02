using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Core.Domain.Entities;
using ItlaTVApp.Infrastructure.Persistence.Contexts;

namespace ItlaTVApp.Infrastructure.Persistence.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        private readonly ApplicationContext _dbContext;
        public SerieRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
