namespace Infrastructure.EFCore.Common.DatabaseManager
{
    /// <summary>
    /// Multitenant database manager
    /// </summary>
    public interface IDatabaseManager
    {
        /// <summary>
        /// Gets the name of the data base.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>db name</returns>
        string GetDatabaseName(string tenantId);
    }
}
