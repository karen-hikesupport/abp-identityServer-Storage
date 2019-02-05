# abp-identityServer-Storage

use this one for configuration Abp.ZeroCore.IdentityServer4.Configuration

[DependsOn(typeof(AbpZeroCoreIdentityServer4ConfigurationModule))]
    public class OpenIdCoreModule : AbpModule {
        
    }
    
    
     [DependsOn(
        typeof(OpenIdCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(AbpZeroCoreIdentityServer4ConfigurationModule))]
    public class OpenIdEntityFrameworkModule : AbpModule {
    }
    
    
    using Abp.IdentityServer4;
using Abp.IdentityServer4.Entities;
using Abp.IdentityServer4.Extensions;

public class OpenIdDbContext : AbpZeroDbContext<Tenant, Role, User, OpenIdDbContext>, IAbpConfigurationDbContext {
        public DbSet<Client> Clients { get; set; }

        public DbSet<IdentityResource> IdentityResources { get; set; }

        public DbSet<ApiResource> ApiResources { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureConfigurationContext();

            base.OnModelCreating(modelBuilder);
        }
}


InitialHostDbBuilder.cs

new DefaultIdentityServerConfigCreator(_context).Create();


Startup.cs

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);
            services.AddIdentityServer()
                .AddSigningCredential(new X509Certificate2(_appConfiguration["Authentication:IdentityServer:File"],
                    _appConfiguration["Authentication:IdentityServer:Password"]))
                .AddAbpPersistedGrants<IAbpPersistedGrantDbContext>()
                .AddConfigurationStore<IAbpConfigurationDbContext>()
                .AddAbpIdentityServer<User>();
        }
        
        
        
        

