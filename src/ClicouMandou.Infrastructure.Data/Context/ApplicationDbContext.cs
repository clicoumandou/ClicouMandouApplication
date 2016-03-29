using Microsoft.Data.Entity;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using ClicouMandou.Infrastructure.Data.Domain.UserArg;
using Microsoft.Data.Entity.Infrastructure;
using ClicouMandou.Infrastructure.Data.Domain.ProjetoArg;

namespace ClicouMandou.Infrastructure.Data.Context
{
    public class ClicouMandouDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private static bool _created = false;

        //Declarar as entidades
        public DbSet<Projeto> Projetos { get; set; }

        public ClicouMandouDbContext(DbContextOptions options)
: base(options)
        {
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=198.71.225.145,1433;Initial Catalog=cmmandouc;Persist Security Info=True;User ID=cmmandouc;Password=20cmmandouc16");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //mapeamento
            builder.Entity<Projeto>().HasKey(s => s.Id);

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<ApplicationRole>().ToTable("Roles");
        }

    }
}
