using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarterProject.Api.Common.Responses;
using StarterProject.Api.Dtos;
using StarterProject.Api.Features.Users;
using StarterProject.Api.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StarterProject.Api.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class UsersController : MediatorControllerBase
    {
        private readonly IMediatorService _mediatorService;

        public UsersController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        [AllowAnonymous]
        [HttpPost("[controller]/authenticate")]
        [ProducesResponseType(typeof(Response<GetUserAuthenticationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Authenticate(AuthenticateUserRequest request)
        {
            var result = await _mediatorService.Send(request);
            return Ok(result);
        }

        [HttpGet("[controller]")]
        [ProducesResponseType(typeof(Response<List<GetUserDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllUsersRequest();
            var result = await _mediatorService.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("[controller]")]
        [ProducesResponseType(typeof(Response<GetUserDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(CreateUserRequest request)
        {
            var result = await _mediatorService.Send(request);
            return Created("api/users/Id-Goes-Here", result);
        }
    }
}
