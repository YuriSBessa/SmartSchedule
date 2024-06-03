using SmartSchedule.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchedule.Dominio.Entidades
{
	public class Tarefas
	{
		[Key]
        public int Id { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public DateTime DataDeCriacao { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataConclusao { get; set; }

        [Required]
        public EPrioridade Prioridade { get; set; }

        [Required]
        public EStatusTarefa StatusTarefa { get; set; }

        public ECategoria Categoria { get; set; }

        [Required]
        public string? Responsavel_id { get; set; }

        public Tarefas(string? titulo, string? descricao, DateTime dataDeCriacao, DateTime? dataInicio, DateTime? dataConclusao, EPrioridade prioridade, EStatusTarefa statusTarefa, ECategoria categoria, string? responsavel_id)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.DataDeCriacao = dataDeCriacao;
            this.DataInicio = dataInicio;
            this.DataConclusao = dataConclusao;
            this.Prioridade = prioridade;
            this.StatusTarefa = statusTarefa;
            this.Categoria = categoria;
            this.Responsavel_id = responsavel_id;
        }

        public Tarefas(int id, string? titulo, string? descricao, DateTime dataDeCriacao, DateTime? dataInicio, DateTime? dataConclusao, EPrioridade prioridade, EStatusTarefa statusTarefa, ECategoria categoria)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.DataDeCriacao = dataDeCriacao;
            this.DataInicio = dataInicio;
            this.DataConclusao = dataConclusao;
            this.Prioridade = prioridade;
            this.StatusTarefa = statusTarefa;
            this.Categoria = categoria;
        }

        public Tarefas()
        {
            
        }
    }
}
