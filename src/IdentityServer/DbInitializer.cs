using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
  public class DatabaseInitializer
  {
    public static void Init(IServiceProvider provider)
    {
      InitializeIdentityServer(provider);

      var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();
      var rafi = userManager.FindByNameAsync("rafi").Result;
      if (rafi == null)
      {
        rafi = new IdentityUser
        {
          UserName = "rafi"
        };
        var result = userManager.CreateAsync(rafi, "$AspNetIdentity10$").Result;
        if (!result.Succeeded)
        {
          throw new Exception(result.Errors.First().Description);
        }

        rafi = userManager.FindByNameAsync("rafi").Result;

        result = userManager.AddClaimsAsync(rafi, new Claim[]{
                    new Claim(JwtClaimTypes.Name, "Refael Henig"),
                    new Claim(JwtClaimTypes.GivenName, "Refael"),
                    new Claim(JwtClaimTypes.FamilyName, "Henig"),
                    new Claim(JwtClaimTypes.Email, "yesrefael@blog.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "https://rafihenig.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'localhost 10', 'postal_code': 11146, 'country': 'Greece' }",
                        IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }).Result;

        if (!result.Succeeded)
        {
          throw new Exception(result.Errors.First().Description);
        }
        Console.WriteLine("rafi created");
      }
      else
      {
        Console.WriteLine("rafi already exists");
      }
    }

    private static void InitializeIdentityServer(IServiceProvider provider)
    {
      var context = provider.GetRequiredService<ConfigurationDbContext>();
      if (!context.Clients.Any())
      {
        foreach (var client in Config.GetClients())
        {
          context.Clients.Add(client.ToEntity());
        }
        context.SaveChanges();
      }

      if (!context.IdentityResources.Any())
      {
        foreach (var resource in Config.GetIdentityResources())
        {
          context.IdentityResources.Add(resource.ToEntity());
        }
        context.SaveChanges();
      }

      if (!context.ApiResources.Any())
      {
        foreach (var resource in Config.GetApis())
        {
          context.ApiResources.Add(resource.ToEntity());
        }
        context.SaveChanges();
      }
    }
  }
}