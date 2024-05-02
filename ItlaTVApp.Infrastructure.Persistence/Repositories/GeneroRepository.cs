using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Core.Domain.Entities;
using ItlaTVApp.Infrastructure.Persistence.Contexts;

namespace ItlaTVApp.Infrastructure.Persistence.Repositories
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        private readonly ApplicationContext _dbContext;
        public GeneroRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
