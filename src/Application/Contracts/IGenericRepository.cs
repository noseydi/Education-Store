﻿using Application.Contracts.Specification;
using Application.Features.Products.Queries.GetAll;
using Domain.Entities;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync( int id , CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T>AddAsync(T entity,CancellationToken cancellationtoken);
        Task<T> UpdateAsync(T entity);
         void Delete(T entity , CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression , CancellationToken cancellationToken);
        Task<bool> AnyAsync(CancellationToken cancellationToken);
        //specification 
        Task<T> GetEntityWithSpec(ISpecification<T> spec , CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken   );
    }
}
