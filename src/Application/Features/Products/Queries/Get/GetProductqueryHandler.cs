using Application.Contracts;
using Application.Features.ProductBrands.Queries.GetAll;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Get
{
     public class GetProductqueryHandler : IRequestHandler<GetProductQuery , Product>

     {
         private readonly IUnitOfWork _uow;
        public GetProductqueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
         {
            var spec =new  GetAllProductSpec(request.Id);
            return await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);

             //var entity = await _uow.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
           //  if (entity == null) throw new Exception("Error Message"); 
           //  return entity;
         }
      

}
}
