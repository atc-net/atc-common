﻿using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.147.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Orders
{
    /// <summary>
    /// Results for operation request.
    /// Description: Get orders.
    /// Operation: GetOrders.
    /// Area: Orders.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class GetOrdersResult
    {
        private readonly ActionResult result;

        private GetOrdersResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static GetOrdersResult Ok(Pagination<Order> response) => new GetOrdersResult(new OkObjectResult(response));

        /// <summary>
        /// 404 - NotFound response.
        /// </summary>
        public static GetOrdersResult NotFound(string? message = null) => new GetOrdersResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.NotFound, message));

        /// <summary>
        /// Performs an implicit conversion from GetOrdersResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(GetOrdersResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from GetOrdersResult to ActionResult.
        /// </summary>
        public static implicit operator GetOrdersResult(Pagination<Order> x) => Ok(x);
    }
}