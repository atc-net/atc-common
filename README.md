### General Project Info
[![Github top language](https://img.shields.io/github/languages/top/atc-net/atc)](https://github.com/atc-net/atc)
[![Github stars](https://img.shields.io/github/stars/atc-net/atc?style=flat)](https://github.com/atc-net/atc)
[![Github forks](https://img.shields.io/github/forks/atc-net/atc?style=flat)](https://github.com/atc-net/atc)
[![Github size](https://img.shields.io/github/repo-size/atc-net/atc?style=flat)](https://github.com/atc-net/atc)
[![NuGet Version](https://img.shields.io/nuget/v/atc.svg?style=flat-square)](https://www.nuget.org/profiles/atc-net)
[![Issues Open](https://img.shields.io/github/issues/atc-net/atc.svg?style=flat-square&logo=github)](https://github.com/atc-net/atc/issues)

### Build Status
![.NET Core](https://github.com/atc-net/atc/workflows/.NET%20Core/badge.svg)
[![Build Status](https://dev.azure.com/atc-net/ATC.NET/_apis/build/status/atc-net.atc?branchName=master)](https://dev.azure.com/atc-net/ATC.NET/_build/latest?definitionId=1&branchName=master)

### Code Quality
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=atc-net_atc&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=atc-net_atc)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=atc-net_atc&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=atc-net_atc)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=atc-net_atc&metric=security_rating)](https://sonarcloud.io/dashboard?id=atc-net_atc)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=atc-net_atc&metric=bugs)](https://sonarcloud.io/dashboard?id=atc-net_atc)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=atc-net_atc&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=atc-net_atc)

# ATC.Net

## Projects in the repository

|Project|Target Framework|Description|Docs|Nuget Download Link|
|---|---|---|---|---|
|[Atc](src/Atc)|netstandard2.1|Atc is a collection of classes and extension methods for common functionality.|[References](docs/CodeDoc/Atc/Index.md)<br/>[References extended](docs/CodeDoc/Atc/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc)|
|[Atc.CodeAnalysis.CSharp](src/Atc.CodeAnalysis.CSharp)|netstandard2.1|Atc.CodeAnalysis.CSharp is a collection of classes and extension methods for Microsoft.CodeAnalysis.CSharp.|[References](docs/CodeDoc/Atc.CodeAnalysis.CSharp/Index.md)<br/>[References extended](docs/CodeDoc/Atc.CodeAnalysis.CSharp/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.CodeAnalysis.CSharp?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.CodeAnalysis.CSharp)|
|[Atc.CodeDocumentation](src/Atc.CodeDocumentation)|netstandard2.1|Atc.CodeDocumentation is a markdown generator for source code.|[References](docs/CodeDoc/Atc.CodeDocumentation/Index.md)<br/>[References extended](docs/CodeDoc/Atc.CodeDocumentation/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.CodeDocumentation?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.CodeDocumentation)|
|[Atc.OpenApi](src/Atc.OpenApi)|netstandard2.1|Atc.OpenApi is a collection of classes and extension methods for Microsoft.OpenApi.|[References](docs/CodeDoc/Atc.OpenApi/Index.md)<br/>[References extended](docs/CodeDoc/Atc.OpenApi/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.OpenApi?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.OpenApi)|
|[Atc.Rest](src/Atc.Rest)|netcoreapp3.1|Atc.Rest is a basic collection of classes and extension methods for ASP.NET Core WebApi.|[References](docs/CodeDoc/Atc.Rest/Index.md)<br/>[References extended](docs/CodeDoc/Atc.Rest/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.Rest?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest)|
|[Atc.Rest.ApiGenerator](src/Atc.Rest.ApiGenerator)|netstandard2.1|Atc.Rest.ApiGenerator is a WebApi C# code generator using a OpenApi 3.0.x specification YAML file.|[References](docs/CodeDoc/Atc.Rest.ApiGenerator/Index.md)<br/>[References extended](docs/CodeDoc/Atc.Rest.ApiGenerator/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.ApiGenerator?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.ApiGenerator)|
|[Atc.Rest.ApiGenerator.CLI](src/Atc.Rest.ApiGenerator.CLI)|netcoreapp3.1|A CLI tool that use Atc.Rest.ApiGenerator to create/update a project specified by a OpenApi 3.0.x specification YAML file.||[![Nuget](https://img.shields.io/nuget/dt/atc-api-gen?logo=nuget&style=flat-square)](https://www.nuget.org/packages/atc-api-gen)|
|[Atc.Rest.ApiGenerator.Web](src/Atc.Rest.ApiGenerator.Web)|netcoreapp3.1||||
|[Atc.Rest.Extended](src/Atc.Rest.Extended)|netcoreapp3.1|Atc.Rest.Extended is a collection of classes and extension methods for Atc.Rest, that contains SwaggerUI, FluentValidation Versioning etc.|[References](docs/CodeDoc/Atc.Rest.Extended/Index.md)<br/>[References extended](docs/CodeDoc/Atc.Rest.Extended/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.Rest.Extended?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.Rest.Extended)|
|[Atc.XUnit](src/Atc.XUnit)|netstandard2.1|Atc.XUnit is a collection of helper method for code compliance of documentation and tests.|[References](docs/CodeDoc/Atc.XUnit/Index.md)<br/>[References extended](docs/CodeDoc/Atc.XUnit/IndexExtended.md)|[![Nuget](https://img.shields.io/nuget/dt/Atc.XUnit?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Atc.XUnit)|

## CLI Tool Usage

The Atc.Rest.ApiGenerator.CLI library mentioned above is available through a cross platform command line application.

**Requirements**
- .NET Core 3.1 runtime

### Installation

The tool can be installed as a .NET Core global tool that you can call from the shell / command line

```
dotnet tool install --global atc-api-gen
```

or by following the instructions [here](https://www.nuget.org/packages/atc-api-gen/) to install a specific version of the tool.

A successful installation will output something like:

```
You can invoke the tool using the following command: atc-api
Tool 'atc-api-gen' (version '1.0.104') was successfully installed.`
```

### Usage

Since the tool is published as a .NET Core Tool, it can be launched from anywhere using any command line interface by calling **atc-api**. The help information is displayed using the `--help` argument to **atc-api**

```
$ atc-api --help

Usage: atc-api [command] [options]

Commands
  generate
  validate
```

#### Example for --help on the commands 'generate server api'
```
$ atc-api generate server api --help

Create API project.

Usage: atc-api generate server api [options]

Options:
  --validate-strictMode                    Use strictMode
  --validate-operationIdCasingStyle        Set casingStyle for operationId
  --validate-modelNameCasingStyle          Set casingStyle for model name
  --validate-modelPropertyNameCasingStyle  Set casingStyle for model property name
  -p|--projectPrefixName                   Project prefix name (e.g. 'PetStore' becomes 'PetStore.Api.Generated').
  -o|--outputPath                          Path to generated project.
  --useNullableReferenceTypes              Use nullable reference types in .csproj
  --useAuthorization                       Use authorization
  -v|--verboseMode                         Use verboseMode for more debug/trace information
  --optionsPath                            Path to options json-file.
  -s|--specificationPath                   Path to Open API specification (directory, file or url)
  -?|-h|--help                             Show help information
```


### Usage Examples:

Comming soon...
