using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameCollection.Model;

namespace GameCollection.Models
{
    public class GameCollectionContext : DbContext
    {
        public GameCollectionContext (DbContextOptions<GameCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<GameCollection.Model.Game> Game { get; set; }
    }
}
