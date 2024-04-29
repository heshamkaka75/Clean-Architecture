using CleanArchitecture.Application.Contracts.Persistence.IBaseRepository;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Contracts.Persistence.IRepository
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
    }
}
