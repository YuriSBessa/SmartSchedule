using SmartSchedule.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchedule.Dominio.Filtros
{
	public class FiltroTarefa
	{
        public string? Titulo { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public ECategoria? Categoria { get; set; }
        public EStatusTarefa? Status { get; set; }
    }
}
