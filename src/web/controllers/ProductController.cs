using Microsoft.AspNetCore.Mvc;
using web.common;

namespace web.controllers
{
    public class ProductController : BaseApiController
    {
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
