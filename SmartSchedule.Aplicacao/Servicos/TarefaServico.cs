using SmartSchedule.Dominio.Dtos;
using SmartSchedule.Dominio.Entidades;
using SmartSchedule.Dominio.Filtros;
using SmartSchedule.Dominio.Interfaces;

namespace SmartSchedule.Aplicacao.Servicos
{
	public class TarefaServico : ITarefaServico
	{
		public readonly ITarefaRepositorio tarefaRepositorio;

        public TarefaServico(ITarefaRepositorio tarefaRepositorio)
        {
			this.tarefaRepositorio = tarefaRepositorio;
        }

        public void AlterarStatus(int id, AlterarStatusTarefaDTO dto)
		{
			tarefaRepositorio.AlterarStatus(id, dto);
		}

		public void AtualizarTarefa(int id, TarefaDTO dto)
		{
			tarefaRepositorio.AtualizarTarefa(id, dto);
		}

		public List<Tarefas> BuscarPorFiltro(FiltroTarefa filtro, string userId)
		{
			return tarefaRepositorio.BuscarPorFiltro(filtro, userId);
		}

        public Tarefas BuscarPorId(int id)
        {
			return tarefaRepositorio.BuscarPorId(id);
        }

        public void CadastrarTarefa(TarefaDTO dto, string userId)
		{
			tarefaRepositorio.CriarTarefa(dto, userId);
		}

		public void ExcluirTarefa(int id)
		{
			tarefaRepositorio.ExcluirTarefa(id);
		}
	}
}
