using Carteira.Domain;
using Carteira.Domain.Contexto;

namespace Carteira.Repository
{
    public class ApuracaoRepository : Repository<Apuracao>
    {
        public ApuracaoRepository(Context context) : base(context) { }
    }
}
