using Rh.Auva.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Funcionarios
{
    public class Funcionario : PessoaFisicaAbstract
    {
        #region PROPRIEDADE
        public int Codigo { get; set; }
        public decimal TotalReceber { get; set; }
        public double HorasExtras { get; set; }
        public double HorasDebitos { get; set; }
        public int DiasFalta { get; set; }
        public int DiasExtra { get; set; }
        public int DiasTrabalhados { get; set; }
        #endregion

        #region CONSTRUTORES
        public Funcionario(string nome) : base(nome)
        {

        }

        #endregion
    }
}
