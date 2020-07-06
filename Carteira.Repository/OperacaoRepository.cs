using Carteira.Domain;
using Carteira.Domain.Contexto;

namespace Carteira.Repository
{
    public class OperacaoRepository : Repository<Operacao>
    {
        public OperacaoRepository(Context context) : base(context) { }
    }
}
