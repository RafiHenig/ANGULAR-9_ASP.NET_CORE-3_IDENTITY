using identity.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Identity
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddTransient<IAuthorizationPolicyProvider, StreamingCategoryPolicyProvider>();

      // As always, handlers must be provided for the requirements of the authorization policies
      services.AddTransient<IAuthorizationHandler, StreamingCategoryAuthorizationHandler>();
      services.AddTransient<IAuthorizationHandler, UserCategoryAuthorizationHandler>();

      services.AddMvc(options => options.EnableEndpointRouting = false);
      // In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });

      services.AddDbContext<IdentityDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("Default"),
        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name))
        );

      services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDbContext>()
                    .AddDefaultTokenProviders();


      // services
      // .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      // .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

      services.ConfigureApplicationCookie(options =>
      {
        options.Events.OnRedirectToLogin = context =>
        {
          context.Response.Headers["Location"] = context.RedirectUri;
          context.Response.StatusCode = 401;
          return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = context =>
        {
          context.Response.Headers["Location"] = context.RedirectUri;
          context.Response.StatusCode = 403;
          return Task.CompletedTask;
        };
      });

      services.AddScoped<IDbInitializer, DbInitializer>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      app.UseStaticFiles();

      if (!env.IsDevelopment())
      {
        app.UseSpaStaticFiles();
      }
    //  app.UseDeveloperExceptionPage();
      app.UseAuthentication();
      app.UseRouting();
      app.UseAuthorization();

  app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

      app.UseSpa(spa =>
      {
        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        // see https://go.microsoft.com/fwlink/?linkid=864501

        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
        }
      });
    }

    // static Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(
    //   HttpStatusCode statusCode,
    //   Func<RedirectContext<CookieAuthenticationOptions>, Task> existingRedirector
    // ) =>
    // context =>
    // {
    //   if (context.Request.Path.StartsWithSegments("/api"))
    //   {
    //     context.Response.Headers["Location"] = context.RedirectUri;
    //     context.Response.StatusCode = (int)statusCode;
    //     return Task.CompletedTask;
    //   }
    //   return existingRedirector(context);
    // };
  }
}


