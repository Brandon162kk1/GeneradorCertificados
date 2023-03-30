using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeneradorCertificados.Models
{
     [Table("t_vecinos")]
    public class Vecinos
    {
        //identificador del vecino autoimcrementable
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //CREAR ID AUTOINCREMENT
        [Column("id")]
        public int idVecino { get; set; }

        [Column("dni")]
        public int dni { get; set; }

        [Column("nombre")] //como se llama en la tabla
        public string? nombre {get;set;}

        [Column("apellido")] 
        public string? apellido {get;set;}

        [Column("telefono")] 
        public string? telefono {get;set;}

       [Column("email")]
        public string? email {get;set;}

    }
}