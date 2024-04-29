using CleanArchitecture.Application.Dtos.GenderDtos;
using CleanArchitecture.Domain.Common;
using MediatR;

namespace CleanArchitecture.Application.Features.Genders.Requests.Commands
{
    public class CreateGenderCommand : IRequest<BaseResponse>
    {
        public CreateGenderDto CreateGenderDto { get; set; }
    }
}
