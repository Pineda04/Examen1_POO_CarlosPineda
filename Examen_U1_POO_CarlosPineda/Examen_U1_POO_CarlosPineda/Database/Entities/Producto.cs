using System;
using System.ComponentModel.DataAnnotations;

namespace Examen_U1_POO_CarlosPineda.Database.Entities
{
    public class Producto
    {
        public Guid Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} del producto es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La cantidad del producto es requerida.")]
        public double Cantidad { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio del producto es requerido.")]
        public double Precio { get; set; }
    }
}
