using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using WikiAnime.Data.Request;
using WikiAnime.Data.Response;

namespace WikiAnime.Data.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        
        public string Imagen { get; set; } = null!;
        public int? AnimeId { get; set; }

        [ForeignKey("AnimeId")]
        public virtual Anime? Anime { get; set; }

        public static Personaje Crear(PersonajeRequest personaje)
          => new()
          {
              Nombre = personaje.Nombre,
              Imagen = personaje.Imagen,
              AnimeId = personaje.AnimeId
          };

        public bool Modificar(PersonajeRequest personaje)
        {
            var cambio = false;
            if (Nombre != personaje.Nombre)
            {
                Nombre = personaje.Nombre;
                cambio = true;
            }
            if (Imagen != personaje.Imagen)
            {
                Imagen = personaje.Imagen;
                cambio = true;
            }
            if (AnimeId != personaje.AnimeId)
            {
                AnimeId = personaje.AnimeId;
                cambio = true;
            }
            return cambio;
        }
        public PersonajeResponse ToResponse()
            => new()
            {
                Id = Id,
                Nombre = Nombre,
                Imagen = Imagen,
                AnimeId = AnimeId,
                Anime = Anime != null ? Anime!.ToResponse() : null
            };
    }
}
