using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.ProductBrands.Queries.GetAll;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery,IEnumerable<ProductDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper; 
        public GetAllProductQueryHandler(IUnitOfWork uow , IMapper mapper )
        {
            _uow = uow;
            _mapper = mapper ;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request , CancellationToken cancellationToken)
        {
            // return await _uow.Repository<Product>().GetAllAsync(cancellationToken);
            var spec = new GetAllProductSpec();
            var result = await _uow.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

    }
}
