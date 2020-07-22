using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using identity.Vms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure
{
  internal class StreamingCategoryAuthorizationHandler : AuthorizationHandler<StreamingCategoryRequirement>
  {

    private readonly UserManager<IdentityUser> _userManager;

    public StreamingCategoryAuthorizationHandler(UserManager<IdentityUser> userManager)
    {
      _userManager = userManager;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, StreamingCategoryRequirement requirement)
    {
      IdentityUser loggedInUser = await _userManager.GetUserAsync(context.User);
      IList<Claim> userClaims = await _userManager.GetClaimsAsync(loggedInUser);

      if (userClaims.Any(c => c.Type == requirement.Category))
      {
        context.Succeed(requirement);
      }
    }
  }
}