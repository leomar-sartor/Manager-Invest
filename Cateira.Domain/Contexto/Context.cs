using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Carteira.Domain.Contexto
{
    public class Context : DbContext
    {
        #region Variaveis
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Carteira;Trusted_Connection=True;";
        #endregion

        #region DbSet's
        public virtual DbSet<Corretora> Corretoras { get; set; }
        public virtual DbSet<Ativo> Ativos { get; set; }
        public virtual DbSet<Operacao> Operacoes { get; set; }
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

        #region Métodos de Configuração
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
        }
        #endregion
    }
}
