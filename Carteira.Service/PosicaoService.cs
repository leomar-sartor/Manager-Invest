using Carteira.Domain.Contexto;
using Carteira.Domain.Enums;
using Carteira.Repository;
using Carteira.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        }

        public List<PosicaoViewModel> PosicaoFII()
        {
            var lista = new List<PosicaoViewModel>();

            var operacoes = _rOperacao
                .Buscar(o => o.Ativo.TipoPapel == TipoPapel.FundoImobiliario)
                .ToList();

            var Ativos = operacoes.GroupBy(o => o.Ativo);

            foreach (var ativo in Ativos)
            {
                var vm = new PosicaoViewModel();

                var UltimoRegistro = ativo
                    .OrderByDescending(a => a.Id)
                    .FirstOrDefault();

                var SaldoCotas = UltimoRegistro.SaldoCotas;
                var PrecoMedio = UltimoRegistro.PrecoMedioDoAtivo;

                vm.Sigla = ativo.Key.Sigla;
                vm.QuantidadeCotas = SaldoCotas;
                vm.PrecoMedioAquisicao = PrecoMedio;
                vm.ValorPosicao = SaldoCotas * PrecoMedio;

                lista.Add(vm);
            }

            var totalFII = lista.Sum(m => m.ValorPosicao);

            foreach (var item in lista)
            {
                item.Percentagem = (item.ValorPosicao * 100) / totalFII ;
            }

            return lista; 
        }
    }
}
