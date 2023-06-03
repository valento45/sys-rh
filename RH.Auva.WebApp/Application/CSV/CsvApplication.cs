using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Rh.Auva.Domain.ControlesIndices;
using RH.Auva.Application.Application.CSV.Interfaces;
using RH.Auva.Application.Models.CsvModels;
using RH.Auva.Application.Models.Departamento;
using RH.Auva.Factory.Command.Interfaces;
using RH.Auva.Persistence.Repositorys.Interfaces;

namespace RH.Auva.Application.Application.CSV
{
    public class CsvApplication : ICsvApplication
    {
        private readonly ICsvCommand _csvCommand;
        private readonly IDepartamentoRepository _departamentoRepository;

        public CsvApplication(ICsvCommand csvCommand, IDepartamentoRepository departamentoRepository)
        {
            _csvCommand = csvCommand;
            _departamentoRepository = departamentoRepository;
        }


        public async Task<FileCsv> GetFileAsync(ImportacaoPontoDepartamentoViewModel obj)
        {
            var result = new FileCsv();
            result.Filename = $"PontosFuncionarios_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm")}.json";

            using (var ms = new MemoryStream())
            {
                await obj.File.CopyToAsync(ms);
                result.Bytes = ms.ToArray();
            }

            var dptoRendimento = new DepartamentoRendimentoDomain();
            dptoRendimento.InformarDepartamento(await _departamentoRepository.GetByIdAsync(obj.IdDepartamentoSelecionao));

            var pontosfuncionario = await _csvCommand.ImportarPontosFuncionario(result.Bytes);
            dptoRendimento.InformarPontosFuncionario(pontosfuncionario.ToList());


            return result;

        }
    }
}
