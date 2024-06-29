using System.ComponentModel.DataAnnotations;

namespace Examen_U1_POO_CarlosPineda.Dtos.Productos
{
    public class ProductoCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del producto es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La {0} del producto es requerida.")]
        public int Cantidad { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El {0} del producto es requerido.")]
        public double Precio { get; set; }
    }
}
