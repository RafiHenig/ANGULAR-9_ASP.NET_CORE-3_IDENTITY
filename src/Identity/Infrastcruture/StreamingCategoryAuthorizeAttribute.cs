using System;
using identity.Vms;
using Microsoft.AspNetCore.Authorization;


namespace Identity.Infrastructure
{
  public class StreamingCategoryAuthorizeAttribute : AuthorizeAttribute
  {
    const string POLICY_PREFIX = "StreamingCategory_";
    public StreamingCategoryAuthorizeAttribute(StreamingCategory category) {
      Category = category;
    }

    // Get or set the Category property by manipulating the underlying Policy property
    public StreamingCategory Category
    {
      get
      {
        var category = (StreamingCategory)Enum.Parse(typeof(StreamingCategory),
            Policy.Substring(POLICY_PREFIX.Length));

        return (StreamingCategory)category;
      }
      set
      {
        Policy = $"{POLICY_PREFIX}{value.ToString()}";
      }
    }
  }
}

