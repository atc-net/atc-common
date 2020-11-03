﻿using Demo.Domain.Handlers.Orders;
using System;
using System.CodeDom.Compiler;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.181.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
namespace Demo.Domain.Tests.Handlers.Orders.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.181.0")]
    public class GetOrdersHandlerGeneratedTests
    {
        [Fact]
        public void InstantiateConstructor()
        {
            // Act
            var actual = new GetOrdersHandler();

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void ParameterArgumentNullCheck()
        {
            // Arrange
            var sut = new GetOrdersHandler();

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => sut.ExecuteAsync(null!));
        }
    }
}