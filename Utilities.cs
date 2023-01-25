using System.Text;
using System.Text.Json;
using AskGPT.Models;

namespace AskGPT;

public static class Utilities
{
    private static readonly JsonSerializerOptions _options = GetSerializerOptions();

    public static string Serialize(GptRequest request) =>
        JsonSerializer.Serialize(request, _options);

    public static GptResponse? Deserialize(string response) =>
        JsonSerializer.Deserialize<GptResponse>(response, _options);

    public static string GetCommand(string input)
    {
        var sb = new StringBuilder();
        var commands = input.Split("\n\n");

        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] is null)
            {
                continue;
            }

            sb.Append($"{commands[i]}");

            if (i != commands.Length - 1)
            {
                sb.Append('\n');
            }
        }

        var command = sb.ToString();

        var lastIndex = input.LastIndexOf('\n');
        var clipboardCommand = input[(lastIndex + 1)..]; // input.Substring(lastIndex + 1);

        TextCopy.ClipboardService.SetText(clipboardCommand);

        return command;
    }

    private static JsonSerializerOptions GetSerializerOptions() =>
        new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
}