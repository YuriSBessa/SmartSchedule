using System.ComponentModel;

namespace SmartSchedule.Dominio.Enums
{
	public enum ECategoria : int
	{
		[Description("Pessoal")]
		Pessoal = 0,

		[Description("Profissional")]
		Profissional = 1,

		[Description("Financeiro")]
		Financeiro = 2,

		[Description("Casa e familia")]
		CasaEFamilia = 3,

		[Description("Saúde")]
		Saude = 4,

		[Description("Viagem e lazer")]
		ViagensELazer = 5,

		[Description("Tecnologia")]
		Tecnologia = 6,

		[Description("Social e comunitario")]
		SocialEComunitario = 7,

		[Description("Estudantil")]
		Estudantil = 8,

		[Description("Projetos específicos")]
		ProjetosEspecificos = 9,

		[Description("Marketing")]
		Marketing = 10,

		[Description("Eventos")]
		Eventos = 11
	}
}
