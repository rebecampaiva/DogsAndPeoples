using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DogsAndPeoples.Models
{
    [Table("Caes")]
    [Index(nameof(Nome), Name = "IX_TB_CODIGO", IsUnique = true)]
    public partial class Caes
    {
        public Caes()
        {
            Donos = new HashSet<Dono>();
        }

        [Key]
        public int CaesId { get; set; }
        [Required]
       [StringLength(150)]
        public string Nome { get; set; }
       

     
        public virtual ICollection<Dono> Donos { get; set; }
    }
}
