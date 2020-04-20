using Microsoft.EntityFrameworkCore;

namespace Carteira.Domain.Contexto
{
    public class Context : DbContext
    {
        #region Variaveis
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Carteira;Trusted_Connection=True;";
        #endregion

        #region DbSet's
        public virtual DbSet<Corretora> Corretoras { get; set; }
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
        #endregion
    }
}
