using JsonCrafter.Core.Enums;
using JsonCrafter.Demo.Api.Controllers;
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
                .AddJsonCrafter(builder =>
                {
                    builder.EnableMediaType(JsonCrafterMediaType.Hal);
                    builder.For<Test>()
                        .HasId(z => z.Id)
                        //.HasEmbedded(e => e.TestTests)
                        .HasTemplate("doc", "http://docs.com/{someId}/{rel}")
                            .WithParam("someId", x => x.Id2)
                        .HasLinkToSelf("https://feghre/grehgrte/{baba}")
                            .WithParam("baba", e => e.Id2)
                    .For<GetValuesOutputModel>()
                        .HasId(e => e.ModelId);
                    
                    //    builder.For<GetValuesOutputModel>(
                    //        "/v1/users/{0}", t => t.ModelId));
                    //    //.ContainsResource(r => r.Tests);
                    //    builder.For<Test>("/v1/fefewgfef/{0}", o => o.Id);
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
            
            app.UseMvc()
                .UseHttpsRedirection();
        }
    }
}
