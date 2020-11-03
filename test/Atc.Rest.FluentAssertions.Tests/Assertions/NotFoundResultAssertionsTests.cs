﻿using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;

namespace Atc.Rest.FluentAssertions.Tests.Assertions
{
    public class NotFoundResultAssertionsTests
    {
        [Fact]
        public void WithContent_Throws_When_Content_Is_Not_Equivalent_To_Expected()
        {
            var target = new ContentResult()
            {
                Content = "FOO",
                ContentType = "application/json",
            };
            var sut = new NotFoundResultAssertions(target);

            sut.Invoking(x => x.WithContent("BAR"))
                    .Should()
                    .Throw<XunitException>()
                    .WithMessage(@"Expected not found result to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Fact]
        public void WithContent_Throws_When_ContentTypes_Isnt_Json()
        {
            var target = new ContentResult()
            {
                Content = "FOO",
                ContentType = "BAZ",
            };
            var sut = new NotFoundResultAssertions(target);

            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .Throw<XunitException>()
                .WithMessage(@"Expected not found result to be ""application/json"" with a length of 16, but ""BAZ"" has a length of 3, differs near ""BAZ"" (index 0).");
        }


        [Fact]
        public void WithContent_Does_Not_Throw_When_Expected_Match()
        {
            var target = new ContentResult()
            {
                Content = "FOO",
                ContentType = "application/json",
            };
            var sut = new NotFoundResultAssertions(target);

            sut.Invoking(x => x.WithContent("FOO"))
                .Should()
                .NotThrow();
        }

        public static readonly IEnumerable<object[]> ErrorMessageContent = new[]
        {
            new object[]{ JsonSerializer.Serialize(new ProblemDetails { Detail = "FOO" })},
            new object[]{ "FOO" },
        };

        [Theory]
        [MemberData(nameof(ErrorMessageContent))]
        public void WithErrorMessage_Throws_When_Content_Doenst_Match_Expected(string content)
        {
            var target = new ContentResult()
            {
                Content = content,
            };
            var sut = new NotFoundResultAssertions(target);

            sut.Invoking(x => x.WithErrorMessage("BAR"))
                    .Should()
                    .Throw<XunitException>()
                    .WithMessage(@"Expected error message of ""not found result"" to be ""BAR"", but ""FOO"" differs near ""FOO"" (index 0).");
        }

        [Theory]
        [MemberData(nameof(ErrorMessageContent))]
        public void WithErrorMessage_Does_Not_Throw_When_Expected_Match(string content)
        {
            var target = new ContentResult()
            {
                Content = content,
            };
            var sut = new NotFoundResultAssertions(target);

            sut.Invoking(x => x.WithErrorMessage("FOO"))
                    .Should()
                    .NotThrow();
        }
    }
}