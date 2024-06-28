using Application.Contracts.Specification;
using Domain.Entities;

namespace Application.Features.Products.Queries.GetAll
{
    
        public class GetAllProductSpec : BaseSpecification<Product>
        {
            public GetAllProductSpec() : base()
            {
                AddInclude(x => x.productbrand);
                AddInclude(x => x.producttype);
            }
        public GetAllProductSpec(int id): base (x => x.Id == id)
        {
            AddInclude(x => x.productbrand);
            AddInclude(x => x.producttype);

        }

    }
    
}