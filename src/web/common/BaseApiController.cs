using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.common
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private  ISender _miadiatr = null!;
        protected ISender Mediatr => _miadiatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
