using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Domain.Entities; 

#nullable disable 
public class Book : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual Library Library {get; set; }
    public Guid LibraryId {get; set; }
}