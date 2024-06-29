using System.ComponentModel.DataAnnotations;

namespace Examen_U1_POO_CarlosPineda.Database.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }

        // Data anotation 
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} nombre de la categoria es requerido")]
        public string Name { get; set; }   
    }
}
