using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using WebClinicaMVC.Models;

namespace WebClinicaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<ProfissionalEspecialidade> ProfissionalEspecialidades { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Profissional>()
                .HasMany(e => e.Especialidades)
                .WithMany(p => p.Profissionais)
                .UsingEntity<ProfissionalEspecialidade>(
                l => l.HasOne<Especialidade>(e => e.Especialidade).WithMany(e => e.ProfissionalEspecialidades).HasForeignKey(e => e.IdEspecialidade),
                r => r.HasOne<Profissional>(e => e.Profissional).WithMany(e => e.ProfissionalEspecialidades).HasForeignKey(e => e.IdProfissional));

            base.OnModelCreating(builder);
        }
    }
}