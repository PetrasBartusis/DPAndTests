﻿using Microsoft.EntityFrameworkCore;
using System;
namespace GameServer.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options)
            : base(options)
        {
        }

        public DbSet<Player2> Players2 { get; set; }
    }
}

