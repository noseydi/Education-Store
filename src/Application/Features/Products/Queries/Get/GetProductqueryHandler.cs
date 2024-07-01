using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.ProductBrands.Queries.GetAll;
using Application.Features.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Get
{
     public class GetProductqueryHandler : IRequestHandler<GetProductQuery , ProductDto>

     {
         private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductqueryHandler()
        {
            
        }
        public GetProductqueryHandler(IUnitOfWork uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
         {
            var spec =new  GetAllProductSpec(request.Id);
            var result = await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);
            return _mapper.Map<ProductDto>(result);
             //var entity = await _uow.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
           //  if (entity == null) throw new Exception("Error Message"); 
           //  return entity;
         }
      

}
}
