using CleanArchitecture.API.ApiRouters;
using CleanArchitecture.Application.Dtos.GenderDtos;
using CleanArchitecture.Application.Features.Genders.Requests.Commands;
using CleanArchitecture.Application.Features.Genders.Requests.Queries;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GendersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoute.GenderRoutes.Genders)]
        public async Task<BaseResponse> GetAllAsync()
        {
            var genders = await _mediator.Send(new GetGenderListRequest());
            return new BaseResponse(true, StatusCodesConst.Status200OK, "Success", genders);
        }

        [HttpGet(ApiRoute.GenderRoutes.GenderById)]
        public async Task<BaseResponse> GetByIdAsync(int id)
        {
            try
            {
                var gender = await _mediator.Send(new GetGenderRequest { Id = id });
                return gender == null
                        ? new BaseResponse(false, StatusCodesConst.Status404NotFound, "Not found")
                        : new BaseResponse(true, StatusCodesConst.Status200OK, "Success", gender);
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, StatusCodesConst.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost(ApiRoute.GenderRoutes.AddGender)]
        public async Task<BaseResponse> Post([FromBody] CreateGenderDto createGenderDto)
        {
            var command = new CreateGenderCommand { CreateGenderDto = createGenderDto };
            return await _mediator.Send(command);
        }
    }
}
