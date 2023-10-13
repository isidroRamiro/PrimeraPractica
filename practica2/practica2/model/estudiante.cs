using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practica2.model
{
    public class estudiante
    {
        [Key]
        public int Id_estu { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool Sexo { get; set; }

        [ForeignKey("universidad")]
        public int Id_uni { get; set; }

        public universidad universidad { get; set; }
    }
}
