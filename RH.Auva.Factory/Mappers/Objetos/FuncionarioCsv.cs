using CsvHelper.Configuration.Attributes;
using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Mappers.Objetos
{
    public class FuncionarioCsv
    {

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string ValorHora { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Saida { get; set; }
        public string Almoco { get; set; }




        public PontoFuncionarioDomain ToPontoFuncionarioDomain()
        {
            var dateImportacao = DateTime.Now;
            var codigo = this.Codigo;
            decimal valor_hora = 0;

            string valorFormatado = ValorHora.Replace("R$", "").Trim().Replace(", ",",");
            valor_hora = decimal.Parse(valorFormatado);

            var funcionario = new FuncionarioDomain(this.Nome)
            {
                Codigo = codigo,
                DataImportacao = dateImportacao,
                ValorHora = valor_hora
            };


            var ponto = new PontoFuncionarioDomain()
            {
                IdFuncionario = this.Codigo,
                Funcionario = funcionario,
                DataPonto = Data,
                Entrada = Entrada,
                Almoco = Almoco,
                Codigo = Codigo,
                Saida = Saida
            };

            return ponto;
        }
    }
}