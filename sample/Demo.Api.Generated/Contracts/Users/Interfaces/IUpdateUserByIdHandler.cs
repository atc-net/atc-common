﻿using System.Threading;
using System.Threading.Tasks;

//------------------------------------------------------------------------------
// This code was auto-generated by Atc.Rest.ApiGenerator 1.0.0.0.
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
    /// Description: Update user by id.
    /// Operation: UpdateUserById.
    /// Area: Users.
    /// </summary>
    public interface IUpdateUserByIdHandler
    {
        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<UpdateUserByIdResult> ExecuteAsync(UpdateUserByIdParameters parameters, CancellationToken cancellationToken = default);
    }
}