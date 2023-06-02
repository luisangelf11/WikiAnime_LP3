using WikiAnime.Data.Request;
using WikiAnime.Data.Response;

namespace WikiAnime.Data.Services
{
    public interface IAnimeServices
    {
        Task<Result<List<AnimeResponse>>> Consultar(string filtro);
        Task<Result> Crear(AnimeRequest request);
        Task<Result> Eliminar(AnimeRequest request);
        Task<Result> Modificar(AnimeRequest request);
    }
}