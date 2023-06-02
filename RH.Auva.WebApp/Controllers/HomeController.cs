using Microsoft.AspNetCore.Mvc;
using RH.Auva.Persistence.Repositorys.Interfaces;
using RH.Auva.WebApp.Models;
using System.Diagnostics;

namespace RH.Auva.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartamentoRepository _departamentoRepository;

        public HomeController(ILogger<HomeController> logger, IDepartamentoRepository departamentoRepository)
        {
            _logger = logger;
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _departamentoRepository.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }   
        public async Task<IActionResult> About()
        {
            return View();
        }

        
    }
}