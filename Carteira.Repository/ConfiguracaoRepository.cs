using Carteira.Entity;
using Carteira.Entity.Contexto;

namespace Carteira.Repository
{
    public class ConfiguracaoRepository : Repository<Configuracao>
    {
        public ConfiguracaoRepository(Context context) : base(context) { }
    }
}
