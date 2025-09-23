using AdminSchool.Application.Common.Dtos;
using AdminSchool.Application.LevelEducation.Commands.AddLevelEducation;
using AdminSchool.Application.LevelEducation.Queries.GetAllLevels;
using AdminSchool.Application.UserApp.Commands.AddUser;
using AdminSchool.Application.UserApp.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminSchool.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationLevelController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<EducationLevelController> _logger;

    public EducationLevelController(IMediator mediator, ILogger<EducationLevelController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("add")]
    public async Task<ActionResult<ApiResponse<bool>>> Add([FromBody] AddLevelEducationCommand command)
    {
        var result = await _mediator.Send(command);


        var response = new ApiResponse<bool>(
                              status: 200,
                              message: "Nivel de Educación creado correctamente",
                              data: result);

        return response;



    }

    [HttpGet("getAll")]
    public async Task<ActionResult<ApiResponse<PagedResultDto<GetAllEducationLevelsDto>>>> GetAllUsers([FromQuery] GetAllLevelsQuery request)
    {
        var result = await _mediator.Send(request);


        var response = new ApiResponse<PagedResultDto<GetAllEducationLevelsDto>>(
                              status: 200,
                              message: "Usuario creado correctamente",
                              data: result);

        return response;



    }
}