using System.Text.Json.Serialization;

namespace AskGPT.Models;

public sealed class GptRequest
{
    [JsonPropertyName("model")]
    public string Model { get; } = "text-davinci-001";
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; } = null!;
    [JsonPropertyName("temperature")]
    public int Temperature { get; } = 1;
    [JsonPropertyName("max_tokens")]
    public int MaxTokens { get; } = 100;

    private GptRequest(string prompt)
    {
        Prompt = prompt;
    }

    public static GptRequest CreateRequest(string prompt)
    {
        return new GptRequest(prompt);
    }
}