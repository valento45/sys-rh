using Rh.Auva.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Departamentos
{
    public class Departamento
    {
        #region Propriedades 
        public int Codigo { get; set; }
        public string NomeDepartamento { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

        #endregion


        #region Construtores
        public Departamento()
        {
            Funcionarios = new List<Funcionario>();
        }

        #endregion
    }
}
