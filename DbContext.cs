using Abp.IdentityServer4;
using Abp.IdentityServer4.Entities;


 
    public class HostDbContext : AbpZeroDbContext<Tenant, Role, User, HostDbContext>, IAbpConfigurationDbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<IdentityResource> IdentityResources { get; set; }

        public DbSet<ApiResource> ApiResources { get; set; }        

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                      
            
            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }

