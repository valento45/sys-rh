using Microsoft.AspNetCore.Mvc;
using Rh.Auva.Domain.Funcionarios;
using RH.Auva.Application.Application.CSV.Interfaces;
using RH.Auva.Application.Models.Departamento;
using RH.Auva.Factory.Command.Interfaces;
using RH.Auva.Persistence.Repositorys.Interfaces;
using System.Web;

namespace RH.Auva.Application.Controllers
{
    public class ControlePontoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly ICsvApplication _csvApplication;

        public ControlePontoController(IDepartamentoRepository departamentoRepository, ICsvApplication csvApplication)
        {
            _departamentoRepository = departamentoRepository;
            _csvApplication = csvApplication;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = new ImportacaoPontoDepartamentoViewModel();
            result.Departamentos = await _departamentoRepository.GetAllAsync();

            return View(result);
        }


        [HttpPost]
        public async Task<FileResult> Importar(ImportacaoPontoDepartamentoViewModel fileData)
        {
            if (fileData?.File != null)
            {
                var file = await _csvApplication.GetFileAsync(fileData);

                return File(file.Bytes, "application/json", file.Filename);
            }

            else
                throw new ArgumentNullException("Nenhum arquivo selecionado!", new Exception(nameof(ControlePontoController)));
        }
    }
}
