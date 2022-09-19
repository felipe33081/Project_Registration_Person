using System.ComponentModel;

namespace Registration.Model.Enumerations
{
    /// <summary>
    /// Estado Civil
    /// </summary>
    public enum CivilStatus
    {
        /// <summary>
        /// Casado
        /// </summary>
        [Description("Casado")]
        Married = 0,

        /// <summary>
        /// Viúvo
        /// </summary>
        [Description("Viúvo")]
        Widowed = 1,

        /// <summary>
        /// Separado
        /// </summary>
        [Description("Separado")]
        Separated = 2,

        /// <summary>
        /// Divorciado
        /// </summary>
        [Description("Divorciado")]
        Divorced = 3,

        /// <summary>
        /// Solteiro
        /// </summary>
        [Description("Solteiro")]
        Single = 4

    }
}