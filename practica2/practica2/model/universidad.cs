
using System.ComponentModel.DataAnnotations;

namespace practica2.model
{
    public class universidad
    {
        [Key]
        public int Id_uni { get; set; }
        public string Nombre { get; set; }
    }
}
