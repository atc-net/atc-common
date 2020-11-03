﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Users;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.181.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
namespace Demo.Api.Tests.Endpoints.Users.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.181.0")]
    public class UpdateUserByIdHandlerStub : IUpdateUserByIdHandler
    {
        public Task<UpdateUserByIdResult> ExecuteAsync(UpdateUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(UpdateUserByIdResult.Ok("Hallo world"));
        }
    }
}