using SmartSchedule.Dominio.Dtos;
using SmartSchedule.Dominio.Entidades;
using SmartSchedule.Dominio.Filtros;

namespace SmartSchedule.Dominio.Interfaces
{
	public interface ITarefaServico
	{
		public void CadastrarTarefa(TarefaDTO dto, string userId);

		public List<Tarefas> BuscarPorFiltro(FiltroTarefa filtro, string userId);

		public Tarefas BuscarPorId(int id);

		public void AtualizarTarefa(int id, TarefaDTO dto);

		public void AlterarStatus(int id, AlterarStatusTarefaDTO dto);

		public void ExcluirTarefa(int id);
	}
}
