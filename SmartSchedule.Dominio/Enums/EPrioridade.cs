using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchedule.Dominio.Enums
{
    public enum EPrioridade : byte
    {
        [Description("Baixa")]
        Baixa = 0,

        [Description("Media")]
        Media = 1,

        [Description("Alta")]
        Alta = 2
    }
}
