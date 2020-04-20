using Carteira.Domain;
using Carteira.Domain.Contexto;

namespace Carteira.Repository
{
    public class CorretoraRepository : Repository<Corretora>
    {
        public CorretoraRepository(Context context) : base(context) { }
    }
}
