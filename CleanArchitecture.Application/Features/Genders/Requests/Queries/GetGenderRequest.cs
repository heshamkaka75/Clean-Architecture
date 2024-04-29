using CleanArchitecture.Application.Dtos.GenderDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Genders.Requests.Queries
{
    public class GetGenderRequest : IRequest<GenderDto>
    {
        public int Id { get; set; }
    }
}
