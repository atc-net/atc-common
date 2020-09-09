using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Atc.XUnit.Internal;

namespace Atc.XUnit
{
    /// <summary>
    /// CodeComplianceTestHelper.
    /// </summary>
    public static class CodeComplianceTestHelper
    {
        /// <summary>
        /// Asserts the exported methods with missing tests.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="testType">Type of the test.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertExportedMethodsWithMissingTests(
            DecompilerType decompilerType,
            Type sourceType,
            Type testType,
            bool useFullName = false)
        {
            if (sourceType == null)
            {
                throw new ArgumentNullException(nameof(sourceType));
            }

            if (testType == null)
            {
                throw new ArgumentNullException(nameof(testType));
            }

            var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
                decompilerType,
                sourceType,
                testType);
            TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests(
                sourceType.Assembly.GetName().Name,
                methodsWithMissingTests,
                useFullName);
        }

        /// <summary>
        /// Asserts the exported methods with missing tests.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertExportedMethodsWithMissingTests(
            DecompilerType decompilerType,
            Type sourceType,
            Assembly testAssembly,
            bool useFullName = false)
        {
            if (sourceType == null)
            {
                throw new ArgumentNullException(nameof(sourceType));
            }

            var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
                decompilerType,
                sourceType,
                testAssembly);
            TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests(
                sourceType.Assembly.GetName().Name,
                methodsWithMissingTests,
                useFullName);
        }

        /// <summary>
        /// Asserts the exported methods with missing tests.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static void AssertExportedMethodsWithMissingTests(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null,
            bool useFullName = false)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
                decompilerType,
                sourceAssembly,
                testAssembly,
                excludeSourceTypes);
            TestResultHelper.AssertOnTestResultsFromMethodsWithMissingTests(
                sourceAssembly.GetName().Name,
                methodsWithMissingTests,
                useFullName);
        }

        /// <summary>
        /// Collects the exported types with missing tests.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        public static Type[] CollectExportedTypesWithMissingTests(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            return AssemblyTestHelper.CollectExportedTypesWithMissingTests(
                decompilerType,
                sourceAssembly,
                testAssembly,
                excludeSourceTypes);
        }

        /// <summary>
        /// Collects the exported types with missing tests and generate text.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static string CollectExportedTypesWithMissingTestsAndGenerateText(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null,
            bool useFullName = false)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var typesWithMissingTests = AssemblyTestHelper.CollectExportedTypesWithMissingTests(
                decompilerType,
                sourceAssembly,
                testAssembly,
                excludeSourceTypes);

            var sb = new StringBuilder();
            sb.AppendLine("            var excludeTypes = new List<Type>");
            sb.AppendLine("            {");
            sb.AppendLine("            {    // TODO: Implement tests on the following types, and then remove the type from the exclude list.");
            for (var i = 0; i < typesWithMissingTests.Length; i++)
            {
                var type = typesWithMissingTests[i];
                if (i == typesWithMissingTests.Length - 1)
                {
                    sb.AppendLine(useFullName
                        ? $"                typeof(global::{type.BeautifyName(true)})"
                        : $"                typeof({type.BeautifyName()})");
                }
                else
                {
                    sb.AppendLine(useFullName
                        ? $"                typeof(global::{type.BeautifyName(true)}),"
                        : $"                typeof({type.BeautifyName()}),");
                }
            }

            sb.AppendLine("            }");
            return sb.ToString();
        }

        /// <summary>
        /// Collects the exported methods with missing tests from assembly.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        public static MethodInfo[] CollectExportedMethodsWithMissingTestsFromAssembly(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            return AssemblyTestHelper.CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);
        }

        /// <summary>
        /// Collects the exported methods with missing tests and generate text lines.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static string[] CollectExportedMethodsWithMissingTestsAndGenerateTextLines(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null,
            bool useFullName = false)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);
            return AssemblyTestHelper.GetMethodsAsRenderTextLines(methodsWithMissingTests, useFullName);
        }

        /// <summary>
        /// Collects the exported methods with missing tests and generate text.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        /// <param name="useFullName">if set to <c>true</c> [use full name].</param>
        public static string CollectExportedMethodsWithMissingTestsAndGenerateText(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null,
            bool useFullName = false)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(decompilerType, sourceAssembly, testAssembly, excludeSourceTypes);
            return AssemblyTestHelper.GetMethodsAsRenderText(methodsWithMissingTests, useFullName);
        }

        /// <summary>
        /// Collects the exported methods with missing tests to excel.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        public static void CollectExportedMethodsWithMissingTestsToExcel(
            DecompilerType decompilerType,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null)
        {
            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            CollectExportedMethodsWithMissingTestsToExcel(
                decompilerType,
                new DirectoryInfo(@"C:\Temp"),
                sourceAssembly,
                testAssembly,
                excludeSourceTypes);
        }

        /// <summary>
        /// Collects the exported methods with missing tests to excel.
        /// </summary>
        /// <param name="decompilerType">The decompiler type.</param>
        /// <param name="reportDirectory">The report directory.</param>
        /// <param name="sourceAssembly">The source assembly.</param>
        /// <param name="testAssembly">The test assembly.</param>
        /// <param name="excludeSourceTypes">The exclude source types.</param>
        /// <exception cref="ArgumentNullException">reportDirectory.</exception>
        public static void CollectExportedMethodsWithMissingTestsToExcel(
            DecompilerType decompilerType,
            DirectoryInfo reportDirectory,
            Assembly sourceAssembly,
            Assembly testAssembly,
            List<Type>? excludeSourceTypes = null)
        {
            if (reportDirectory == null)
            {
                throw new ArgumentNullException(nameof(reportDirectory));
            }

            if (sourceAssembly == null)
            {
                throw new ArgumentNullException(nameof(sourceAssembly));
            }

            if (testAssembly == null)
            {
                throw new ArgumentNullException(nameof(testAssembly));
            }

            var methodsWithMissingTests = AssemblyTestHelper.CollectExportedMethodsWithMissingTests(
                decompilerType,
                sourceAssembly,
                testAssembly,
                excludeSourceTypes);
            TestResultHelper.ToExcelTestResultsFromMethodsWithMissingTests(
                reportDirectory,
                sourceAssembly.GetName().Name,
                methodsWithMissingTests);
        }
    }
}