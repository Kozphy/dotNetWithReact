using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private  IMediator _mediator;

        private readonly IRequest _request;
        private readonly ISender _sender;

        // if _meidator is null assign value from right hand side
        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>();

    }
}