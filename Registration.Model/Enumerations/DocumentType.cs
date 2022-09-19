using System.ComponentModel;

namespace Registration.Model.Enumerations
{
    public enum DocumentType
    {
        [Description("RG")]
        RG = 0,

        [Description("CPF")]
        CPF = 1,

        [Description("CNH")]
        CNH = 2,

        [Description("CTPS")]
        CTPS = 3

    }
}