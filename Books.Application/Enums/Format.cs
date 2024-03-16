using System.ComponentModel;

namespace Books.Application.Enums
{
    public enum Format
    {
        [Description(" Capa dura")]
        Hardcover = 1,
        [Description(" Capa mole")]
        Paperback =2, 
        [Description("Livro eletrônico (e-book)")]
        Ebook = 3,
        [Description("Audiolivro")]
        Audiobook = 4 
    }
}