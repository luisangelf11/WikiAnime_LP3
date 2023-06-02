using System.ComponentModel.DataAnnotations.Schema;
using WikiAnime.Data.Models;
using WikiAnime.Data.Request;

namespace WikiAnime.Data.Response
{
    public class PersonajeResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Imagen { get; set; } = null!;
        public int? AnimeId { get; set; }
        public AnimeResponse? Anime { get; set; }

        public string NombreAnime => Anime != null ? Anime.Nombre : "N/A";

        public PersonajeRequest ToRequest()
        {
            return new PersonajeRequest() { 
                Id = Id,
                Nombre =Nombre,
                Imagen = Imagen,
                AnimeId = AnimeId
            };
        }
    }
}
