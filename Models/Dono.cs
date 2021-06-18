using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DogsAndPeoples.Models
{
    [Table("Dono")]
    [Index(nameof(Nome), Name = "UQ_Dono_Nome", IsUnique = true)]
  
    public partial class Dono
    {
        [Key]
        public int DonoId { get; set; }
       
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string Operador { get; set; }

       /* [ForeignKey(nameof(CaesId))]
        [InverseProperty("Caess")]
        public virtual Caes Caes { get; set; }*/
       
    }
}
