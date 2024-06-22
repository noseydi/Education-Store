﻿using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public  class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity ,CancellationToken cancellationtoken)
        {
            await _dbset.AddAsync( entity,  cancellationtoken);
            return entity;

        }

        public void  Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbset.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id , CancellationToken cancellationToken)
        {
            return await _dbset.FindAsync(id, cancellationToken);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }
    }
}
