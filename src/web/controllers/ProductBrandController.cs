using Microsoft.AspNetCore.Mvc;
using MediatR;
using static MassTransit.ValidationResultExtensions;
using Application.Features.ProductBrands.Queries.GetAll;
using Web.common;
using Domain.Entities;

namespace Web.controllers
{
    public class ProductBrandController : BaseApiController
    {
        [HttpGet("GetAllProductBrand")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new GetAllProductBrandQuery(), cancellationToken));
        }
    }
}
