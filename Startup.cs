using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPIStarter
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
            // services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession(); 
            services.AddMvc();
            services.AddControllers();  
            // services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Use(async (context, next) =>
            // {
            //     await next.Invoke();   
            // });

            app.Map("/hello", appbuilder => {
                appbuilder.MapWhen(
                    context => context.Request.Query.ContainsKey("name"),
                    (appB) => {
                        appB.Run(async newContext => {
                            await newContext.Response.WriteAsync($"Hello { newContext.Request.Query["name"] }!!");
                        });
                    }
                );
            });

            app.UseHttpsRedirection();  //OK
            app.UseStaticFiles(); 
            
            app.UseRouting();
            
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints => //OK
            {
                endpoints.MapControllers();
            });

            // app.UseMvc();
        }
    }
}
