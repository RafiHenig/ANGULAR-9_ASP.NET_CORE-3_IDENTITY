using System;
using System.Threading.Tasks;
using identity.Vms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure
{
  public class StreamingCategoryPolicyProvider : IAuthorizationPolicyProvider
  {
    const string POLICY_PREFIX = "StreamingCategory_";

    public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

    public StreamingCategoryPolicyProvider(IOptions<AuthorizationOptions> options)
    {
      options.Value.AddPolicy("TrialOnly", policy => policy.RequireClaim("Trial"));

      options.Value.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

      options.Value.AddPolicy("AddVideoPolicy", policy => policy.Requirements.Add(new UserCategoryRequirement()));

      FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
      if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
      {
        var category = (StreamingCategory)Enum.Parse(typeof(StreamingCategory),
              policyName.Substring(POLICY_PREFIX.Length));

        var policy = new AuthorizationPolicyBuilder();

        policy.AddRequirements(new StreamingCategoryRequirement(category.ToString()));
        return Task.FromResult(policy.Build());
      }
      else
      {
        return FallbackPolicyProvider.GetPolicyAsync(policyName);
      }
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

  }
}