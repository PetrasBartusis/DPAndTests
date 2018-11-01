using Microsoft.EntityFrameworkCore;
using System;
namespace GameServer.Models
{
    public class EnemyContext : DbContext
    {
        public EnemyContext(DbContextOptions<EnemyContext> options)
            : base(options)
        {
        }

        public DbSet<EnemyPartyJson> enemyParties { get; set; }
        public DbSet<EnemyJson> enemies { get; set; }
    }
}

