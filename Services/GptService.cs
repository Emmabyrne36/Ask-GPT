using System.Text;
using AskGPT.Models;

namespace AskGPT.Services;

public static class GptService
{
    public static async Task<string> GetGptResponse(string question)
    {
        var client = SetupClient();

        var json = Utilities.Serialize(GptRequest.CreateRequest(question));
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.openai.com/v1/completions", content);

        return await response.Content.ReadAsStringAsync();
    }

    private static HttpClient SetupClient()
    {
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("authorization", "Bearer YOUR_API_KEY");

        return client;
    }
}
