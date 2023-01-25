using AskGPT.Services;
using AskGPT;

if (args.Length == 0)
{
    Console.WriteLine("---> You need to provide some input.");
    return;
}

await Execute(args);

static async Task Execute(string[] args)
{
    var jsonResponse = await GptService.GetGptResponse(args[0]);

    try
    {
        var gptResponse = Utilities.Deserialize(jsonResponse);
        Console.ForegroundColor = ConsoleColor.Green;

        if (gptResponse?.Choices.Count > 0)
        {
            var command = Utilities.GetCommand(gptResponse!.Choices[0].Text);

            Console.WriteLine("--->");
            Console.WriteLine(command);

            Console.ResetColor();
            return;
        }

        Console.WriteLine("No command was found for that input, please try again.");
        return;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not deserialize the response: {ex.Message}");
    }
}
