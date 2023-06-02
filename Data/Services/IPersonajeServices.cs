using WikiAnime.Data.Request;
using WikiAnime.Data.Response;

namespace WikiAnime.Data.Services
{
    public interface IPersonajeServices
    {
        Task<Result<List<PersonajeResponse>>> Consultar(string filtro);
        Task<Result> Crear(PersonajeRequest request);
        Task<Result> Eliminar(PersonajeRequest request);
        Task<Result> Modificar(PersonajeRequest request);
        Task<Result<int>> ConsultarNoPersonajes(int id);
        Task<Result<List<PersonajeResponse>>> ConsultarPersonajesDeUnAnime(int id);
    }
}