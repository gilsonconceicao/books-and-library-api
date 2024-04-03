using System.Text.Json;
using Books.Application.Library.DTOs;

public class GetZipCodeServices
{
    public static async void GetZipCode(string zipCode)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://viacep.com.br/ws/{zipCode}/json/";
            Stream response = await httpClient.GetStreamAsync(apiUrl);
            var repositories = await JsonSerializer.DeserializeAsync<AddressZipCodeModel>(response);
            var data = repositories;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message :{0} ", ex.Message);

        }

    }
}