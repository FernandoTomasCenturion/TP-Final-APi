using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SWProvincias_Apellido.Models
{ 
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        public int IdProvincia { get; set; }
        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; }
    }
}
