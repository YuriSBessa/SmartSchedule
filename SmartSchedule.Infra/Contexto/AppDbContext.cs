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
    }
}
