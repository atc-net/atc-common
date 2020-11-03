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
    public class GetUserByEmailTests : WebApiControllerBaseTest
    {
        public GetUserByEmailTests(WebApiStartupFactory fixture) : base(fixture) { }

        [Theory]
        [InlineData("/api/v1/users/email?email=john.doe@example.com")]
        public async Task GetUserByEmail_Ok(string relativeRef)
        {
            // Act
            var response = await HttpClient.GetAsync(relativeRef);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = await response.DeserializeAsync<User>(JsonSerializerOptions);
            responseData.Should().NotBeNull();
        }

        [Theory]
        [InlineData("/api/v1/users/email?email=john.doe_example.com")]
        public async Task GetUserByEmail_BadRequest_InQuery(string relativeRef)
        {
            // Act
            var response = await HttpClient.GetAsync(relativeRef);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}