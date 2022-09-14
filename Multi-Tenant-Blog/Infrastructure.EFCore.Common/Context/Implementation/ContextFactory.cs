using Infrastructure.EFCore.Common.Context.Contracts;
using Infrastructure.EFCore.Common.DatabaseManager;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EFCore.Common.Context.Implementation
{
    /// <summary>
    /// Entity Framework context service
    /// (Switches the db context according to tenant id field)
    /// </summary>
    /// <seealso cref="IContextFactory"/>
    public class ContextFactory<T> : IContextFactory<T> where T : DbContext
    {
        private const string TenantIdFieldName = "tenantid";
        private const string DatabaseFieldKeyword = "Database";
        
        private readonly HttpContext httpContext;
        private readonly IConfiguration configuration;
        private readonly IDatabaseManager dataBaseManager;

        private readonly bool isDevelopmentEnviroment;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextFactory"/> class.
        /// </summary>
        /// <param name="httpContentAccessor">The HTTP content accessor.</param>
        /// <param name="connectionOptions">The connection options.</param>
        /// <param name="dataBaseManager">The data base manager.</param>
        /// <param name="databaseType">Type of the database</param>
        public ContextFactory(IHttpContextAccessor httpContentAccessor,
                IConfiguration configuration,
                IDatabaseManager dataBaseManager,
                bool isDevelopmentEnviroment)
        {
            httpContext = httpContentAccessor.HttpContext;
            this.configuration = configuration;
            this.dataBaseManager = dataBaseManager;
            this.isDevelopmentEnviroment = isDevelopmentEnviroment;

            var newContext = Activator.CreateInstance(typeof(T), new object[] { ChangeDatabaseNameInConnectionString(TenantId).Options });
            if(newContext == null) 
            {
                throw new ApplicationException("Was not possible to initiate a new DbContext"); 
            }

            DbContext = (T)newContext;
        }

        /// <inheritdoc />
        public DbContext DbContext { get; private set; }

        /// <summary>
        /// Gets tenant id from HTTP header
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// httpContext
        /// or
        /// tenantId
        /// </exception>
        private string TenantId
        {
            get
            {
                string tenantId = Guid.Empty.ToString();

                if (!isDevelopmentEnviroment)
                {
                    ValidateHttpContext();

                    tenantId = this.httpContext.Request.Headers[TenantIdFieldName].ToString();

                    ValidateTenantId(tenantId);
                }

                return tenantId;
            }
        }

        private DbContextOptionsBuilder<T> ChangeDatabaseNameInConnectionString(string tenantId)
        {
            // 1. Create Connection String Builder using Default connection string
            var connectionBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));

            if (!isDevelopmentEnviroment)
            {
                // 2. Remove old Database Name from connection string
                connectionBuilder.Remove(DatabaseFieldKeyword);

                // 3. Obtain Database name from DataBaseManager and Add new DB name to 
                connectionBuilder.Add(DatabaseFieldKeyword, this.dataBaseManager.GetDatabaseName(tenantId));
            }

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<T>();

            return contextOptionsBuilder.UseSqlServer(connectionBuilder.ConnectionString);
        }

        private void ValidateHttpContext()
        {
            if (this.httpContext == null)
            {
                throw new ArgumentNullException(nameof(this.httpContext));
            }
        }

        private static void ValidateTenantId(string tenantId)
        {
            if (tenantId == null)
            {
                throw new ArgumentNullException(nameof(tenantId));
            }

            if (!Guid.TryParse(tenantId, out Guid tenantGuid))
            {
                throw new ArgumentNullException(nameof(tenantId));
            }
        }
    }
}