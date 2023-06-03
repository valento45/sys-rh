using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.ControlesIndices;
using Rh.Auva.Domain.Funcionarios;
using RH.Auva.Factory.Interfaces;
using RH.Auva.Factory.Mappers;
using RH.Auva.Factory.Mappers.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Factorys
{
    public class CsvFactory : ICsvFactory
    {
        private readonly CsvConfiguration _ConfigurationCsv;

        public CsvFactory(CsvConfiguration csvConfiguration)
        {
            _ConfigurationCsv = csvConfiguration;
        }

        public async Task<IEnumerable<PontoFuncionarioDomain>> ImportarFolhaFuncionarios(byte[] bytes)
        {
            List<PontoFuncionarioDomain> result = new List<PontoFuncionarioDomain>();

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (StreamReader sr = new StreamReader(ms, Encoding.GetEncoding("windows-1254")))
                {
                    using (var csv = new CsvReader(sr, _ConfigurationCsv))
                    {
                        csv.Context.RegisterClassMap<FuncionarioCsvMap>();

                        var list = csv.GetRecords<FuncionarioCsv>();

                        foreach(var item in list)
                        {
                            result.Add(item.ToPontoFuncionarioDomain());
                        }                        

                        return result;
                    }
                }
            }


            throw new Exception(nameof(CsvFactory));
        }

    }
}
