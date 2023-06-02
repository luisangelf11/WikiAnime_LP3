using Microsoft.EntityFrameworkCore;
using WikiAnime.Data.Context;
using WikiAnime.Data.Models;
using WikiAnime.Data.Request;
using WikiAnime.Data.Response;

namespace WikiAnime.Data.Services
{
    public class PersonajeServices : IPersonajeServices
    {
        private readonly IWikiAnimeDbContext dbContext;

        public PersonajeServices(IWikiAnimeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Crear un personaje
        public async Task<Result> Crear(PersonajeRequest request)
        {
            try
            {
                var personaje = Personaje.Crear(request);
                dbContext.Personajes.Add(personaje);
                await dbContext.SaveChangesAsync();
                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        //Modificar un personaje
        public async Task<Result> Modificar(PersonajeRequest request)
        {
            try
            {
                var personaje = await dbContext.Personajes
                    .FirstOrDefaultAsync(p => p.Id == request.Id);
                if (personaje == null)
                    return new Result { Success = false, Message = "No se encontro el personaje" };
                if (personaje.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        //Eliminar un personaje
        public async Task<Result> Eliminar(PersonajeRequest request)
        {
            try
            {
                var personaje = await dbContext.Personajes
                    .FirstOrDefaultAsync(p => p.Id == request.Id);
                if (personaje == null)
                    return new Result { Success = false, Message = "No se encontro el personaje" };

                dbContext.Personajes.Remove(personaje);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "OK" };
            }
            catch (Exception E)
            {
                return new Result { Success = false, Message = E.Message };
            }
        }

        //Listar todos los personajes
        public async Task<Result<List<PersonajeResponse>>> Consultar(string filtro)
        {
            try
            {
                var personajes = await dbContext.Personajes
                    .Include(p => p.Anime)
                    .Where(p => (p.Nombre + " " + p.Imagen)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(p => p.ToResponse())
                    .ToListAsync();
                return new Result<List<PersonajeResponse>>
                { Success = true, Message = "OK", Data = personajes };
            }
            catch (Exception E)
            {
                return new Result<List<PersonajeResponse>> { Success = false, Message = E.Message };
            }
        }
        //Cantidad de personajes de ese anime en especifo
        public async Task<Result<int>> ConsultarNoPersonajes(int id)
        {
            try
            {
                int cantidad = await dbContext.Personajes
               .Where(p => p.AnimeId == id)
               .Select(p => p.Id)
               .Distinct()
               .CountAsync();
                return new Result<int> { Message = "OK", Success = true, Data = cantidad };
            }
            catch (Exception E)
            {
                return new Result<int>
                { Message = E.Message, Success = true };
            }
        }

        //Esta funcion extrae de la BD los personajes que pertenecen a un anime en especifico
        public async Task<Result<List<PersonajeResponse>>> ConsultarPersonajesDeUnAnime(int id)
        {
            try
            {
                var personajes = await dbContext.Personajes
                     .Where(p=> p.AnimeId == id)
                     .Select(p=> p.ToResponse())
                     .ToListAsync();
                return new Result<List<PersonajeResponse>>
                { Success = true, Message = "OK", Data = personajes };
            }
            catch(Exception E)
            {
                return new Result<List<PersonajeResponse>> { Success = false, Message = E.Message };
            }
        }
    }
}
