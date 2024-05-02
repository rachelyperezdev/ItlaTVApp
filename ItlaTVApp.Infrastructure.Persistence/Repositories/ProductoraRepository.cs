using ItlaTVApp.Core.Application.Interfaces.Repositories;
using ItlaTVApp.Core.Domain.Entities;
using ItlaTVApp.Infrastructure.Persistence.Contexts;

namespace ItlaTVApp.Infrastructure.Persistence.Repositories
{
    public class ProductoraRepository : GenericRepository<Productora>, IProductoraRepository
    {
        private readonly ApplicationContext _dbContext;
        public ProductoraRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
