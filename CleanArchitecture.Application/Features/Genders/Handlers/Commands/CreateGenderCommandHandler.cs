using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using CleanArchitecture.Application.Contracts.Persistence.IUnitOfWork;
using CleanArchitecture.Application.Features.Genders.Requests.Commands;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Genders.Handlers.Commands
{
    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            var gender = _mapper.Map<Gender>(request.CreateGenderDto);
            if (gender == null)
            {
                return new BaseResponse(false, StatusCodesConst.Status404NotFound, "Not Found");
            }
            await _unitOfWork.Genders.AddAsync(gender);
            await _unitOfWork.SaveAsync();
            return new BaseResponse(true, StatusCodesConst.Status200OK, "Successfully", gender);
        }
    }
}
