﻿using Application.Dtos.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>
    {
        public int id { get; set; }
    }
}
