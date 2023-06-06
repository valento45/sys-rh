using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.ControlesIndices;
using Rh.Auva.Domain.Departamentos;
using RH.Auva.Application.Application.CSV.Interfaces;
using RH.Auva.Application.Models.CsvModels;
using RH.Auva.Application.Models.Departamento;
using RH.Auva.Factory.Command.Interfaces;
using RH.Auva.Factory.Factorys.Interfaces;
using RH.Auva.Persistence.Repositorys.Interfaces;
using System.Text.Json.Serialization;

namespace RH.Auva.Application.Application.CSV
{
    public class CsvApplication : ICsvApplication
    {
        private readonly ICsvCommand _csvCommand;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IFuncionarioRepository _funcionario;
        private readonly IResumoFinanceiroDepartamentoFactory _resumoFinanceiroDepartamentoFactory;

        public CsvApplication(ICsvCommand csvCommand, IDepartamentoRepository departamentoRepository,
            IFuncionarioRepository funcionario, IResumoFinanceiroDepartamentoFactory resumoFinanceiroDepartamentoFactory)
        {
            _csvCommand = csvCommand;
            _departamentoRepository = departamentoRepository;
            _funcionario = funcionario;
            _resumoFinanceiroDepartamentoFactory = resumoFinanceiroDepartamentoFactory;
        }


        /// <summary>
        /// Obtem os bytes do arquivo IFormFile carregado pelo usuario
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        private async Task<byte[]> ObterBytes(IFormFile formFile)
        {
            byte[] result;
            using (var ms = new MemoryStream())
            {
                await formFile.CopyToAsync(ms);
                result = ms.ToArray();
            }

            return result;
        }


        private async static Task<byte[]> ExportarJson<T>(T objeto)
        {
            byte[] result;

            using (MemoryStream ms = new MemoryStream())
            {
                using (TextWriter textWriter = new StreamWriter(ms))
                {
                    await textWriter.WriteAsync(JsonConvert.SerializeObject(objeto));
                    await textWriter.FlushAsync();

                    result = ms.ToArray();
                }
            }

            return result;
        }


        private async Task<DepartamentoRendimentoDomain> ObterResumoFinanceiro(DepartamentoDomain departamento, IFormFile file)
        {
            var pontosfuncionario = await _csvCommand.ImportarPontosFuncionario(await ObterBytes(file));
            await _funcionario.InserirAllAsync(pontosfuncionario.Select(x => x.Funcionario));

            var resumoFinanceiro =
                    await _resumoFinanceiroDepartamentoFactory.Calcular(departamento, pontosfuncionario);

            return resumoFinanceiro;
        }

        public async Task<FileCsv> GetFileAsync(ImportacaoPontoDepartamentoViewModel obj)
        {
            List<DepartamentoRendimentoDomain> rendimentoDepartamentos =
                new List<DepartamentoRendimentoDomain>();

            foreach (var file in obj.File)
            {
                var dadosArquivo = file.FileName.Split("-");

                string nomeDepartamento = dadosArquivo.First();

                if (! await _departamentoRepository.Exists(nomeDepartamento))
                {
                    _ = _departamentoRepository.InserirAsync(
                       new DepartamentoDomain { NomeDepartamento = nomeDepartamento });
                }

                var departamento = await _departamentoRepository.GetByNome(nomeDepartamento);

                rendimentoDepartamentos.Add(await ObterResumoFinanceiro(departamento, file));
            }

            var result = new FileCsv();
            result.Filename = $"PontosFuncionarios_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm")}.json";
            result.Bytes = await ExportarJson(rendimentoDepartamentos);

            return result;

        }

    }
}
