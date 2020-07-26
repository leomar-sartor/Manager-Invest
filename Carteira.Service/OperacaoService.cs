using Carteira.Domain;
using Carteira.Domain.Contexto;
using Carteira.Domain.Enums;
using Carteira.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Carteira.Service
{
    public class OperacaoService
    {
        private Context _contexto;
        private OperacaoRepository _rOperacao;

        public OperacaoService(Context contexto)
        {
            _contexto = contexto;
            _rOperacao = new OperacaoRepository(_contexto);
        }

        public decimal SaldoQuantidade(Operacao operacao) 
        {
            var Operacoes = _rOperacao.QueriableList().Include(m => m.Ativo).ToList();

            var QuantidadeComprada = Operacoes.Where
                (o => o.Ativo.Id == operacao.Ativo.Id && o.TipoOperacao == TipoOperacao.Compra)
                .Sum(o => o.Quantidade);

            var QuantidadeVendida = Operacoes.Where
                (o => o.Ativo.Id == operacao.Ativo.Id && o.TipoOperacao == TipoOperacao.Venda)
                .Sum(o => o.Quantidade);

            var saldo = (operacao.TipoOperacao == TipoOperacao.Compra) ? (QuantidadeComprada - QuantidadeVendida) + operacao.Quantidade : (QuantidadeComprada - QuantidadeVendida) - operacao.Quantidade;
            return saldo;
        }

        public void Salvar(Operacao operacao)
        {
            operacao.SaldoCotas = SaldoQuantidade(operacao);

            _rOperacao.Adicionar(operacao);
            _rOperacao.Salvar();
        }
    }
}
