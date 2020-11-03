﻿using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.181.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
namespace Demo.Api.Generated.Contracts.Orders
{
    /// <summary>
    /// Parameters for operation request.
    /// Description: Get orders.
    /// Operation: GetOrders.
    /// Area: Orders.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.181.0")]
    public class GetOrdersParameters
    {
        /// <summary>
        /// The numbers of items to return.
        /// </summary>
        [FromQuery(Name = "pageSize")]
        [Required]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// The number of items to skip before starting to collect the result set.
        /// </summary>
        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// The query string.
        /// </summary>
        [FromQuery(Name = "queryString")]
        public string? QueryString { get; set; }

        /// <summary>
        /// The continuation token.
        /// </summary>
        [FromQuery(Name = "continuationToken")]
        public string? ContinuationToken { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(PageSize)}: {PageSize}, {nameof(PageIndex)}: {PageIndex}, {nameof(QueryString)}: {QueryString}, {nameof(ContinuationToken)}: {ContinuationToken}";
        }
    }
}