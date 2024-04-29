using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using CleanArchitecture.Application.Contracts.Persistence.IUnitOfWork;
using CleanArchitecture.Application.Dtos.GenderDtos;
using CleanArchitecture.Application.Features.Genders.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Genders.Handlers.Queries
{
    public class GetGenderListRequestHandler : IRequestHandler<GetGenderListRequest, List<GenderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenderListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GenderDto>> Handle(GetGenderListRequest request, CancellationToken cancellationToken)
        {
            var genders = await _unitOfWork.Genders.GetAllAsync();
            return _mapper.Map<List<GenderDto>>(genders);
        }
    }
}
