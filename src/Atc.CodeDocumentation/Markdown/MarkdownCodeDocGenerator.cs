namespace Atc.CodeDocumentation.Markdown;

/// <summary>
/// MarkdownCodeDocGenerator.
/// </summary>
public static class MarkdownCodeDocGenerator
{
    internal const string GeneratedBy = "<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>";

    /// <summary>Runs on the specified assembly to document the code in markdown files.</summary>
    /// <param name="assemblyToCodeDoc">The assembly to code document.</param>
    /// <param name="outputPath">The output path.</param>
    /// <exception cref="IOException">No CodeDoc output path found for the assembly:  {assemblyToCodeDoc.FullName}.</exception>
    /// <code><![CDATA[MarkdownCodeDocGenerator.Run(Assembly.GetAssembly(typeof(OneTypeFromTheAssemblyToDocument)));]]></code>
    /// <example><![CDATA[MarkdownCodeDocGenerator.Run(Assembly.GetAssembly(typeof(LocalizedDescriptionAttribute)));]]></example>
    public static void Run(Assembly assemblyToCodeDoc, DirectoryInfo? outputPath = null)
    {
        // Due to some build issue with GenerateDocumentationFile=true and xml-file location, this hack is made for now.
        if (!OperatingSystem.IsWindows())
        {
            return;
        }

        var typeComments = AssemblyCommentHelper.CollectExportedTypesWithComments(assemblyToCodeDoc);
        if (!typeComments.Any())
        {
            return;
        }

        outputPath ??= GetOutputPath(assemblyToCodeDoc);
        if (outputPath is null)
        {
            throw new IOException($"No CodeDoc output path found for the assembly:  {assemblyToCodeDoc.FullName}");
        }

        PrepareOutputPath(outputPath);
        GenerateAndWrites(typeComments, outputPath);
    }

    private static DirectoryInfo? GetOutputPath(Assembly assembly)
    {
        var assemblyName = assembly.GetName().Name!;
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var index = baseDirectory.IndexOf(assemblyName, StringComparison.Ordinal);
        if (index == -1)
        {
            return null;
        }

        baseDirectory = baseDirectory[..(index + assemblyName.Length)];
        return new DirectoryInfo(Path.Combine(baseDirectory, "CodeDoc"));
    }

    private static void PrepareOutputPath(DirectoryInfo outputPath)
    {
        if (!Directory.Exists(outputPath.FullName))
        {
            Directory.CreateDirectory(outputPath.FullName);
        }
        else
        {
            foreach (var file in Directory.GetFiles(outputPath.FullName, "*.md", SearchOption.AllDirectories))
            {
                File.Delete(file);
            }
        }
    }

    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "OK.")]
    private static void GenerateAndWrites(TypeComments[] typeComments, DirectoryInfo outputPath)
    {
        var homeBuilder = new MarkdownBuilder();
        homeBuilder.AppendLine("<div style='text-align: right'>");
        homeBuilder.AppendLine("[References extended](IndexExtended.md)");
        homeBuilder.AppendLine("</div>");
        homeBuilder.AppendLine();
        homeBuilder.Header(1, "References");
        homeBuilder.AppendLine();

        var homeExtendedBuilder = new MarkdownBuilder();
        homeExtendedBuilder.AppendLine("<div style='text-align: right'>");
        homeExtendedBuilder.AppendLine("[References](Index.md)");
        homeExtendedBuilder.AppendLine("</div>");
        homeExtendedBuilder.AppendLine();
        homeExtendedBuilder.Header(1, "References extended");
        homeExtendedBuilder.AppendLine();

        foreach (var g in typeComments
                     .GroupBy(x => x.Namespace, StringComparer.Ordinal)
                     .OrderBy(x => x.Key, StringComparer.Ordinal))
        {
            homeBuilder.HeaderWithLink(2, g.Key, g.Key + ".md");
            homeBuilder.AppendLine();

            homeExtendedBuilder.HeaderWithLink(2, g.Key, g.Key + ".md");
            homeExtendedBuilder.AppendLine();

            var sb = new StringBuilder();
            sb.AppendLine("<div style='text-align: right'>");
            sb.AppendLine();
            sb.AppendLine("[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)");
            sb.AppendLine("</div>");
            sb.AppendLine();

            var hashKey = $"# {g.Key}";
            sb.AppendLine(hashKey);
            foreach (var item in g.OrderBy(x => x.Name, StringComparer.Ordinal))
            {
                var beautifyItemName1 = item.BeautifyHtmlName;
                var beautifyItemName2 = item.BeautifyHtmlName
                    .Replace(",", string.Empty, StringComparison.Ordinal)
                    .Replace(' ', '-')
                    .ToLower(GlobalizationConstants.EnglishCultureInfo);

                homeBuilder.ListLink(beautifyItemName1, g.Key + ".md" + "#" + beautifyItemName2);
                homeExtendedBuilder.ListLink(beautifyItemName1, g.Key + ".md" + "#" + beautifyItemName2);
                homeExtendedBuilder.SubList(item);
                sb.Append(MarkdownHelper.Render(item));
            }

            homeBuilder.AppendLine();
            homeExtendedBuilder.AppendLine();
            sb.AppendLine(GeneratedBy);
            WriteToFile(outputPath, g.Key + ".md", sb.ToString());
        }

        homeBuilder.AppendLine(GeneratedBy);
        WriteToFile(outputPath, "Index.md", homeBuilder.ToString());

        homeExtendedBuilder.AppendLine(GeneratedBy);
        WriteToFile(outputPath, "IndexExtended.md", homeExtendedBuilder.ToString());
    }

    private static void WriteToFile(DirectoryInfo directory, string filename, string content)
    {
        content = content.Replace("\r\n", "\n", StringComparison.Ordinal);
        File.WriteAllText(Path.Combine(directory.FullName, filename), content);
    }
}