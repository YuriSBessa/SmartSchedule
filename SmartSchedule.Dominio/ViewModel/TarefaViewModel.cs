using SmartSchedule.Dominio.Entidades;
using SmartSchedule.Dominio.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchedule.Dominio.ViewModel
{
    public class TarefaViewModel
    {
        public FiltroTarefa? Filtro { get; set; }
        public List<Tarefas> Tarefas { get; set; }
    }
}
