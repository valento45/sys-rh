using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.Departamentos;
using Rh.Auva.Domain.Extensions;

namespace Rh.Auva.Domain.ControlesIndices
{
    /// <summary>
    /// 
    /// </summary>
    public class DepartamentoRendimentoDomain
    {
        public DepartamentoDomain Departamento { get; private set; }
        public string MesVigencia
        {
            get
            {
                if (Departamento?.PontoFuncionarios?.Any() ?? false)
                    return Departamento?.PontoFuncionarios?.FirstOrDefault()?.DataPonto.Month.GetMesExtenso() ?? "";

                return "";
            }
        }
        public int AnoVigencia
        {
            get
            {

                if (Departamento?.PontoFuncionarios?.Any() ?? false)
                    return Departamento?.PontoFuncionarios?.FirstOrDefault()?.DataPonto.Year ?? -1;

                return -1;

            }
        }
        public decimal TotalPagar { get; set; }
        public decimal TotalDescontos { get; set; }
        public decimal TotalExtras { get; set; }


        public void InformarDepartamento(DepartamentoDomain departamento)
        {
            Departamento = departamento;
        }

        public void InformarPontosFuncionario(List<PontoFuncionarioDomain> pontosFuncionario)
        {
            if (Departamento != null)
                Departamento.InformarPontosFuncionario(pontosFuncionario);
        }
    }
}
