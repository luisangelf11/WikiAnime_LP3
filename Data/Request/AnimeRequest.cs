using System.ComponentModel.DataAnnotations;

namespace WikiAnime.Data.Request
{
    public class AnimeRequest
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo descripcion es obligatorio")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El campo portada es obligatorio")]
        public string Portada { get; set; } = null!;

        [Required(ErrorMessage = "El campo autor es obligatorio")]
        public string Autor { get; set; } = null!;
    }
}
