using Helenium.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Helenium.DAL
{
    /// <summary>
    /// database Context
    /// </summary>
    public class HeleniumDbContext : DbContext
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public HeleniumDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Gets or sets the configuration data.
        /// </summary>
        /// <value>
        /// The configuration data.
        /// </value>
        public virtual DbSet<ConfigData> ConfigData { get; set; }
        ///// <summary>
        ///// Gets or sets the URL data.
        ///// </summary>
        ///// <value>
        ///// The URL data.
        ///// </value>
        //public DbSet<URLData> URLData { get; set; }
        /// <summary>
        /// Gets or sets the error data.
        /// </summary>
        /// <value>
        /// The error data.
        /// </value>
        public virtual DbSet<ErrorData> ErrorData { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}