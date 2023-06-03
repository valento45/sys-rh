using Rh.Auva.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.ControlePonto
{
    public class PontoFuncionarioDomain
    {
        private FuncionarioDomain _funcionario { get; set; }
        public int Codigo { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Saida { get; set; }
        public string Almoco { get; set; }
        public DateTime DataPonto { get; set; }
        public int IdFuncionario { get; set; }

        public FuncionarioDomain Funcionario
        {
            get
            {              
                return _funcionario;
            }
            set { _funcionario = value; }
        }


        public PontoFuncionarioDomain()
        {
            
        }




    }
}
