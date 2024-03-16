using System.ComponentModel;

namespace Books.Application.Enums
{
    public enum StatusAvailability
    {
        [Description("Disponível")]
        Available = 1,
        [Description("Reservado")]
        Reserved =2, 
        [Description(" Em empréstimo")]
        OnLoan = 3,
        [Description("Perdido")]
        Lost = 4, 
        [Description("Danificado")]
        Damaged =5
    }
}