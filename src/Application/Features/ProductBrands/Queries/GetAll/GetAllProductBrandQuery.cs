using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.ProductBrands.Queries.GetAll
{
    public class GetAllProductBrandQuery : IRequest <IEnumerable<ProductBrand>>
    {
    }
}
