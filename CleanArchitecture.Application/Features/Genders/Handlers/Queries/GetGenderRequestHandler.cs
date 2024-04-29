using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using CleanArchitecture.Application.Contracts.Persistence.IUnitOfWork;
using CleanArchitecture.Application.Dtos.GenderDtos;
using CleanArchitecture.Application.Features.Genders.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Genders.Handlers.Queries
{
    public class GetGenderRequestHandler : IRequestHandler<GetGenderRequest, GenderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenderRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GenderDto> Handle(GetGenderRequest request, CancellationToken cancellationToken)
        {
            var gender = await _unitOfWork.Genders.GetAsync(g => g.Id == request.Id);
            return _mapper.Map<GenderDto>(gender);
        }
    }
}
