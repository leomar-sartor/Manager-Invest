using Carteira.Entity;
using Carteira.Entity.Contexto;

namespace Carteira.Repository
{
    public class AtivoRepository : Repository<Ativo>
    {
        public AtivoRepository(Context context) : base(context) { }
    }
}
