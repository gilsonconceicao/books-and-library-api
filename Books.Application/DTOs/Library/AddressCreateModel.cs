namespace Books.Application.DTOs.Library
{
    #nullable disable
    public class AddressCreateModel
    {
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
    }
}