using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminSchool.Api
{
    public class BaseController : ControllerBase {
        private IMediator _mediator;
        protected readonly ILogger _logger;

        protected IMediator Mediator => _mediator ?? (_mediator = base.HttpContext.RequestServices.GetService<IMediator>());

        protected BaseController(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}