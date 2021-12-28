// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;

namespace IdentitySpike.IdentityApi;

public static class Config
{
	public static IEnumerable<IdentityResource> IdentityResources
	{
		get
		{
			yield return new IdentityResources.OpenId();
		}
	}

	public static IEnumerable<ApiScope> ApiScopes
	{
		get
		{
			yield return new("api1", "My API");
		}
	}

	public static IEnumerable<Client> Clients
	{
		get
		{
			yield return new()
			{
				ClientId = "client",

				// no interactive user, use the clientid/secret for authentication
				AllowedGrantTypes = GrantTypes.ClientCredentials,

				// secret for authentication
				ClientSecrets =
				{
					new Secret("secret".Sha256()),
				},

				// scopes that client has access to
				AllowedScopes = { "api1", },
			};
		}
	}
}
