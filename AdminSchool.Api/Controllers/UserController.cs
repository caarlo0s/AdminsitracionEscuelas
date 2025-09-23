using AdminSchool.Application.Auth.Command.Login;
using AdminSchool.Application.Common.Dtos;
using AdminSchool.Application.UserApp.Commands.AddUser;
using AdminSchool.Application.UserApp.Commands.UpdateUser;
using AdminSchool.Application.UserApp.Queries.GetAllUsers;
using AdminSchool.Application.UserApp.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminSchool.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("add")]
    public async Task<ActionResult<ApiResponse<bool>>> Add([FromBody] AddUserCommand command)
    {
        var result = await _mediator.Send(command);


        var response = new ApiResponse<bool>(
                              status: 200,
                              message: "Usuario creado correctamente",
                              data: result);

        return response;



    }
    [HttpPut("edit")]
    public async Task<ActionResult<ApiResponse<int>>> Update([FromBody] UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);


        var response = new ApiResponse<int>(
                              status: 200,
                              message: "Usuario creado correctamente",
                              data: result);

        return response;



    }
    [HttpGet("getAll")]
    public async Task<ActionResult<ApiResponse<PagedResultDto<UserListDto>>>> GetAllUsers([FromQuery] GetAllUsersQuery request)
    {
        var result = await _mediator.Send(request);


        var response = new ApiResponse<PagedResultDto<UserListDto>>(
                              status: 200,
                              message: "Usuario creado correctamente",
                              data: result);

        return response;



    }
      
    [HttpGet("getById")]
    public async Task<ActionResult<ApiResponse<UserUpdateInfo>>> GetById([FromQuery] GetUserByIdQuery request)
    {
        var result = await _mediator.Send(request);


        var response = new ApiResponse<UserUpdateInfo>(
                              status: 200,
                              message: "Usuario creado correctamente",
                              data: result);

        return response;



    }
}
