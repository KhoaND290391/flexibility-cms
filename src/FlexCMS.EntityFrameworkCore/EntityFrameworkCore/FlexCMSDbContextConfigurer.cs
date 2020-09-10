using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FlexCMS.EntityFrameworkCore
{
    public static class FlexCMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FlexCMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FlexCMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
