﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Users;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.181.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
namespace Demo.Api.Tests.Endpoints.Users.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.181.0")]
    [Collection("Sequential-Endpoints")]
    public class PostUserTests : WebApiControllerBaseTest
    {
        public PostUserTests(WebApiStartupFactory fixture) : base(fixture) { }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_Created(string relativeRef)
        {
            // Arrange
            var data = new CreateUserRequest
            {
                FirstName = "Hallo",
                LastName = "Hallo1",
                MyNullableDateTime = DateTimeOffset.Parse("2020-10-12T21:22:23"),
                MyDateTime = DateTimeOffset.Parse("2020-10-12T21:22:23"),
                Email = "john.doe@example.com",
                Gender = GenderType.Female,
                MyNullableAddress = new Address(),
            };

            // Act
            var response = await HttpClient.PostAsync(relativeRef, ToJson(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_BadRequest_InBody_FirstName(string relativeRef)
        {
            // Arrange
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"FirstName\": null,");
            sb.AppendLine("  \"LastName\": \"Hallo1\",");
            sb.AppendLine("  \"MyNullableDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"MyDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"Email\": \"john.doe@example.com\",");
            sb.AppendLine("  \"Gender\": \"Female\",");
            sb.AppendLine("  \"MyNullableAddress\": \"new Address()\"");
            sb.AppendLine("}");
            var data = sb.ToString();

            // Act
            var response = await HttpClient.PostAsync(relativeRef, Json(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_BadRequest_InBody_LastName(string relativeRef)
        {
            // Arrange
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"FirstName\": \"Hallo\",");
            sb.AppendLine("  \"LastName\": null,");
            sb.AppendLine("  \"MyNullableDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"MyDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"Email\": \"john.doe@example.com\",");
            sb.AppendLine("  \"Gender\": \"Female\",");
            sb.AppendLine("  \"MyNullableAddress\": \"new Address()\"");
            sb.AppendLine("}");
            var data = sb.ToString();

            // Act
            var response = await HttpClient.PostAsync(relativeRef, Json(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_BadRequest_InBody_MyNullableDateTime(string relativeRef)
        {
            // Arrange
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"FirstName\": \"Hallo\",");
            sb.AppendLine("  \"LastName\": \"Hallo1\",");
            sb.AppendLine("  \"MyNullableDateTime\": \"x2020-10-12T21:22:23\",");
            sb.AppendLine("  \"MyDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"Email\": \"john.doe@example.com\",");
            sb.AppendLine("  \"Gender\": \"Female\",");
            sb.AppendLine("  \"MyNullableAddress\": \"new Address()\"");
            sb.AppendLine("}");
            var data = sb.ToString();

            // Act
            var response = await HttpClient.PostAsync(relativeRef, Json(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_BadRequest_InBody_MyDateTime(string relativeRef)
        {
            // Arrange
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"FirstName\": \"Hallo\",");
            sb.AppendLine("  \"LastName\": \"Hallo1\",");
            sb.AppendLine("  \"MyNullableDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"MyDateTime\": \"x2020-10-12T21:22:23\",");
            sb.AppendLine("  \"Email\": \"john.doe@example.com\",");
            sb.AppendLine("  \"Gender\": \"Female\",");
            sb.AppendLine("  \"MyNullableAddress\": \"new Address()\"");
            sb.AppendLine("}");
            var data = sb.ToString();

            // Act
            var response = await HttpClient.PostAsync(relativeRef, Json(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_BadRequest_InBody_Email(string relativeRef)
        {
            // Arrange
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"FirstName\": \"Hallo\",");
            sb.AppendLine("  \"LastName\": \"Hallo1\",");
            sb.AppendLine("  \"MyNullableDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"MyDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"Email\": \"john.doe_example.com\",");
            sb.AppendLine("  \"Gender\": \"Female\",");
            sb.AppendLine("  \"MyNullableAddress\": \"new Address()\"");
            sb.AppendLine("}");
            var data = sb.ToString();

            // Act
            var response = await HttpClient.PostAsync(relativeRef, Json(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("/api/v1/users")]
        public async Task PostUser_BadRequest_InBody_Gender(string relativeRef)
        {
            // Arrange
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"FirstName\": \"Hallo\",");
            sb.AppendLine("  \"LastName\": \"Hallo1\",");
            sb.AppendLine("  \"MyNullableDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"MyDateTime\": \"2020-10-12T21:22:23\",");
            sb.AppendLine("  \"Email\": \"john.doe@example.com\",");
            sb.AppendLine("  \"Gender\": \"@\",");
            sb.AppendLine("  \"MyNullableAddress\": \"new Address()\"");
            sb.AppendLine("}");
            var data = sb.ToString();

            // Act
            var response = await HttpClient.PostAsync(relativeRef, Json(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}