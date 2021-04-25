using copave.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace copave.Data
{
    public class CopaveContext: DbContext
    {
        public CopaveContext(DbContextOptions<CopaveContext> options): base(options){}
        public DbSet<Maquina> Maquina {get; set;}
        public DbSet<TipoMaquina> TipoMaquina {get; set;} 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Maquina>()
                        .Property(p => p.Valor)
                        .HasColumnType("decimal(14,3)");
        } 
    }
    
}