using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeneradorCertificados.Models
{
     [Table("t_eventos")]
    public class Eventos
    {
        //identificador del vecino autoimcrementable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //CREAR ID AUTOINCREMENT
        [Column("id")]
        public int idEvento { get; set; }

    }
}