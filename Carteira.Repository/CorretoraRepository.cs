using Carteira.Entity;
using Carteira.Entity.Contexto;

namespace Carteira.Repository
{
    public class CorretoraRepository : Repository<Corretora>
    {
        public CorretoraRepository(Context context) : base(context) { }
    }
}
