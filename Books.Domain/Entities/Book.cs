namespace Books.Domain.Entities; 

#nullable disable 
public class Book : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
}