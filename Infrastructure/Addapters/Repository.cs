using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Raffle.Domain.Entities.Base;
using Raffle.Domain.Ports;
using Raffle.Infrastructure.EntityFramework.Helpers;
using Raffle.Infrastructure.EntityFramework.StoreProcedures;

namespace Raffle.Infrastructure.EntityFramework.Adapters
{
    public class Repository<E> : IRepository<E>, IDisposable where E : DomainEntity
    {
        private readonly PersistenceContext _context;

        public Repository(PersistenceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        internal DbContext DbContext => _context;

        public async Task<E> AddAsync(E entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), "La entidad no puede estar vacia");

            _context.Set<E>().Add(entity);

            await SaveAsync();

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<E> entities)
        {
            if (entities == null)
                return; 
            if (!entities.Any())
                return;

            await _context.Set<E>().AddRangeAsync(entities);
            await SaveAsync();
        }

        public async Task RemoveAsync(E entity)
        {
            if (entity == null)
            {
                return;
            }

            _context.Set<E>().Remove(entity);

            await SaveAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<E> entities)
        {
            if (entities == null)
                return;
            if (!entities.Any())
                return;

            _context.Set<E>().RemoveRange(entities);
            await SaveAsync();
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, string includeStringProperties = "", bool isTracking = false)
        {
            IQueryable<E> query = _context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeStringProperties))
            {
                foreach (var includeProperty in includeStringProperties.Split
                    (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, bool isTracking = false, params Expression<Func<E, object>>[] includeObjectProperties)
        {
            IQueryable<E> query = _context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeObjectProperties != null)
            {
                foreach (var include in includeObjectProperties)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<E?> FindAsync(object id)
        {
            return await _context.Set<E>().FindAsync(id);
        }

        public async Task<E> FindByAlternateKeyAsync(Expression<Func<E, bool>> alternateKey, string includeProperties = "")
        {
            var entity = _context.Set<E>().AsNoTracking();

            includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(property =>
            {
                entity = entity.Include(property.Trim());
            });

            return await entity.FirstOrDefaultAsync(alternateKey).ConfigureAwait(false);
        }

        public async Task UpdateAsync(E entity)
        {
            if (entity == null)
            {
                return;
            }

            _context.Set<E>().Update(entity);

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            _context.ChangeTracker.DetectChanges();

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<StoreProcedureResult<E>> ExecuteStoreProcedureAsync(string storeProcedureName)
        {
            var items = await _context.Set<E>().FromSqlRaw(storeProcedureName).ToListAsync();

            return new StoreProcedureResult<E>(items);
        }

        public async Task<StoreProcedureResult<E>> ExecuteStoreProcedureAsync<TDefinition>(string storeProcedureName, TDefinition definition)
        {
            var (query, parameters) = definition.AsStoreProcedure(storeProcedureName);

            var items = await _context.Set<E>().FromSqlRaw(query, parameters.ToArray()).ToListAsync();

            return new StoreProcedureResult<E>(items, parameters.GetOutputValues<TDefinition>());
        }

        public async Task<StoreProcedureResult<E>> ExecuteStoreProcedureAsync<TDefinition>(string storeProcedureName, object instance)
        {
            var (query, parameters) = instance.AsStoreProcedure<TDefinition>(storeProcedureName);

            var items = await _context.Set<E>().FromSqlRaw(query, parameters.ToArray()).ToListAsync();

            return new StoreProcedureResult<E>(items, parameters.GetOutputValues<TDefinition>());
        }

        public async Task<StoreProcedureResult> ExecuteSqlRawAsync<TDefinition>(string storeProcedureName, object instance)
        {
            var (query, parameters) = instance.AsStoreProcedure<TDefinition>(storeProcedureName);

            await _context.Database.ExecuteSqlRawAsync(query, parameters);

            return new StoreProcedureResult(parameters.GetOutputValues<TDefinition>());
        }

        public async Task<StoreProcedureResult> ExecuteSqlRawAsync<TDefinition>(string storeProcedureName, TDefinition definition)
        {
            var (query, parameters) = definition.AsStoreProcedure(storeProcedureName);

            await _context.Database.ExecuteSqlRawAsync(query, parameters.ToArray());

            return new StoreProcedureResult(parameters.GetOutputValues<TDefinition>());
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
