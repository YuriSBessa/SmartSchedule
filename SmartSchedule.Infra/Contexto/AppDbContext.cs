using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartSchedule.Dominio.Entidades;
using SmartSchedule.Dominio.Enums;
using SmartSchedule.Dominio.Models;

namespace SmartSchedule.Infra.Contexto
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Tarefas> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<Tarefas>()
                .Property(t => t.Prioridade)
                .HasConversion(
                    v => v.ToString(),
                    v => (EPrioridade)Enum.Parse(typeof(EPrioridade), v)
                );

            modelBuilder.Entity<Tarefas>()
                .Property(t => t.StatusTarefa)
                .HasConversion(
                    v => v.ToString(),
                    v => (EStatusTarefa)Enum.Parse(typeof(EStatusTarefa), v)
                );

            modelBuilder.Entity<Tarefas>()
                .Property(t => t.Categoria)
                .HasConversion(
                    v => v.ToString(),
                    v => (ECategoria)Enum.Parse(typeof(ECategoria), v)
                );
        }
    }
}
