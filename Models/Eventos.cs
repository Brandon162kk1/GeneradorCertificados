using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software2.Models
{
    [Table("t_eventos")]
    public class Eventos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("codEvento")]
        public string? CodEvento { get; set; }

        [Column("NombreEvento")]
        public string? NombreEvento { get; set; }

        [Column("Docente")]
        public string? Docente { get; set; }

        [Column("Horario")]
        public string? Horario { get; set; }
    }
}