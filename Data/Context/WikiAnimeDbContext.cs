using Microsoft.EntityFrameworkCore;
using WikiAnime.Data.Models;

namespace WikiAnime.Data.Context
{
    public class WikiAnimeDbContext : DbContext, IWikiAnimeDbContext
    {
        private readonly IConfiguration config;

        public WikiAnimeDbContext(IConfiguration config)
        {
            this.config = config;
        }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Anime> Animes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
