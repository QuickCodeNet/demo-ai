using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using QuickCode.Template0.Persistence.Contexts;

namespace QuickCode.Template0.Api.Extension;

public class CustomClaimsPrincipalFactory(
    UserManager<ApiUser> userManager,
    IOptions<IdentityOptions> optionsAccessor)
    : UserClaimsPrincipalFactory<ApiUser>(userManager, optionsAccessor)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApiUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("PermissionGroupName", user.PermissionGroupName.ToString()!));
        return identity;
    }
}