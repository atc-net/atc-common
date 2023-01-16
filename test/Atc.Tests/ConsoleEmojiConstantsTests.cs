// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
namespace Atc.Tests;

/// <summary>
/// The generator of emojis from unicode.org.
/// </summary>
/// <remarks>
/// For documentation and usage, see https://www.unicode.org/reports/tr51
/// https://www.unicode.org/reports/tr51
/// </remarks>
[Collection(nameof(Xunit.Sdk.TestCollection))]
[Trait(Traits.Category, Traits.Categories.Integration)]
[Trait(Traits.Category, Traits.Categories.SkipWhenLiveUnitTesting)]
public class ConsoleEmojiConstantsTests
{
    private const string EmojiConstantsFile = "UnicodeEmojiConstants.cs";
    private const string SourceUrl = "https://unicode.org/Public/emoji/15.0/emoji-test.txt";
    private const string GroupPrefix = "# group:";
    private const string SubGroupPrefix = "# subgroup:";
    private const char CommentPrefix = '#';
    private const float MaxVersion = 15.0F;
    private static readonly char[] FormatNameSeparators = { ' ', '-', ',', '’', '!', '“', '”', '(', ')', '.' };

    [Fact]
    [SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "OK. This \"Test\" generates our EmojisConstants.cs file.")]

    public void RunEmojiConstantsGenerate()
    {
        var emojisConstantsFile = GetEmojiConstantsFile();
        if (emojisConstantsFile.Exists)
        {
            // To re-create/update the file - please manual delete it first.
            return;
        }

        var unicodeEmojisContent = GetUnicodeEmojisContent();
        if (string.IsNullOrEmpty(unicodeEmojisContent))
        {
            throw new HttpRequestException($"Unable to download from {SourceUrl}");
        }

        var emojis = Extract(unicodeEmojisContent);

        var emojiConstantsContent = GenerateContent(emojis);

        FileHelper.WriteAllText(
            emojisConstantsFile,
            emojiConstantsContent);
    }

    [SuppressMessage("Major Bug", "S2583:Conditionally executed code should be reachable", Justification = "OK.")]
    private static string GenerateContent(IList<(string Group, string SubGroup, string Name, string Value)> emojis)
    {
        var groupNames = emojis
            .Select(x => x.Group)
            .Distinct(StringComparer.Ordinal)
            .OrderBy(x => x, StringComparer.Ordinal)
            .ToList();

        var sb = new StringBuilder();
        sb.AppendLine("// <auto-generated />");
        sb.AppendLine("namespace Atc.Console;");
        sb.AppendLine();
        sb.AppendLine("/// <Summery>");
        sb.AppendLine("/// Emojis from unicode.org.");
        sb.AppendLine("/// </Summery>");
        sb.AppendLine("/// <Remarks>");
        sb.AppendLine($"/// Generated from: {SourceUrl}");
        sb.AppendLine("/// </Remarks>");
        sb.AppendLine("public static partial class EmojiConstants");
        sb.AppendLine("{");
        var isFirst = true;
        foreach (var groupName in groupNames)
        {
            var emojisForGroupName = emojis
                .Where(x => x.Group == groupName)
                .OrderBy(x => x.SubGroup, StringComparer.Ordinal)
                .ThenBy(x => x.Name, StringComparer.Ordinal)
                .ToList();

            if (isFirst)
            {
                isFirst = false;
            }
            else
            {
                sb.AppendLine();
            }

            sb.AppendLine(4, $"// {groupName}");
            foreach (var (_, _, name, value) in emojisForGroupName)
            {
                sb.AppendLine(4, $"public const string {name} = \"{value}\";");
            }
        }

        sb.Append('}');
        return sb.ToString();
    }

    private static IList<(string Group, string SubGroup, string Name, string Value)> Extract(
        string unicodeEmojisContent)
    {
        var lines = unicodeEmojisContent
            .EnsureEnvironmentNewLines()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var data = new List<(string Group, string SubGroup, string Name, string Value)>();

        var group = string.Empty;
        var subGroup = string.Empty;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.StartsWith(GroupPrefix, StringComparison.Ordinal))
            {
                group = FormatName(line[GroupPrefix.Length..]);
                continue;
            }

            if (line.StartsWith(SubGroupPrefix, StringComparison.Ordinal))
            {
                subGroup = FormatName(line[SubGroupPrefix.Length..]);
                continue;
            }

            if (line.StartsWith(CommentPrefix))
            {
                continue;
            }

            var emoji = ParseEmoji(line);
            if (emoji.HasValue)
            {
                data.Add(
                    new(
                        group,
                        subGroup,
                        emoji.Value.Name,
                        emoji.Value.Value));
            }
        }

        return data;
    }

    private static string FormatName(
        string source)
    {
        var parts = source
            .Replace(':', '_')
            .Replace('-', ' ')
            .Replace("&", "And", StringComparison.Ordinal)
            .Replace("#", "NumberSign", StringComparison.Ordinal)
            .Replace("*", "Asterisk", StringComparison.Ordinal)
            .Replace(",", string.Empty, StringComparison.Ordinal)
            .Replace("’", string.Empty, StringComparison.Ordinal)
            .Split(FormatNameSeparators, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x
                .Replace("_", string.Empty, StringComparison.Ordinal)
                .Trim()
                .PascalCase())
            .ToList();

        return string.Concat(parts);
    }

    private static (string Name, string Value)? ParseEmoji(
        string line)
    {
        var parts = line.Split(new[] { ';', '#' }, 3);

        if (parts[1].Trim() != "fully-qualified")
        {
            return null;
        }

        var versionAndName = parts[2].Split('E', 2)[1].Split(' ', 2);
        var version = float.Parse(versionAndName[0], GlobalizationConstants.EnglishCultureInfo);

        if (version > MaxVersion)
        {
            return null;
        }

        var name = FormatName(versionAndName[1]);

        if (char.IsDigit(name[0]))
        {
            name = "Number" + name;
        }

        var surrogates = parts[0].Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x, NumberStyles.HexNumber, GlobalizationConstants.EnglishCultureInfo))
            .Select(char.ConvertFromUtf32);

        var value = string.Concat(surrogates);

        return (name, value);
    }

    private static FileInfo GetEmojiConstantsFile()
    {
        var assemblyName = typeof(CodeDocumentationTests).Assembly.GetName().Name;
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        var testProjectDirectory = new DirectoryInfo(
            baseDirectory[..(baseDirectory!.IndexOf(assemblyName!, StringComparison.Ordinal) + assemblyName.Length)]);

        var rootDirectory = testProjectDirectory!.Parent!.Parent;

        return new FileInfo(
            Path.Combine(
                rootDirectory!.FullName,
                $"src\\Atc\\Console\\{EmojiConstantsFile}"));
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    private static string GetUnicodeEmojisContent()
    {
        var content = string.Empty;
        TaskHelper.RunSync(async () =>
        {
            try
            {
                using var client = new HttpClient();
                content = await client
                    .GetStringAsync(new Uri(SourceUrl))
                    .ConfigureAwait(false);
            }
            catch
            {
                // Do not touch response on exceptions
            }
        });

        return content;
    }
}