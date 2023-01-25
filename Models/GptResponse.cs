namespace AskGPT.Models;

public class GptResponse
{
    public string Id { get; set; } = null!;

    public List<Choice> Choices { get; set; } = null!;
}