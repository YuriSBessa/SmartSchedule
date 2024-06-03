using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartSchedule.Dominio.Dtos;
using SmartSchedule.Dominio.Entidades;
using SmartSchedule.Dominio.Enums;
using SmartSchedule.Dominio.Filtros;
using SmartSchedule.Dominio.Interfaces;
using SmartSchedule.Dominio.ViewModel;
using SmartSchedule.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SmartSchedule.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public readonly ITarefaServico tarefaServico;

        public HomeController(ITarefaServico tarefaServico)
        {
			this.tarefaServico = tarefaServico;
        }

        public IActionResult Index(FiltroTarefa filtro, int id)
		{
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Tarefas> tarefas = tarefaServico.BuscarPorFiltro(filtro, userId);

			var model = (new TarefaViewModel{ Filtro = filtro, Tarefas = tarefas  });
			return View("Index", model);
		}

        public IActionResult AlterarTarefa(int id)
        {
			Tarefas tarefas = tarefaServico.BuscarPorId(id);
			return View("AlterarTarefa", tarefas);
        }

		public IActionResult AlterarStatus(int id)
		{
            Tarefas tarefas = tarefaServico.BuscarPorId(id);
            return View("AlterarStatus", tarefas);
        }

        [HttpPost]
        public IActionResult Exibir(FiltroTarefa filtro)
        {
            return RedirectToAction("Index", filtro);
        }

        public IActionResult Cadastrar()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Cadastrar(TarefaDTO dto)
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			tarefaServico.CadastrarTarefa(dto, userId);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Alterar(int id, TarefaDTO dto)
		{
			tarefaServico.AtualizarTarefa(id, dto);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult AlterarStatusTarefa(int id, AlterarStatusTarefaDTO dto)
		{
			tarefaServico.AlterarStatus(id, dto);
			return RedirectToAction("Index");
		}


        public IActionResult DeletarTarefa(int id)
		{
			tarefaServico.ExcluirTarefa(id);
			return RedirectToAction("Index");
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
