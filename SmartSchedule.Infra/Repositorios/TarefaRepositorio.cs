using SmartSchedule.Dominio.Dtos;
using SmartSchedule.Dominio.Enums;
using SmartSchedule.Dominio.Entidades;
using SmartSchedule.Dominio.Filtros;
using SmartSchedule.Dominio.Interfaces;
using SmartSchedule.Infra.Contexto;

namespace SmartSchedule.Infra.Repositorios
{
	public class TarefaRepositorio : ITarefaRepositorio
	{
		private readonly AppDbContext context;

		public TarefaRepositorio(AppDbContext context)
        {
			this.context = context;
        }

        public Tarefas BuscarPorId(int id)
        {
			return context.Tarefas.Find(id);
        }

        public void CriarTarefa(TarefaDTO dto, string userId)
		{
			DateTime hoje = DateTime.Now;

			Tarefas novaTarefa = new Tarefas
			{
				Titulo = dto.Titulo,
				Descricao = dto.Descricao,
				DataDeCriacao = hoje,
				DataInicio = hoje,
				Prioridade = dto.Prioridade,
				StatusTarefa = EStatusTarefa.EmProgresso,
				Categoria = dto.Categoria,
				Responsavel_id = userId
			};

			context.Tarefas.Add(novaTarefa);
			context.SaveChanges();
		}

		public void ExcluirTarefa(int id)
		{
			Tarefas tarefa = context.Tarefas.Find(id);
			context.Remove(tarefa);
			context.SaveChanges();
		}

		void ITarefaRepositorio.AlterarStatus(int id, AlterarStatusTarefaDTO dto)
		{
			Tarefas tarefas = context.Tarefas.Find(id);
            DateTime hoje = DateTime.Now;

            tarefas.StatusTarefa = dto.Status;

			if (dto.Status == EStatusTarefa.Concluida)
			{
				tarefas.DataConclusao = hoje;
			}
			else
			{
				tarefas.DataConclusao = null;
			}

			context.Update(tarefas);
			context.SaveChanges();
		}

		void ITarefaRepositorio.AtualizarTarefa(int id, TarefaDTO dto)
		{
			Tarefas tarefas = context.Tarefas.Find(id);

			tarefas.Titulo = dto.Titulo;
			tarefas.Descricao = dto.Descricao;
			tarefas.Prioridade = dto.Prioridade;
			tarefas.Categoria = dto.Categoria;

			context.Update(tarefas);
			context.SaveChanges();
		}

		List<Tarefas> ITarefaRepositorio.BuscarPorFiltro(FiltroTarefa filtro, string userId)
		{
			var query = context.Tarefas.AsQueryable();

			if (!String.IsNullOrEmpty(filtro.Titulo))
			{
				query = query.Where(x => x.Titulo.Contains(filtro.Titulo));
			}

			if (filtro.DataInicial != null && filtro.DataFinal != null)
			{
				query = query.Where(e => e.DataInicio.Value.Date >= filtro.DataInicial.Value.Date && e.DataInicio.Value.Date <= filtro.DataFinal.Value.Date);
			}

			if (filtro.Categoria != null)
			{
				query = query.Where(e => e.Categoria == filtro.Categoria);
			}

			if (filtro.Status != null)
			{
				query = query.Where(e => e.StatusTarefa == filtro.Status);
			}

			return query.Where(e => e.Responsavel_id == userId)
				.Select(x => new Tarefas
				{
					Id = x.Id,
					Titulo = x.Titulo,
					Descricao = x.Descricao,
					DataDeCriacao = x.DataDeCriacao,
					DataInicio = x.DataInicio,
					DataConclusao = x.DataConclusao,
					Prioridade = x.Prioridade,
					StatusTarefa = x.StatusTarefa,
					Categoria = x.Categoria
				}).ToList();
		}
	}
}
