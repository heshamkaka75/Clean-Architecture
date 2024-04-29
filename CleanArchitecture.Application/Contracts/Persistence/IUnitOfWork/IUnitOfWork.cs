using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Persistence.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenderRepository Genders { get; }
        Task SaveAsync();
    }
}
