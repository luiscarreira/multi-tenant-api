using System.Linq.Expressions;

namespace Domain.Common.Contracts
{
    /// <summary>
    /// Interface for generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">EF entity</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        T Get<TKey>(TKey id);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TProperty">Child entity</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationPropertyPath">Child property to include</param>
        /// <returns>Entity</returns>
        T Get<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class;

        /// <summary>
        /// Gets the specified identifier. Asynchronous version.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Task Entity</returns>
        Task<T> GetAsync<TKey>(TKey id);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TProperty">Child entity</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationPropertyPath">Child property to include</param>
        /// <returns>Entity</returns>
        Task<T> GetAsync<TKey, TProperty>(TKey id, Expression<Func<T, TProperty>> navigationPropertyPath) where TProperty : class;

        /// <summary>
        /// Gets an entity by the keys specified in <paramref name="keyValues"/>
        /// </summary>
        /// <param name="keyValues">Composite Primary Key Identifiers</param>
        /// <returns>The requested Entity</returns>
        T Get(params object[] keyValues);

        /// <summary>
        /// Generic find by predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <returns>Entity</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Generic find by predicate and option to include child entity
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="include">The include sub-entity.</param>
        /// <returns>Queryable</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(int page, int pageCount);

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <param name="navigationPropertyPath">Child entity to include</param>
        /// <returns></returns>
        IQueryable<T> GetAll<TProperty>(int page, int pageCount, Expression<Func<T, TProperty>> navigationPropertyPath);

        /// <summary>
        /// Gets all and offers to include a related table
        /// </summary>
        /// <param name="include">Te sub.entity to include</param>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include);

        
        /// <summary>
        /// Gets all and offers to include 2 related tables
        /// </summary>
        /// <param name="include">The sub.entity to include</param>
        /// <param name="include2">The second sub.entity to include</param>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include, string include2);

        
        /// <summary>
        /// Checks whether a entity matching the <paramref name="predicate"/> exists
        /// </summary>
        /// <param name="predicate">The predicate to filter on</param>
        /// <returns>Whether an entity matching the <paramref name="predicate"/> exists</returns>
        bool Exists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Created Entity</returns>
        T Add(T entity);

        /// <summary>
        /// Deletes the specified <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        void Delete(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Updated entity</returns>
        T Update(T entity);
    }
}
