// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdSrv
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource
                    {
                        Name = "calculator-api",
                        DisplayName = "Calculator API",
                        Description = "Calculates your doubles and squares.",
                        Scopes = new List<Scope>
                        {
                            new Scope
                            {
                                Name = "calc:double",
                                DisplayName = "calc:double",
                                Description = "Calculate double",
                            },
                            new Scope
                            {
                                Name = "calc:square",
                                DisplayName="calc:square",
                                Description = "Calculate square",
                            }
                        },
                    }, 
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "calc:double", "calc:square" }
                },
            };
    }
}