using System.ComponentModel;

namespace SmartSchedule.Dominio.Enums
{
	public enum EStatusTarefa : byte
	{
		[Description("Pendente")]
		Pendente = 0,

		[Description("Em progresso")]
		EmProgresso = 1,

		[Description("Concluida")]
		Concluida = 2,

		[Description("Cancelada")]
		Cancelada = 3
	}
}
