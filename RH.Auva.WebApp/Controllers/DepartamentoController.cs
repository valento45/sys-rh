using Microsoft.AspNetCore.Mvc;
using Rh.Auva.Domain.Departamentos;
using RH.Auva.Persistence.Repositorys;
using RH.Auva.Persistence.Repositorys.Interfaces;

namespace RH.Auva.WebApp.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository rendimentosDepartamentoRepository)
        {
            _departamentoRepository = rendimentosDepartamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Incluir()
        {         

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Departamento departamento)
        {
            
            return Ok(await _departamentoRepository.InserirRendimentoAsync(departamento));
            
        }


        [HttpPost]
        public async Task<IActionResult> Excluir([FromBody] int codigo)
        {
            return Ok(await _departamentoRepository.ExcluirAsync(codigo));
        }


    }
}
