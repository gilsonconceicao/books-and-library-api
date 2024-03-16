namespace Books.Domain.Entities
{
#nullable disable
    public class Library : Base
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Catalogs { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}