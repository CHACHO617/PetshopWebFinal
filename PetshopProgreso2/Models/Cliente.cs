using System.ComponentModel.DataAnnotations;

namespace PetshopProgreso2.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Contrasena { get; set; }  

    }
}
