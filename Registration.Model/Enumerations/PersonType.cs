using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Model.Enumerations
{
    public enum PersonType
    {
        [Description("Pessoa Física")]
        Individual = 0,

        [Description("Pessoa Jurídica")]
        Company = 1
    }
}
