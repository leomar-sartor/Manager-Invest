using Carteira.Domain.Contexto;
using Carteira.Testes.Utilitarios.ObjectDefault;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carteira.Testes.Utilitarios.Mocks
{
    public partial class ContextMock
    {
        public Mock<Context> _contextMock;

        public CorretoraDefault _corretoraDefault;

        partial void BuildCorretora();


        public ContextMock()
        {
            _contextMock = new Mock<Context>();
            _corretoraDefault = new CorretoraDefault();

            BuildCorretora();
        }
    }
}
