﻿using JsonCrafter.Demo.Api.Controllers;
using JsonCrafter.Shared.Enums;
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
                .AddJsonCrafter((builder) =>
                {
                    builder.EnableMediaType(JsonCrafterMediaType.Hal);
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
