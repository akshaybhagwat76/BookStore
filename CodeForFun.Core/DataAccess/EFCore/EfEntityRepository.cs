using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CodeForFun.Core;
using Microsoft.EntityFrameworkCore;
using CodeForFun.Core.Entities;

namespace CodeForFun.Core.DataAccess.EFCore
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        private  readonly TContext _context;

        public EfEntityRepository(TContext context = null)
        {
            _context = new TContext();
        }
        // CREATE
        public void Create(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        // CREATE ASYNC
        public async void CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }


        // CREATE RANGE
        public void CreateRange(List<TEntity> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        // CREATE RANGE ASYNC
        public async void CreateRangeAsync(List<TEntity> entities)
        {
            await Task.Run(() => _context.AddRangeAsync(entities));
            _context.SaveChanges();
        }


        // READ
        public TEntity Read(Expression<Func<TEntity, bool>> filter) =>
            _context.Set<TEntity>().SingleOrDefault(filter);

        // READ ASYNC
        public async Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
            await _context.Set<TEntity>().SingleOrDefaultAsync(filter);

        // READ LIST
        public List<TEntity> ReadList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        // READ LIST ASYNC
        public async Task<List<TEntity>> ReadListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }


        // UPDATE
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // UPDATE ASYNC
        public async void UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }


        // UPDATE RANGE
        public void UpdateRange(List<TEntity> entities)
        {
            _context.UpdateRange(entities);
            _context.SaveChanges();
        }

        // UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<TEntity> entities)
        {
            await Task.Run(() => _context.UpdateRange(entities));
            _context.SaveChanges();
        }

        // DELETE
        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        // DELETE ASYNC
        public async void DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Remove(entity));
            _context.SaveChanges();
        }


        // DELETE RANGE
        public void DeleteRange(List<TEntity> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(List<TEntity> entities)
        {
            await Task.Run(() => _context.RemoveRange(entities));
            _context.SaveChanges();
        }
    }
}