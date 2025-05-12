using IdentityServer4.Models;

namespace AluguelCarros.Infrastructure.Identity
{
    public static class Config
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("api.admin", "Acesso Administrativo à API"),
                new ApiScope("api.cliente", "Acesso de Cliente à API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "admin",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("admin_secret".Sha256()) },
                    AllowedScopes = { "api.admin" },
                    Claims = new List<ClientClaim>
                    {
                        new ClientClaim("role", "admin")
                    }
                },
                // Cliente para Cliente
                new Client
                {
                    ClientId = "cliente",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("cliente_secret".Sha256()) },
                    AllowedScopes = { "api.cliente" },
                    Claims = new List<ClientClaim>
                    {
                        new ClientClaim("role", "cliente")
                    }
                }
            };
        }
    }
}
