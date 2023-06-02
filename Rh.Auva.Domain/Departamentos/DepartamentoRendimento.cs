using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Departamentos
{
    public class DepartamentoRendimento
    {
        public Departamento Departamento { get; set; }
        public string MesVigencia { get; set; }
        public int AnoVigencia { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal TotalDescontos { get; set; }
        public decimal TotalExtras { get; set; }
    }
}
