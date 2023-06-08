using System.ComponentModel.DataAnnotations;

namespace PetshopProgreso2.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

    }
}

