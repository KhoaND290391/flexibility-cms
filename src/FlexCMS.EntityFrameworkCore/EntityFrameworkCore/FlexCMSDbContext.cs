using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FlexCMS.Authorization.Roles;
using FlexCMS.Authorization.Users;
using FlexCMS.MultiTenancy;

namespace FlexCMS.EntityFrameworkCore
{
    public class FlexCMSDbContext : AbpZeroDbContext<Tenant, Role, User, FlexCMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FlexCMSDbContext(DbContextOptions<FlexCMSDbContext> options)
            : base(options)
        {
        }
    }
}
