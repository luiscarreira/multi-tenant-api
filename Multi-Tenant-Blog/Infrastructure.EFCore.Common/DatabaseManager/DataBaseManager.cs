namespace Infrastructure.EFCore.Common.DatabaseManager
{
    /// <summary>
    /// Contains all tenants database mappings and options
    /// </summary>
    public class DatabaseManager : IDatabaseManager
    {
        /// <summary>
        /// IMPORTANT NOTICE: Tenant Configuration was implemented as Dictionary for demo purposes only 
        /// </summary>
        private readonly Dictionary<Guid, string> tenantConfigurationDictionary = new Dictionary<Guid, string>
        {
            {
                Guid.Parse("0240E8F3-1793-43A9-9B41-1E3B4C645C33"), "Blog.Article_T1"
            },
            {
                Guid.Parse("589C5158-2759-4694-B64C-BC4E1BC21EB1"), "Blog.Article_T2"
            }
        };

        /// <summary>
        /// Gets the name of the data base.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>db name</returns>
        public string GetDatabaseName(string tenantId)
        {
            var dataBaseName = this.tenantConfigurationDictionary[Guid.Parse(tenantId)];

            if (dataBaseName == null)
            {
                throw new ArgumentNullException(nameof(dataBaseName));
            }

            return dataBaseName;
        }
    }
}
