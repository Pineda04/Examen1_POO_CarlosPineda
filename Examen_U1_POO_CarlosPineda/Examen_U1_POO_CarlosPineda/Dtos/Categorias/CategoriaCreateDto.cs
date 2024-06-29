using System.ComponentModel.DataAnnotations;

namespace Examen_U1_POO_CarlosPineda.Dtos.Categorias
{
    public class CategoriaCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es requerido.")]
        public string Name { get; set; }
    }
}
