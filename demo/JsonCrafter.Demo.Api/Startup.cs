using JsonCrafter.Core.Configuration;
using JsonCrafter.Demo.Api.Controllers;
using JsonCrafter.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonCrafter.Demo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o =>
                {
                    o.RespectBrowserAcceptHeader = true;
                    o.ReturnHttpNotAcceptable = true;
                    o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                })
                .AddJsonCrafterFormatters((builder, url) =>
                {
                    builder.EnableMediaType(MediaType.Hal);
                    builder.For<GetValuesOutputModel>(url.Action(nameof(ValuesController.Get), "Values", new { Boogle = "{0}" }), t => t.Tests.ToString());
                    builder.For<Test>(url.Action(nameof(ValuesController.Get), "Values"));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
