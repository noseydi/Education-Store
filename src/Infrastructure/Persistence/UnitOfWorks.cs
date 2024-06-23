﻿using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWorks(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbContext context => _context ;

        public  IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}