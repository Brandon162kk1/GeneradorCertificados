using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software2.Models
{
    [Table("t_dicert")]
    public class DisenarCerti
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("infoVec")]
        public Vecinos vecinos { get; set; }

        [Column("infoLog")]
        public Logos logos { get; set; }

        [Column("infoFir")]
        public Firmas firmas{ get; set; }

        [Column("Certificado")]
        public Byte [] archivo {get; set;} = new Byte[1];

    }
}