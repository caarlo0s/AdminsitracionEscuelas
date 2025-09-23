using AdminSchool.Application.Auth.Command.Login;
using AdminSchool.Application.Common.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminSchool.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<UserInfoDto>>>Login([FromBody] AuthLoginCommand command)
    {
        var result = await _mediator.Send(command);


        var response = new ApiResponse<UserInfoDto>(
                              status: 200,
                              message: "Login successful",
                              data: result);

        return response;



    }
}
