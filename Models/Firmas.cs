using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software2.Models
{
    [Table("t_firmas")]
    public class Firmas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("NombreFirma")]
        public string? NombreFirma { get; set; }
        [Column("ImageNameFir")]
        public string? ImageNameFir { get; set; }

    }
}