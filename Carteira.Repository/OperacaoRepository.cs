using Carteira.Entity;
using Carteira.Entity.Contexto;

namespace Carteira.Repository
{
    public class OperacaoRepository : Repository<Operacao>
    {
        public OperacaoRepository(Context context) : base(context) { }
    }
}
