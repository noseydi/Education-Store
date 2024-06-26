using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Specification
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inpputquery, ISpecification<T> specification)
        {
            var query = inpputquery.AsQueryable();
            if (specification.Predicate != null)
                query = query.Where(specification.Predicate);

            if (specification.Includes.Any())
                query = specification.Includes.Aggregate(query, (current, value) => current.Include(value));

            return query;
        }
    }
}