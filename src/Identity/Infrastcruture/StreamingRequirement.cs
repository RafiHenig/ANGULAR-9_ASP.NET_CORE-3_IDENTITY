using Microsoft.AspNetCore.Authorization;

namespace Identity.Infrastructure
{
  public class StreamingCategoryRequirement : IAuthorizationRequirement
  {
    public string Category { get; set; }
    public StreamingCategoryRequirement(string category) => Category = category;
  }
}