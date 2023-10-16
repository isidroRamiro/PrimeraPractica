using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace practica2.model
{
    public class Materia
    {
        [Key]
        public int Id_Materia { get; set; }
        public string Nombre { get; set; }
        // public string Apellido { get; set; }
        // public string Ubicacion { get; set; }
        //public bool Sexo { get; set; }
        //public string Ci { get; set; }

        [ForeignKey("docente")]
        public int Id_Doce { get; set; }

        public docente docente { get; set; }
    }
}
