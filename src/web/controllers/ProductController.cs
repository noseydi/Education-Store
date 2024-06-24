using Application.Features.Products.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using web.common;

namespace web.controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new GetAllProductQuery(),cancellationToken));
        }
    }
}
