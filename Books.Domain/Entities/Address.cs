namespace Books.Domain.Entities
{
#nullable disable
    public class Address : Base
    {
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Number { get; set; }

        public virtual Guid LibraryId { get; set; }
        public virtual Library Library { get; set; }
    }
}