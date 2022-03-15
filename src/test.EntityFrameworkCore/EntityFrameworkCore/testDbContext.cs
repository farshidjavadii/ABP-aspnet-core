using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using test.Authorization.Roles;
using test.Authorization.Users;
using test.MultiTenancy;

namespace test.EntityFrameworkCore
{
    public class testDbContext : AbpZeroDbContext<Tenant, Role, User, testDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public testDbContext(DbContextOptions<testDbContext> options)
            : base(options)
        {
        }
    }
}
