using Domain.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.EFCore.Common.Repositories
{
    /// <summary>
    /// Generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class EFCoreBaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFCoreBaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EFCoreBaseRepository(DbContext context)
        {
            this.context = context;

            dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public T Get<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        /// <inheritdoc/>
        public T Get<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class
        {
            var entity = dbSet.Find(id);

            if (entity == null)
                return null;
            context.Entry(entity).Reference(navigationPropertyPath).Load();
            return entity;
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null) return null;
            await context.Entry(entity).Reference(navigationPropertyPath).LoadAsync();
            return entity;
        }

        /// <inheritdoc />
        public T Get(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            return FindBy(predicate).Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;

            return dbSet.Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll<TProperty>(int page, int pageCount, Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            var pageSize = (page - 1) * pageCount;

            return dbSet.Include(navigationPropertyPath).Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include)
        {
            return dbSet.Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include, string include2)
        {
            return dbSet.Include(include).Include(include2);
        }

        /// <inheritdoc />
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        /// <inheritdoc />
        public T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }

        /// <inheritdoc />
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public T Update(T entity)
        {
            return dbSet.Update(entity).Entity;
        }
    }
}
