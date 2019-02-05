
using Abp.IdentityServer4;
using HikePOS.Authorization.Clients;
using HikePOS.Authorization.Users;
using HikePOS.EntityFrameworkCore;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Abp.IdentityServer4.Extensions;
using IdentityServer4.Services;
using IdentityServer4.AspNetIdentity;
using Abp.Domain.Uow;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Abp.Authorization.Users;
using System.Collections.Generic;
using Abp.Runtime.Security;
using System.Security.Claims;
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IdentityModel.Tokens.Jwt;
using HikePOS.Migrations.Seed.Host;

namespace HikePOS.Web.IdentityServer
{
    public static class IdentityServerRegistrar
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAbpPersistedGrants<IAbpPersistedGrantDbContext>()
                .AddConfigurationStore<IAbpConfigurationDbContext>()
                .AddAbpIdentityServer<User>();
        }
    }
}
