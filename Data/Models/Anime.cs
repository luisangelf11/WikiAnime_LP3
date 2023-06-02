using System.ComponentModel.DataAnnotations;
using WikiAnime.Data.Request;
using WikiAnime.Data.Response;

namespace WikiAnime.Data.Models
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Portada { get; set; } = null!;
        public string Autor { get; set; } = null!;

        //Crear un Anime
        public static Anime Crear(AnimeRequest anime) =>
            new (){
                Nombre = anime.Nombre,
                Descripcion = anime.Descripcion,
                Portada = anime.Portada,
                Autor = anime.Autor
            };

        //Modificar un Anime
        public bool Modificar(AnimeRequest anime)
        {
            var cambio = false;
            if(Nombre != anime.Nombre)
            {
                Nombre = anime.Nombre;
                cambio = true;
            }
            if (Descripcion != anime.Descripcion)
            {
                Descripcion = anime.Descripcion;
                cambio = true;
            }
            if (Portada != anime.Portada)
            {
                Portada = anime.Portada;
                cambio = true;
            }
            if (Autor != anime.Autor)
            {
                Autor = anime.Autor;
                cambio = true;
            }
            return cambio;
        }

        //ToResponde
        public AnimeResponse ToResponse() =>
            new() { 
                Id = Id,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Portada = Portada,
                Autor = Autor
            };
    }
}
