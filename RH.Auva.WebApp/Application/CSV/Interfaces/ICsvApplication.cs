using Microsoft.AspNetCore.Mvc;
using RH.Auva.Application.Models.CsvModels;
using RH.Auva.Application.Models.Departamento;

namespace RH.Auva.Application.Application.CSV.Interfaces
{
    public interface ICsvApplication
    {
        /// <summary>
        /// Obter arquivo JSON assincrono
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<FileCsv> GetFileAsync(ImportacaoPontoDepartamentoViewModel obj);  


    }
}
