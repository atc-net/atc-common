﻿using System.CodeDom.Compiler;

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
    /// Update test-gender Request.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class UpdateTestGenderRequest
    {
        /// <summary>
        /// GenderType.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Gender)}: ({Gender})";
        }
    }
}