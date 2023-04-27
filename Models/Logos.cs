using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software2.Models
{
    [Table("t_logos")]
    public class Logos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("NombreInsti")]
        public string? NombreInsti { get; set; }
        [Column("ImageName")]
        public string? ImageName { get; set; }

    }
}