using System;
using DogsAndPeoples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MRO.Models;

#nullable disable

namespace DogsAndPeoples.Data
{
    public partial class DB_DogsAndPeoplesContext : DbContext
    {
        public DB_DogsAndPeoplesContext()
        {
        }

        public DB_DogsAndPeoplesContext(DbContextOptions<DB_DogsAndPeoplesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Dono> Donos { get; set; }
        public virtual DbSet<Caes> Caess { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*"Persist Security Info=False;Integrated Security=true; Initial Catalog=DogsAndPeoples;Server=REBECAPAIVAD084\\SQLEXPRESS"  */
                /*"Server= localhost; Database= employeedetails;Integrated Security=SSPI;"*/
                optionsBuilder.UseSqlServer("Persist Security Info = False; Integrated Security = true; Initial Catalog = DogsAndPeoples; Server = REBECAPAIVAD084\\SQLEXPRESS ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Caes>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

               
            });

            modelBuilder.Entity<Dono>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

            });

          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
