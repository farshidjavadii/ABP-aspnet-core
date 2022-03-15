using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace test.EntityFrameworkCore
{
    public static class testDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<testDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<testDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
