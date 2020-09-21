using Carteira.Entity;
using Carteira.Entity.Contexto;

namespace Carteira.Repository
{
    public class ApuracaoRepository : Repository<Apuracao>
    {
        public ApuracaoRepository(Context context) : base(context) { }
    }
}
