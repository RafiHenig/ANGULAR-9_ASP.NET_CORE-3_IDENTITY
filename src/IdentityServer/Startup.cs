using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
      Configuration = configuration;
      Environment = env;
    }


    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddControllers();
      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(connectionString));

      services.AddIdentity<IdentityUser, IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDbContext>()
         .AddDefaultTokenProviders();

      services.AddControllersWithViews();


      var builder = services
      .AddIdentityServer(options =>
      {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
      })
      .AddConfigurationStore(options => options.ConfigureDbContext = opt => opt
      .UseSqlServer(
        connectionString,
         optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name)
        )
      )
      .AddOperationalStore(options =>
      {
        options.ConfigureDbContext = opt => opt.UseSqlServer(
        connectionString,
         optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name)
        );
        options.EnableTokenCleanup = true;
      })
      .AddAspNetIdentity<IdentityUser>();

      if (Environment.IsDevelopment())
      {
        builder.AddDeveloperSigningCredential();
      }
      else
      {
        throw new Exception("need to configure key material");
      }

      services.AddAuthentication();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();


      app.UseIdentityServer();

      app.UseEndpoints(endpoints =>
             {
               endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
             });
    }
  }
}
