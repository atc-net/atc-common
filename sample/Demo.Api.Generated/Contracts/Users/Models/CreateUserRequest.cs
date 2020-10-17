﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;

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
    /// Request to create a user.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public class CreateUserRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTimeOffset? MyNullableDateTime { get; set; }

        [Required]
        public DateTimeOffset MyDateTime { get; set; }

        /// <summary>
        /// Undefined description.
        /// </summary>
        /// <remarks>
        /// Email validation being enforced.
        /// </remarks>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// GenderType.
        /// </summary>
        [Required]
        public GenderType Gender { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(MyNullableDateTime)}: {MyNullableDateTime}, {nameof(MyDateTime)}: {MyDateTime}, {nameof(Email)}: {Email}, {nameof(Gender)}: ({Gender})";
        }
    }
}