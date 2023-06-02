using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using WikiAnime.Data.Context;
using WikiAnime.Data.Models;
using WikiAnime.Data.Request;
using WikiAnime.Data.Response;

namespace WikiAnime.Data.Services
{
    public class AnimeServices : IAnimeServices
    {
        private readonly IWikiAnimeDbContext dbContext;

        public AnimeServices(IWikiAnimeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Crear
        public async Task<Result> Crear(AnimeRequest request)
        {
            try
            {
                var anime = Anime.Crear(request);
                dbContext.Animes.Add(anime);
                await dbContext.SaveChangesAsync();
                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        //Modificar
        public async Task<Result> Modificar(AnimeRequest request)
        {
            try
            {
                var anime = await dbContext.Animes
                    .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (anime == null)
                    return new Result { Success = false, Message = "No se encontro el anime" };
                if (anime.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        //Eliminar
        public async Task<Result> Eliminar(AnimeRequest request)
        {
            try
            {
                var anime = await dbContext.Animes
                    .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (anime == null)
                    return new Result { Success = false, Message = "No se encontro el anime" };
                dbContext.Animes.Remove(anime);
                await dbContext.SaveChangesAsync();
                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        //Consultar
        public async Task<Result<List<AnimeResponse>>> Consultar(string filtro)
        {
            try
            {
                var animes = await dbContext.Animes
                    .Where(a => (a.Nombre + " " + a.Descripcion + " " + a.Portada + " " + a.Autor)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(a => a.ToResponse())
                    .ToListAsync();
                return new Result<List<AnimeResponse>>
                { Message = "OK", Success = true, Data = animes };
            }
            catch (Exception E)
            {
                return new Result<List<AnimeResponse>>
                { Message = E.Message, Success = true };
            }
        }
    }
}
