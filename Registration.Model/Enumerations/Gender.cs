using System.ComponentModel;

namespace Registration.Model.Enumerations
{
    public enum Gender
    {
        [Description("Não informado")]
        NotInformed = 0,

        [Description("Masculino")]
        Male = 1,

        [Description("Feminino")]
        Female = 2
    }
}