using Carteira.Domain;
using Carteira.Domain.Contexto;
using Carteira.Domain.Enums;
using Carteira.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Carteira.Service
{
    public class OperacaoService
    {
        private Context _contexto;
        private OperacaoRepository _rOperacao;
        private ApuracaoRepository _rApuracao;
        private PosicaoService _sPosicao;

        public OperacaoService(Context contexto)
        {
            _contexto = contexto;
            _rOperacao = new OperacaoRepository(_contexto);
            _rApuracao = new ApuracaoRepository(_contexto);
            _sPosicao = new PosicaoService(_contexto);
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

            var saldo = (operacao.TipoOperacao == TipoOperacao.Compra) 
                ? (QuantidadeComprada - QuantidadeVendida) + operacao.Quantidade 
                : (QuantidadeComprada - QuantidadeVendida) - operacao.Quantidade;

            return saldo;
        }

        public decimal PrecoMedio(Operacao operacao)
        {
            var Operacoes = _rOperacao
                .QueriableList()
                .Where(m => m.Ativo == operacao.Ativo)
                .ToList();

            var calculo =
                ((operacao.Quantidade * operacao.PrecoUnitario) +
                operacao.Corretagem + operacao.Emolumentos + operacao.TaxaLiquidacao) / operacao.Quantidade;

            var precoMedioOperacao = Math.Round(calculo, 2);

            decimal precoMedio = 0M;

            var ultimoOperacao = Operacoes.OrderByDescending(m => m.Id).FirstOrDefault();

            if (operacao.TipoOperacao == TipoOperacao.Compra)
            {
                if (Operacoes.Count == 0)
                {
                    precoMedio = precoMedioOperacao;

                    return precoMedio;
                }
                else
                {
                    var ultimoPrecoMedio = ultimoOperacao.PrecoMedioDoAtivo;
                    var ultimoSaldoQuantidade = ultimoOperacao.SaldoCotas;

                    var somaPrecoMedio = (ultimoPrecoMedio * ultimoSaldoQuantidade) + (precoMedioOperacao * operacao.Quantidade);
                    var somaQuantidade = (ultimoSaldoQuantidade + operacao.Quantidade);
                    var novoPrecoMedio = (somaPrecoMedio / somaQuantidade);

                    var result = Math.Round(novoPrecoMedio, 2);
                    return result;
                }
            }
            else
            {
                return ultimoOperacao.PrecoMedioDoAtivo;
            }
        }

        public Apuracao ApurarLucroPrejuizo(Operacao operacao)
        {
            var posicaoAtivo = _sPosicao.PosicaoFII()
                .Where(m => m.Sigla == operacao.Ativo.Sigla)
                .FirstOrDefault();

            decimal numeroDeCotasVendidas = operacao.Quantidade;
            decimal precoDeVenda = operacao.PrecoUnitario;
            decimal precoMedioDeCompra = posicaoAtivo.PrecoMedioAquisicao;
            decimal custos = operacao.Corretagem + operacao.Emolumentos + operacao.TaxaLiquidacao;

            decimal custoMedioVenda;
            decimal valorApurado;
            if (precoDeVenda > precoMedioDeCompra)
            {
                custoMedioVenda = Math.Round((numeroDeCotasVendidas * precoDeVenda) / numeroDeCotasVendidas, 2);
                valorApurado = (custoMedioVenda - precoMedioDeCompra) * numeroDeCotasVendidas - custos;
            }
            else
            {
                custoMedioVenda = Math.Round((numeroDeCotasVendidas * precoDeVenda) / numeroDeCotasVendidas, 2);
                valorApurado = (((precoMedioDeCompra - custoMedioVenda) * numeroDeCotasVendidas) + custos) * -1;
            }
               
            var apuracao = new Apuracao(operacao.Data.Month, operacao.Data.Year, valorApurado);
            
            return apuracao;
        }

        public void Salvar(Operacao operacao)
        {
            operacao.SaldoCotas = SaldoQuantidade(operacao);
            operacao.PrecoMedioDoAtivo = PrecoMedio(operacao);

            if(operacao.TipoOperacao == TipoOperacao.Venda)
            {
                operacao.Apuracao = ApurarLucroPrejuizo(operacao);
            }

            _rOperacao.Adicionar(operacao);
            _rOperacao.Salvar();
        }
    }
}
