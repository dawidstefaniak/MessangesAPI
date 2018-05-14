using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessangesAPI.Controllers;
using MessangesAPI.Entities;
using MessangesAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace MessangesAPI
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
            services.AddMvc(options =>{ options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());})
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            //USING SQL SERVER
            //var connectionString = @"Server=(localdb)\mssqllocaldb;Database=MessangerDB;Trusted_Connection=True;";
            //services.AddDbContext<MessagesContext>(o=>o.UseSqlServer(connectionString));

            //USING SQLITE
            services.AddDbContext<MessagesContext>(o => o.UseSqlite("Data Source=sqlitedatabase.db"));

            services.AddScoped<IMessangerRepository, MessangerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.MessageForCreationDto, Entities.Message>();
                cfg.CreateMap<Entities.Message, Models.MessageDto>();
                cfg.CreateMap<Models.UserToLoginDto,Entities.User>();
                cfg.CreateMap<Entities.User,Models.LoggedUserToReturnDto>();
                cfg.CreateMap<Entities.User, Models.UserToReturnDto>();
                cfg.CreateMap<Entities.User,Models.LoggedUserToReturnDto>();
                cfg.CreateMap<Models.UserForCreationDto, Entities.User>();
                cfg.CreateMap<Entities.Case,Models.CaseToReturnDto>();
                cfg.CreateMap<Models.CaseToReturnDto,Entities.Case>();
                cfg.CreateMap<Models.CaseForCreationDto,Entities.Case>();
                cfg.CreateMap<Entities.User,Models.UserListToReturnDto>();
                cfg.CreateMap<Models.UserListToReturnDto,Entities.User>();
            });
        }
    }
}
