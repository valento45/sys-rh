using Microsoft.AspNetCore.Mvc;
using Rh.Auva.Domain.Funcionarios;
using RH.Auva.Persistence.Repositorys.Interfaces;

namespace RH.Auva.Application.Controllers
{
    public class OrdemPagamentoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public OrdemPagamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _departamentoRepository.GetAllAsync();
            return View(result);
        }


        public async Task<IActionResult> Importar(string base64)
        {
            return View();
        }
    }
}
