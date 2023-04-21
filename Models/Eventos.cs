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
        public string? CodEvento { get; set; }

        public string? NombreEvento { get; set; }

        public string? Docente { get; set; }

        public string? Horario { get; set; }
    }
}