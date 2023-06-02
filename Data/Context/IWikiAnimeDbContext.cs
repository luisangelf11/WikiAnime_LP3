using Microsoft.EntityFrameworkCore;
using WikiAnime.Data.Models;

namespace WikiAnime.Data.Context
{
    public interface IWikiAnimeDbContext
    {
        DbSet<Anime> Animes { get; set; }
        DbSet<Personaje> Personajes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}