using CleanArchitecture.Application.Dtos.GenderDtos;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Features.Genders.Requests.Queries
{
    public class GetGenderListRequest : IRequest<List<GenderDto>>
    {
    }
}
