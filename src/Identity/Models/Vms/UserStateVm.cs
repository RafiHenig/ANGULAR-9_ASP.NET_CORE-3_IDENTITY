using System.Collections.Generic;
using System.Security.Claims;

namespace identity.Vms{
  public class UserStateVM
  {
      public bool IsAuthenticated { get; set; }
      public string UserName { get; set; }
      public IList<string> Roles { get; set; }
  }
}