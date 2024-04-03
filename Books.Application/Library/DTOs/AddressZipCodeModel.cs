using System.Text.Json.Serialization;
namespace Books.Application.Library.DTOs; 

#nullable disable
public class AddressZipCodeModel
{
    [JsonPropertyName("cep")]
    public string ZipCode { get; set; }
    [JsonPropertyName("logradouro")]
    public string Street { get; set; }
    [JsonPropertyName("complemento")]
    public string Complement { get; set; }
    [JsonPropertyName("uf")]
    public string State { get; set; }
    [JsonPropertyName("localidade")]
    public string City { get; set; }
}
// Reference via CEP
//   "cep": string,
//   "logradouro": string,
//   "complemento": string,
//   "bairro": ")",
//   "localidade": string,
//   "uf": string,
//   "ibge": string,
//   "gia": string,
//   "ddd": string,
//   "siafi": string