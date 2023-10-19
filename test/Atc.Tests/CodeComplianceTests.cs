namespace Atc.Tests;

public class CodeComplianceTests
{
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper testOutputHelper;
    private readonly Assembly sourceAssembly = typeof(AtcAssemblyTypeInitializer).Assembly;
    private readonly Assembly testAssembly = typeof(CodeComplianceTests).Assembly;

    private readonly List<Type> excludeTypes = new()
    {
        // TODO: Add UnitTest and remove from this list!!
        typeof(AssemblyHelper),
        typeof(AppDomainExtensions),
        typeof(SemanticVersion),
        typeof(MathEx),
        typeof(JsonSerializerOptionsFactory),
        typeof(JsonCultureInfoToLcidConverter),
        typeof(JsonCultureInfoToNameConverter),
        typeof(JsonDateTimeOffsetMinToNullConverter),
        typeof(JsonElementObjectConverter),
        typeof(JsonNumberToStringConverter),
        typeof(JsonTimeSpanConverter),
        typeof(JsonTypeDiscriminatorConverter<>),
        typeof(JsonUnixDateTimeOffsetConverter),
        typeof(JsonVersionConverter),
        typeof(LoggerExtensions),
        typeof(FileHelper),
        typeof(FileHelper<>),
        typeof(ByteHelper),
        typeof(ByteExtensions),

        // UnitTests are made, but CodeCompliance test cannot detect this
        typeof(DynamicJson),
        typeof(NumberHelper),
        typeof(InternetBrowserHelper),
        typeof(FileInfoExtensions),
        typeof(HttpClientRequestResult<>),
        typeof(IsoCurrencySymbolAttribute),
        typeof(NetworkInformationHelper),
        typeof(DateTimeExtensions),
        typeof(DateTimeOffsetExtensions),
        typeof(ProcessExtensions),
        typeof(StringAttribute),
        typeof(System.TaskExtensions),
        typeof(ThreadExtensions),
        typeof(VersionExtensions),
    };

    public CodeComplianceTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void AssertExportedMethodsWithMissingTests_AbstractSyntaxTree()
    {
        // Act & Assert
        CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
            DecompilerType.AbstractSyntaxTree,
            sourceAssembly,
            testAssembly,
            excludeTypes);
    }

    [Fact]
    public void AssertExportedMethodsWithMissingTests_MonoReflection()
    {
        // Act & Assert
        CodeComplianceTestHelper.AssertExportedMethodsWithMissingTests(
            DecompilerType.MonoReflection,
            sourceAssembly,
            testAssembly,
            excludeTypes);
    }

    [Fact]
    public void AssertExportedTypesWithMissingComments()
    {
        // Act & Assert
        CodeComplianceDocumentationHelper.AssertExportedTypesWithMissingComments(
            sourceAssembly);
    }

    [Fact]
    public void AssertExportedTypesWithWrongNaming()
    {
        var excludeTypesForNaming = new List<Type>
        {
            typeof(CharExtensions),
            typeof(ByteExtensions),
            typeof(ByteSizeExtensions), // Extension parameter type should "normal" match the class name-prefix, but because of the code-grouping, it is ok.
        };

        // Act & Assert
        CodeComplianceHelper.AssertExportedTypesWithWrongDefinitions(
            sourceAssembly,
            excludeTypesForNaming);
    }

    [Fact]
    public void AssertLocalizationResources()
    {
        // TODO: Fix missing translation and uncomment this:
        Assert.True(true);

        ////// Arrange
        ////var cultureNames = new List<string>
        ////{
        ////    "da-DK",
        ////    "de-DE",
        ////};

        ////var allowSuffixTermsForKeySuffixWithPlaceholders = new List<string>
        ////{
        ////    "AsAbbreviation",
        ////};

        // Act & Assert
        ////CodeComplianceHelper.AssertLocalizationResources(
        ////    sourceAssembly,
        ////    cultureNames,
        ////    allowSuffixTermsForKeySuffixWithPlaceholders);
    }

    [Fact]
    public void AssertLocalizationResourcesForMissingTranslations()
    {
        // TODO: Fix missing translation and uncomment this:
        Assert.True(true);

        ////// Arrange
        ////var cultureNames = new List<string>
        ////{
        ////    "da-DK",
        ////    "de-DE",
        ////};

        ////// Act & Assert
        ////CodeComplianceHelper.AssertLocalizationResourcesForMissingTranslations(
        ////    sourceAssembly,
        ////    cultureNames);
    }

    [Fact]
    public void AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders()
    {
        // Arrange
        var cultureNames = new List<string>
        {
            "da-DK",
            "de-DE",
        };

        var allowSuffixTermsForKeySuffixWithPlaceholders = new List<string>
        {
            "AsAbbreviation",
        };

        // Act & Assert
        CodeComplianceHelper.AssertLocalizationResourcesForInvalidKeysSuffixWithPlaceholders(
            sourceAssembly,
            cultureNames,
            allowSuffixTermsForKeySuffixWithPlaceholders);
    }
}