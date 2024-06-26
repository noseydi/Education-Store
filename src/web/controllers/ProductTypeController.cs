using Application.Features.ProductTypes.Queries.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.common;

namespace Web.controllers
{
    public class ProductTypeController : BaseApiController
    {
       
            [HttpGet("GetAllProductType")]
            public async Task<ActionResult<IEnumerable<ProductType>>> Get(CancellationToken cancellationToken)
            {
                return Ok(await Mediatr.Send(new GetAllProductTypeQuery(), cancellationToken));
            }
        
    }
}
