using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace web.common
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private  ISender _miadiatr = null!;
        protected ISender Mediatr => _miadiatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
