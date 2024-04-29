using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using CleanArchitecture.Application.Contracts.Persistence.IUnitOfWork;
using CleanArchitecture.Persistence.Data;
using CleanArchitecture.Persistence.Repository;

namespace CleanArchitecture.Persistence.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IGenderRepository Genders { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Genders = new GenderRepository(_dbContext);

        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
