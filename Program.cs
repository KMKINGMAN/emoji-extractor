using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 1 && (args[0] == "--help" || args[0] == "-h"))
        {
            DisplayHelp();
            return;
        }

        if (args.Length == 1 && args[0] == "--version")
        {
            DisplayVersion();
            return;
        }

        if (args.Length < 1)
        {
            Console.WriteLine("Usage: Program <filePath>");
            return;
        }

        string filePath = args[0];
        string saveFolder = "./kingman";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: The specified file does not exist.");
            return;
        }

        EnsureDirectoryExists(saveFolder);
        List<string> emojiCodes = ExtractEmojiCodesFromFile(filePath, saveFolder);
        Console.WriteLine(string.Join(", ", emojiCodes));
    }

    static void EnsureDirectoryExists(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    static List<string> ExtractEmojiCodesFromFile(string filePath, string saveFolder)
    {
        string fileContent = File.ReadAllText(filePath);
        string regexPattern = @"<(a?):\w+:(\d+)>";
        var emojiCodes = new HashSet<string>();

        var regex = new System.Text.RegularExpressions.Regex(regexPattern);
        var matches = regex.Matches(fileContent);

        foreach (System.Text.RegularExpressions.Match match in matches)
        {
            bool animated = match.Groups[1].Value == "a";
            string code = match.Groups[2].Value;

            if (!emojiCodes.Contains(code))
            {
                string emojiUrl = $"https://cdn.discordapp.com/emojis/{code}.{(animated ? "gif" : "png")}";
                string savePath = $"{saveFolder}/{code}.{(animated ? "gif" : "png")}";

                emojiCodes.Add(code);
                DownloadEmoji(emojiUrl, savePath);
            }
        }

        return new List<string>(emojiCodes);
    }

    static void DownloadEmoji(string url, string savePath)
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, savePath);
            Console.WriteLine($"{url} saved as {savePath}");
        }
    }

    static void DisplayHelp()
    {
        Console.WriteLine("Emoji Extractor Tool");
        Console.WriteLine("Usage: Program <filePath>");
        Console.WriteLine("Options:");
        Console.WriteLine("--version    Display the version of the Emoji Extractor tool.");
        Console.WriteLine("--help       Display this help message.");
        Console.WriteLine("GitHub Repository: https://github.com/kmkingman/emoji-extractor");
    }

    static void DisplayVersion()
    {
        Console.WriteLine("Emoji Extractor Tool v1.0");
    }
}
