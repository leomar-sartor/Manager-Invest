using Carteira.Domain.Contexto;
using Carteira.Repository;
using System;
using Carteira.Domain.Enums;
using System.Linq;
using Carteira.Domain.Migrations;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Carteira.Service.Models;

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
            ////Dinheiro Aplicado
            //var Soma = new DepositoDefault()._depositos.Sum(d => d.Valor);

            

        }

        /// <summary>
        /// Retornar o saldo transferido para as corretoras
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        public void Transferido(DateTime dataInicial, DateTime dataFinal)
        {

        }

        public List<PosicaoViewModel> PosicaoFII()
        {
            var operacoes = _rOperacao
                .Buscar(o => o.Ativo.TipoPapel == TipoPapel.FundoImobiliario)
                .ToList();

            var Ativos = operacoes.GroupBy(o => o.Ativo);

            var lista = new List<PosicaoViewModel>();

            foreach (var ativo in Ativos)
            {
                var vm = new PosicaoViewModel();

                var quantidadePorAtivo = ativo.OrderByDescending(a => a.Id).FirstOrDefault().SaldoCotas;

                var custos = (from at in ativo select at.CustoOperacao).Sum();

                var CustoMedio = Math.Round(custos / quantidadePorAtivo, 2);

                var posicao = CustoMedio * quantidadePorAtivo;

                vm.Sigla = ativo.Key.Sigla;
                vm.QuantidadeCotas = quantidadePorAtivo;
                vm.PrecoMedioAquisicao = CustoMedio;
                vm.ValorPosicao = posicao;

                lista.Add(vm);
            }

            return lista;
        }

    }
}
