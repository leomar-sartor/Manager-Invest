using Carteira.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carteira.Testes.Utilitarios.ObjectDefault
{
    public class DepositoDefault
    {
        public List<Deposito> _depositos = new List<Deposito>();
        public List<Corretora> _corretoras = new CorretoraDefault()._corretoras;
        public DepositoDefault() => BuildDeposito();

        private void BuildDeposito()
        {
            var XP = _corretoras.Where(a => a.Nome == "XP Investimentos").First();
            var CLEAR = _corretoras.Where(a => a.Nome == "Clear Corretora").First();

            var DepositoOne = new Deposito(new DateTime(2019, 06, 13), 150.00M, XP);
            var DepositoTwo = new Deposito(new DateTime(2019, 10, 08), 150.00M, XP);
            var DepositoThree = new Deposito(new DateTime(2019, 10, 08), 150.00M, CLEAR);
            var DepositoFour = new Deposito(new DateTime(2019, 11, 12), 100.00M, XP);
            var DepositoFive = new Deposito(new DateTime(2019, 12, 26), 300.00M, CLEAR);
            var DepositoSix = new Deposito(new DateTime(2020, 01, 14), 150.00M, CLEAR);
            var DepositoSeven = new Deposito(new DateTime(2020, 02, 11), 174.00M, XP);
            var DepositoEight = new Deposito(new DateTime(2020, 03, 11), 210.00M, XP);
            var DepositoNine = new Deposito(new DateTime(2020, 03, 11), 58.00M, CLEAR);
            var DepositoTen = new Deposito(new DateTime(2010, 03, 19), 30.00M, CLEAR);
            var DepositoEleven = new Deposito(new DateTime(2020, 04, 07), 165.00M, XP);
            var DepositoTwelve = new Deposito(new DateTime(2020, 04, 07), 45.00M, CLEAR);

            _depositos.AddRange(new List<Deposito> { DepositoOne, DepositoTwo, DepositoThree, DepositoFour,
                                                     DepositoFive, DepositoSix, DepositoSeven, DepositoEight,
                                                     DepositoNine, DepositoTen, DepositoEleven, DepositoTwelve
                                                    });
        }
    }
}
