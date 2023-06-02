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
        public async Task<IActionResult> Index()
        {

            var result = await _departamentoRepository.GetAllAsync();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Incluir()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] Departamento departamento)
        {

            if (departamento.Codigo > 0)
                return Ok(await _departamentoRepository.AtualizarAsync(departamento));

            else
                return Ok(await _departamentoRepository.InserirAsync(departamento));

        }



        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var result = await _departamentoRepository.GetByIdAsync(id);

            return View("Incluir", result);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir([FromBody] int codigo)
        {
            return Ok(await _departamentoRepository.ExcluirAsync(codigo));
        }


        [HttpGet]
        public async Task<IActionResult> ListarDepartamentosPartial(string filtro = "")
        {
            var result = await _departamentoRepository.GetAllAsync(filtro);
            return PartialView("Departamento/Partial/ListaDepartamentosPartial", result); ;
        }

    }
}
