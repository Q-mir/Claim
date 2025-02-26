using AuthDomain.Querys.Object;
using Service;
using System.Security.Claims;

namespace AuthDomain.Querys
{
    public class CreatePrincipleQueryService : IQueryService<User, ClaimsPrincipal>
    {
        public ClaimsPrincipal Execute(User obj)
        {
            ICollection<Claim> claims = new List<Claim>();
            foreach (var item in obj.Rules)
            {
                Claim claim = new("role", item);
                claims.Add(claim);
            }
            var identity = new ClaimsIdentity(claims, "RulesClaim", ClaimTypes.Name, ClaimTypes.Role);
            return new ClaimsPrincipal(identity);
        }
    }
}