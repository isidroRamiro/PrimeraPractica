using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practica2.model
{
    public class docente
    {
        [Key]
        public int Id_Doce { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ubicacion { get; set; }
        public bool Sexo { get; set; }
        public string Ci { get; set; }

        [ForeignKey("universidad")]
        public int Id_uni { get; set; }

        public universidad universidad { get; set; }
    }
}
