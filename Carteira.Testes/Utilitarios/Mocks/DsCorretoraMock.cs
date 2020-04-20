using Carteira.Domain;
using Carteira.Domain.Contexto;
using Carteira.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carteira.Testes.Utilitarios.Mocks
{
    public partial class ContextMock
    {
        public IQueryable<Corretora> _corretoras;
        public Mock<DbSet<Corretora>> _dsCorretora;

        public Mock<CorretoraRepository> _rCorretoraMock;

        partial void BuildCorretora()
        {
            _dsCorretora = new Mock<DbSet<Corretora>>();
            _rCorretoraMock = new Mock<CorretoraRepository>(_contextMock.Object);

            LoadingCorretoras();
        }

        public void LoadingCorretoras()
        {
            _corretoras = _corretoraDefault._corretoras.AsQueryable();

            ConfigureDbSetCorretora();
            ConfigureRepositoryCorretora();
        }

        public void ConfigureDbSetCorretora()
        {
            _dsCorretora.As<IQueryable<Corretora>>().Setup(m => m.Provider).Returns(_corretoras.Provider);
            _dsCorretora.As<IQueryable<Corretora>>().Setup(m => m.Expression).Returns(_corretoras.Expression);
            _dsCorretora.As<IQueryable<Corretora>>().Setup(m => m.ElementType).Returns(_corretoras.ElementType);
            _dsCorretora.As<IQueryable<Corretora>>().Setup(m => m.GetEnumerator()).Returns(_corretoras.GetEnumerator());

            _contextMock.Setup(c => c.Corretoras).Returns(_dsCorretora.Object);
        }

        public void ConfigureRepositoryCorretora()
        {
            _rCorretoraMock.Setup(r => r.QueriableListAsync()).Returns(Task.FromResult(_contextMock.Object.Corretoras.AsQueryable()));
            _rCorretoraMock.Setup(r => r.Listar()).Returns(_contextMock.Object.Corretoras.ToList());
        }

        public void AddObjectInContext(Corretora corretora)
        {
            _corretoras = _corretoras.Concat(new[] { corretora });
            ConfigureDbSetCorretora();
            ConfigureRepositoryCorretora();
        }
    }
}
