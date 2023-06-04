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

        public TimeSpan InicioAlmoco
        {
            get
            {
                return TimeSpan.Parse(Almoco.Split(" - ")[0]);
            }
        }

        public TimeSpan FimAlmoco
        {
            get
            {
                return TimeSpan.Parse(Almoco.Split(" - ")[1]);
            }
        }



        public FuncionarioDomain Funcionario
        {
            get
            {
                return _funcionario;
            }
            set { _funcionario = value; }
        }


        public decimal TotalPagarDia { get; set; }
        public decimal TotalDescontoDia { get; set; }
        public decimal TotalExtraDia { get; set; }


        public double HorasExtras
        {
            get
            {
                if (((Saida - FimAlmoco) + (InicioAlmoco - Entrada)).TotalHours > 9)
                    return ((Saida - FimAlmoco) + (InicioAlmoco - Entrada)).TotalHours - 9;

                return 0;
            }
        }
        public double HorasDebito
        {
            get
            {
                if (((Saida - FimAlmoco) + (InicioAlmoco - Entrada)).TotalHours < 9)
                    return 9 - ((Saida - FimAlmoco) + (InicioAlmoco - Entrada)).TotalHours;

                return 0;
            }
        }

        public PontoFuncionarioDomain()
        {

        }

        public void Calcular()
        {
            var totalHoras = ((Saida - FimAlmoco) + (InicioAlmoco - Entrada));
            TotalPagarDia = _funcionario.ValorHora * decimal.Parse(totalHoras.TotalHours.ToString());

            if (TotalPagarDia < _funcionario.ValorHora * 9)
                TotalDescontoDia = _funcionario.ValorHora * 9 - TotalPagarDia;

            else if (TotalPagarDia > _funcionario.ValorHora * 9)
                TotalExtraDia = (TotalPagarDia - _funcionario.ValorHora * 9);

        }


    }
}
