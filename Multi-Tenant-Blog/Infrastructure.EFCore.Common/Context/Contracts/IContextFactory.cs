using Infrastructure.EFCore.Common.Context.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.Common.Context.Contracts
{ 
    /// <summary>
    /// Context factory interface
    /// </summary>
    public interface IContextFactory<T>
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        DbContext DbContext { get; }
    }
}
