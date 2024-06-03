using SmartSchedule.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchedule.Dominio.Dtos
{
	public class TarefaDTO
	{
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public EPrioridade Prioridade { get; set; }
        public ECategoria Categoria { get; set; }
    }
}
