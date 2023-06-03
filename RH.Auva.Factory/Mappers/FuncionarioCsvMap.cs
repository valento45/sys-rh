using CsvHelper.Configuration;
using RH.Auva.Factory.Mappers.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Mappers
{
    public class FuncionarioCsvMap : ClassMap<FuncionarioCsv>
    {

        public FuncionarioCsvMap()
        {
            Map(m => m.Codigo).Name("Código");
            Map(m => m.Nome).Name("Nome");
            Map(m => m.ValorHora).Name("Valor hora");
            Map(m => m.Data).Name("Data");
            Map(m => m.Entrada).Name("Entrada");
            Map(m => m.Saida).Name("Saída");
            Map(m => m.Almoco).Name("Almoço");
        }
    }
}
