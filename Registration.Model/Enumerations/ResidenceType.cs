using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Model.Enumerations
{
    public enum ResidenceType
    {
        [Description("Propria")]
        Owner = 0,

        [Description("Alugada")]
        Rent = 1
    }
}
