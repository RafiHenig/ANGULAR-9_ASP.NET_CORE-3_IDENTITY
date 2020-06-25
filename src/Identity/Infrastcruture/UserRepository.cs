using System.Collections.Generic;
using identity.Models.Entities;

namespace identity.Infrastructure
{
  public static class UserRepository
  {
    public static List<AppUser> Users { get; set; }

    static UserRepository()
    {
      Users = new List<AppUser>();
    }
  }
}