using System.ComponentModel.DataAnnotations;

namespace WikiAnime.Data.Request
{
    public class PersonajeRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo imagen es obligatorio")]
        public string Imagen { get; set; } = null!;
        public int? AnimeId { get; set; }
    }
}
