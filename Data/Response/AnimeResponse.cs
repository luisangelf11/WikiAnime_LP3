using WikiAnime.Data.Request;

namespace WikiAnime.Data.Response
{
    public class AnimeResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Portada { get; set; } = null!;
        public string Autor { get; set; } = null!;

        public AnimeRequest ToRequest()
        {
            return new AnimeRequest()
            {
                Id = Id,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Portada = Portada,
                Autor = Autor
            };
        }
    }
}
