using System.Text.Json;
using Books.Application.Exceptions;
using Books.Application.Library.DTOs;
#nullable disable
public class GetZipCodeServices
{
    public static async Task<object> GetZipCode(string zipCode)
    {
        HttpClient httpClient = new HttpClient();
        string apiUrl = $"https://viacep.com.br/ws/{zipCode}/json/";
        Stream response = await httpClient.GetStreamAsync(apiUrl);
        var repositories = await JsonSerializer.DeserializeAsync<AddressZipCodeModel>(response);
        return repositories;
    }
}