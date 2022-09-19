using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Model.Enumerations
{
    public enum OccupationType
    {
        [Description("Empregado do setor privado")]
        PrivateEmployee = 0,

        [Description("Empregado do setor público")]
        PublicEmployee = 1,

        [Description("Empregador/Empresário")]
        Employer = 2,

        [Description("Rentista")]
        Capitalist = 3,

        [Description("Militar")]
        Military = 4,

        [Description("Profissional liberal/Autônomo")]
        Autonomous = 5,

        [Description("Outros")]
        Other = 6
    }
}
