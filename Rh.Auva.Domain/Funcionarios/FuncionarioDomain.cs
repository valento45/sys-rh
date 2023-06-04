using Newtonsoft.Json;
using Rh.Auva.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Funcionarios
{
    public class FuncionarioDomain : PessoaFisica, IEqualityComparer<FuncionarioDomain>
    {
        #region PROPRIEDADE
        public int Codigo { get; set; }    
        public decimal ValorHora { get; set; }

        [JsonIgnore]
        public int CodigoDepartamento { get; set; }

        [JsonIgnore]
        public DateTime DataImportacao { get; set; }

        #endregion

        #region CONSTRUTORES
        public FuncionarioDomain(string nome) : base(nome)
        {

        }


        #endregion


        #region Metodos Publicos
        public bool Equals(FuncionarioDomain? x, FuncionarioDomain? y)
        {
            return x?.Codigo == y?.Codigo;
        }

        public int GetHashCode([DisallowNull] FuncionarioDomain obj)
        {
            return
                 obj.Codigo.GetHashCode() +
                 obj.GetHashCode();
        }

        #endregion
    }
}
