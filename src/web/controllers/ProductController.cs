﻿using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.common;
using Domain.Entities;
using MassTransit.Futures.Contracts;
using Application.Dtos.Products;

namespace Web.controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new GetAllProductQuery(),cancellationToken));
        }
        
        [HttpGet("id:int")]
        public async Task<ActionResult<ProductDto>> Get( int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new GetProductQuery(id), cancellationToken));
        }
       
}

}
    

