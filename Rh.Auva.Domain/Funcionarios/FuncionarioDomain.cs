using Rh.Auva.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Funcionarios
{
    public class FuncionarioDomain : PessoaFisica
    {
        #region PROPRIEDADE
        public int Codigo { get; set; }
        public decimal ValorHora { get; set; }
        public DateTime DataImportacao { get; set; }
        #endregion

        #region CONSTRUTORES
        public FuncionarioDomain(string nome) : base(nome)
        {

        }
       
        #endregion
    }
}
