using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Cafe.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Cafe.Query.Handler;
using System.Linq;

namespace AspNetCoreEFCrud.Web
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();

            IntegrateSimpleInjector(services);

            /*var connection = @"Server=.\\SQLEXPRESS;Database=DB_CAFE;Trusted_Connection=True;ConnectRetryCount=30";
            services.AddDbContext<CafeContext>(options => options.UseSqlServer(connection));*/

        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));
            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // ASP.NET default stuff here
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler(" / Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            //Registrando o contexto
            container.Register<ICafeContext, CafeContext>(Lifestyle.Scoped);

            //Registrando as query Handlers
            typeof(MesaAbertaQueryHandler).Assembly.GetExportedTypes()
                .Where(x => x.Namespace.EndsWith("Handler"))
                .Where(x => x.GetInterfaces().Any())
                .ToList()
                .ForEach(x => container.Register(x.GetInterfaces().Single(), x, Lifestyle.Transient));

            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);
        }
    }
}
