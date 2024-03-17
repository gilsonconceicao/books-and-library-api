using System.ComponentModel;

namespace Books.Application.Enums
{
    public enum StatusAvailability
    {
        [Description("Disponível")]
        Available = 0,
        [Description("Reservado")]
        Reserved = 1, 
        [Description(" Em empréstimo")]
        OnLoan = 2,
        [Description("Perdido")]
        Lost = 3, 
        [Description("Danificado")]
        Damaged = 4
    }
}