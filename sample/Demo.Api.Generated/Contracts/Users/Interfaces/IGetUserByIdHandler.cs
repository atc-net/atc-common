﻿using System.CodeDom.Compiler;
using System.Threading;
using System.Threading.Tasks;

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
    /// Domain Interface for RequestHandler.
    /// Description: Get user by id.
    /// Operation: GetUserById.
    /// Area: Users.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.147.0")]
    public interface IGetUserByIdHandler
    {
        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<GetUserByIdResult> ExecuteAsync(GetUserByIdParameters parameters, CancellationToken cancellationToken = default);
    }
}