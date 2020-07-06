using Carteira.Domain.Contexto;
using Carteira.Repository;
using System;

namespace Carteira.Service
{
    public class PosicaoService
    {
        private Context _contexto;
        private OperacaoRepository _rOperacao;

        public PosicaoService(Context contexto)
        {
            _contexto = contexto;
            _rOperacao = new OperacaoRepository(_contexto);
        }

        public PosicaoService(Context contextMock, OperacaoRepository rOperacaoMock)
        {
            _contexto = contextMock;
            _rOperacao = rOperacaoMock;
        }


        /// <summary>
        /// Retornar todos os custos para montar a carteira
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        public void Aplicado(DateTime dataInicial, DateTime dataFinal)
        {
            //Todo o dinheiro gasto com compras
        }

        /// <summary>
        /// Retornar o saldo transferido para as corretoras
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        public void Transferido(DateTime dataInicial, DateTime dataFinal)
        {

        }



    }
}
