﻿using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.147.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Users
{
    /// <summary>
    /// Parameters for operation request.
    /// Description: Get user by id.
    /// Operation: GetUserById.
    /// Area: Users.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class GetUserByIdParameters
    {
        /// <summary>
        /// The id of the user to retrieve.
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}";
        }
    }
}