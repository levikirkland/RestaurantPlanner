using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBaseBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
