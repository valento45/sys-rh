using Rh.Auva.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.ControlePonto
{
    public class ResumoDePontosFuncionarioDomain
    {
        public FuncionarioDomain Funcionario { get; set; }
        public decimal TotalReceber { get; set; }
        public double HorasExtras { get; set; }
        public double HorasDebito { get; set; }
        public int DiasFalta { get; set; }
        public int DiasExtras { get; set; }
        public int DiasTrabalhados { get; set; }

    }
}
