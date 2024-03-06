using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Automation_System.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ZohoData> ZohoDatas { get; set; }
        public virtual DbSet<CustomerDefaultBillingAddress> CustomerDefaultBillingAddresses { get; set; }
        //public virtual DbSet<AccessTokenResponse> AccessTokenResponses { get; set; }
        //public virtual DbSet<ResponseAcceTok> ResponseAcceToks { get; set; }
        //public virtual DbSet<InvoiceResponseData> InvoiceResponseDatas { get; set; }
        public virtual DbSet<ResponseSadadData> ResponseSadadDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ZohoData>(Configure);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        void Configure(EntityTypeBuilder<ZohoData> builder)
        {
            builder.Property(x => x.Total).HasColumnType("decimal(18,8)");
        }
    }
}
