using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Services;

// Startup.cs does two things:
// 1. Place to register our custom services and to pass them around
// 2. Configure method: Set up the HTTP processing pipeline to respond to requests
namespace OdeToFood {
    public class Startup { // configured how the application behaves
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration) {
            _configuration = configuration; // appsettings.json(?)
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options => {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();
            services.AddSingleton<IGreeter, Greeter>(); // when someone wants IGreeter, pass them Greeter and it'll be used everywhere for every request
            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>(); // any component that needs IRestaurantData, we create an instance for each HTTP request, and then throw it away after we're done. create another one when we need to use it again.
            services.AddScoped<IRestaurantData, SQLRestaurantData>();
            services.AddDbContext<OdeToFoodDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood"))
            );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // for every HTTP message that arrives, it's the code in this config method that defines the components that respond to that request
        // Dependency Injection: Uses it here
        // "Use" methods: Order matters
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              IGreeter greeter,
                              ILogger<Startup> logger) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            // SSL-related Middleware
            app.UseRewriter(new RewriteOptions()
                                .AddRedirectToHttpsPermanent());

            //app.UseDefaultFiles(); // Middleware that looks inside dir and find a default file (like index.html). In paren can place default file if it's NOT index.html
            app.UseStaticFiles(); // Middleware that allows us to use files in wwwroot folder
            //app.UseFileServer(); // Does both of the things above

            app.UseNodeModules(env.ContentRootPath);

            app.UseAuthentication();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            /*// Lesson 3: Part 3
            // ASP.NET invokes this when the framework is ready to set up the pipeline. Invoked once. Needs to return the middleware function to ASP.NET Core.
            app.Use(next => {
                // Middleware: Invoked once per HTTP request that reaches this middleware
                return async context => {
                    logger.LogInformation("Request incoming");

                    if (context.Request.Path.StartsWithSegments("/mym")) {
                        await context.Response.WriteAsync("Hit!!");
                        logger.LogInformation("Request handled!!");
                    } else {
                        await next(context);
                        logger.LogInformation("Response outgoing!!");
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/wp"
            });*/
        }

        // Convention based routing
        private void ConfigureRoutes(IRouteBuilder routeBuilder) {
            // example: /Home/Index/4
            // Controller: Home (MVC framework will add "Controller" to the end of "Home")
            // Action: Index

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"); // MVC framework will say, "aahh, the controller name is Home. Then lets find a 'index' action". 
                                                                                        // ? means the 'id' portion is optional. '=' means default values.
        }
    }
}
