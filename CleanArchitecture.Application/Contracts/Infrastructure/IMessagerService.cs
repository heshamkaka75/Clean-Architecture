using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Common;
using System.Net.Mail;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IMessagerService
    {
        Task<BaseResponse> SendEmailAsync(SendEmailAsyncDto sendEmailAsyncDto);
    }
}
