using Application.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Get
{
    /* public class GetProductqueryHandler : IRequestHandler<GetProductQuery , Product>

     {
         private readonly IUnitOfWork _uow;

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
         {
             var entity = await _uow.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
             if (entity == null) throw new Exception("Error Message"); 
             return entity;
         }
      

}*/
}
