using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Persistence.BaseRepository;
using CleanArchitecture.Persistence.Data;

namespace CleanArchitecture.Persistence.Repository
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GenderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
