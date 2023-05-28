using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software2.Models
{
[Table("t_formato")]
    public class Formato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public string? Nombres { get; set; }

        [Column("Apellidos")]
        public string? Apellidos { get; set; }

        [Column("Dni")]
        public string? Dni { get; set; }

        [Column("Evento")]
        public string? Evento{ get; set; }

        public Byte [] archivo {get; set;} = new Byte[1];
    }
}