using Microsoft.AspNetCore.Authorization;

namespace FIFA_API.Models
{
    public class Policies
    {
        public const string Admin = "Admin";
        public const string Utilisateur = "Utilisateur";
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Utilisateur).Build();
        }
    }
}
