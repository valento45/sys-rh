using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
                if (PontoFuncionarios?.Any() ?? false)
                    return PontoFuncionarios?.FirstOrDefault()?.DataPonto.Month.GetMesExtenso() ?? "";

                return "";
            }
        }
        public int AnoVigencia
        {
            get
            {

                if (PontoFuncionarios?.Any() ?? false)
                    return PontoFuncionarios?.FirstOrDefault()?.DataPonto.Year ?? -1;

                return -1;

            }
        }
        public decimal TotalPagar { get; set; }
        public decimal TotalDescontos { get; set; }
        public decimal TotalExtras { get; set; }

        [JsonIgnore]
        public List<PontoFuncionarioDomain> PontoFuncionarios { get; private set; }

        [JsonProperty("Funcionarios")]
        public List<ResumoDePontosFuncionarioDomain> ResumoPontoFuncionarios { get; set; }


        public void InformarDepartamento(DepartamentoDomain departamento)
        {
            Departamento = departamento;
        }

        public void InformarPontosFuncionario(List<PontoFuncionarioDomain> pontosFuncionario)
        {
            PontoFuncionarios = pontosFuncionario;
        }

        public void Calcular()
        {

            if (ResumoPontoFuncionarios == null)
                ResumoPontoFuncionarios = new List<ResumoDePontosFuncionarioDomain>();

            PontoFuncionarios.ForEach(x => x.Calcular());


            TotalPagar = PontoFuncionarios.Sum(x => x.TotalPagarDia);
            TotalDescontos = PontoFuncionarios.Sum(x => x.TotalDescontoDia);
            TotalExtras = PontoFuncionarios.Sum(x => x.TotalExtraDia);

            int month = 0, year = 0;
            foreach (var ponto in PontoFuncionarios)
            {
                var resumoPonto = new ResumoDePontosFuncionarioDomain();
                 resumoPonto.Funcionario = ponto.Funcionario;
                resumoPonto.DiasTrabalhados++;

                if (ResumoPontoFuncionarios.Any(x => x.Funcionario.Codigo == ponto.Funcionario.Codigo))
                {
                    var obter = ResumoPontoFuncionarios.First(x => x.Funcionario.Codigo == ponto.Funcionario.Codigo);
                    obter.DiasTrabalhados += resumoPonto.DiasTrabalhados;

                    obter.HorasExtras += ponto.HorasExtras;
                    obter.HorasDebito += ponto.HorasDebito;
                    obter.TotalReceber += ponto.TotalPagarDia;
                }
                else
                    ResumoPontoFuncionarios.Add(resumoPonto);

                month = ponto.DataPonto.Month;
                year = ponto.DataPonto.Year;
            }


            if (month > 0 && year > 0)
            {
                ResumoPontoFuncionarios.ForEach(x => x.DiasExtras = (x.DiasTrabalhados - ObterTotalDiasUteis(year, month)) > 0 ? x.DiasTrabalhados - ObterTotalDiasUteis(year, month) : 0);
                ResumoPontoFuncionarios.ForEach(x => x.DiasFalta = (ObterTotalDiasUteis(year, month) - x.DiasTrabalhados) > 0 ? (ObterTotalDiasUteis(year, month) - x.DiasTrabalhados) : 0);
            }
        }

        public int ObterTotalDiasUteis(int year, int month)
        {
            int days = 0;

            DateTime startDate = DateTime.Parse($"01/{month}/{year}");

            while (startDate.Date.Month == month)
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday
                   && startDate.DayOfWeek != DayOfWeek.Sunday)
                    days++;

                startDate = startDate.AddDays(1);
            }

            return days;
        }
    }
}
