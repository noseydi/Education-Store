using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using web.common;
using Domain.Entities;
using MassTransit.Futures.Contracts;

namespace web.controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new GetAllProductQuery(),cancellationToken));
        }
        
        [HttpGet("id:int")]
        public async Task<ActionResult<Product>> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new GetProductQuery(id), cancellationToken));
        }
}
}
    

