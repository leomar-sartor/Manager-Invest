using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//Nuguet Microsoft.AspNetCore.Identity.EntityFrameworkCore
//http://www.macoratti.net/20/05/aspc_crident2.htm
namespace Carteira.Entity.Contexto
{
    public class Context : IdentityDbContext<ApplicationUser> 
    {
        #region Variaveis
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Carteira;Trusted_Connection=True;";
        #endregion

        #region DbSet's
        public virtual DbSet<Corretora> Corretoras { get; set; }
        public virtual DbSet<Ativo> Ativos { get; set; }
        public virtual DbSet<Operacao> Operacoes { get; set; }

        public virtual DbSet<Apuracao> Apuracoes { get; set; }
        public virtual DbSet<Deposito> Depositos { get; set; }

        public virtual DbSet<Configuracao> Configuracoes { get; set; }
        #endregion

        #region Construtores
        public Context(DbContextOptions<Context> options) : base(options) { }

        public Context() : base() => _ConfigureDataBase();

        public Context(bool AmbienteDeHomologacao)
        {
            if (AmbienteDeHomologacao)
            {
                _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CarteiraHomologacao;Trusted_Connection=True;";
                _ConfigureDataBase();
            }
        }
        #endregion

        private void _ConfigureDataBase()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            builder.UseSqlServer(_connectionString);
            this.OnConfiguring(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //4º Identity
            base.OnModelCreating(modelBuilder);

            //Instruction - https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration

            //One to Many Relationship
            modelBuilder.Entity<Corretora>()
                .HasMany(c => c.Operacoes)
                .WithOne(op => op.Corretora)
                .IsRequired();

            // Other Way
            //modelBuilder.Entity<Operacao>()
            //    .HasOne(op => op.Corretora)
            //    .WithMany(c => c.Operacoes);

            //One to Many Relationship
            modelBuilder.Entity<Ativo>()
                .HasMany(a => a.Operacoes)
                .WithOne(op => op.Ativo)
                .IsRequired();

            modelBuilder.Entity<Deposito>()
                .HasOne(d => d.Corretora)
                .WithMany(c => c.Depositos)
                .IsRequired();

            modelBuilder.Entity<Operacao>()
               .HasOne(m => m.Apuracao)
               .WithOne(m => m.Operacao)
               .HasForeignKey("Apuracao");
        }
    }
}
