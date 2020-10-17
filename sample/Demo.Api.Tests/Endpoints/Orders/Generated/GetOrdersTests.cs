﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Demo.Api.Generated;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Orders;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.147.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//--
namespace Demo.Api.Tests.Endpoints.Orders.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class GetOrdersTests : WebApiControllerBaseTest
    {
        public GetOrdersTests(WebApiStartupFactory fixture) : base(fixture) { }

        [Theory]
        [InlineData("/api/v1/orders?pageSize=42")]
        [InlineData("/api/v1/orders?pageSize=42&pageIndex=42")]
        [InlineData("/api/v1/orders?pageSize=42&queryString=Hallo")]
        [InlineData("/api/v1/orders?pageSize=42&pageIndex=42&queryString=Hallo")]
        [InlineData("/api/v1/orders?pageSize=42&continuationToken=Hallo")]
        [InlineData("/api/v1/orders?pageSize=42&pageIndex=42&continuationToken=Hallo")]
        [InlineData("/api/v1/orders?pageSize=42&queryString=Hallo&continuationToken=Hallo")]
        [InlineData("/api/v1/orders?pageSize=42&pageIndex=42&queryString=Hallo&continuationToken=Hallo")]
        public async Task GetOrders_Ok(string relativeRef)
        {
            // Act
            var response = await HttpClient.GetAsync(relativeRef);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseData = await response.DeserializeAsync<Pagination<Order>>(JsonSerializerOptions);
            responseData.Should().NotBeNull();
        }

        [Theory]
        [InlineData("/api/v1/orders?pageSize=@")]
        public async Task GetOrders_BadRequest_InQuery(string relativeRef)
        {
            // Act
            var response = await HttpClient.GetAsync(relativeRef);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}