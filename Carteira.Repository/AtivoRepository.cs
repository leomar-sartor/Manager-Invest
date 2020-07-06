using Carteira.Domain;
using Carteira.Domain.Contexto;

namespace Carteira.Repository
{
    public class AtivoRepository : Repository<Ativo>
    {
        public AtivoRepository(Context context) : base(context) { }
    }
}
