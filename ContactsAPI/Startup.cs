using AutoMapper;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Queries.GetContactDetail;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Application.Contacts;
using System.Reflection;
using Application.Contacts.Commands;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Queries.GetAllContactsByCity;
using Application.Contacts.Queries.GetContactByEmail;
using Application.Contacts.Queries.GetContactByPhoneNumber;

namespace ContactsAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=ContactsDb;Trusted_Connection=True;";
            services.AddDbContext<ContacDbContext>(x => x.UseSqlServer(connectionString));

            ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public void ConfigureIoC(IServiceCollection services)
        {
            services.AddTransient<ICreateContactCommand, CreateContactCommand>();
            services.AddTransient<IUpdateContactCommand, UpdateContactCommand>();
            services.AddTransient<IDeleteContactCommand, DeleteContactCommand>();
            services.AddTransient<IGetAllContactsByCityQuery, GetAllContactsByCityQuery>();
            services.AddTransient<IGetAllContactsByStateQuery, GetAllContactsByStateQuery>();
            services.AddTransient<IGetContactByEmailQuery, GetContactByEmailQuery>();
            services.AddTransient<IGetContactByPhoneNumberQuery, GetContactByPhoneNumberQuery>();
            services.AddTransient<IGetContactDetailQuery, GetContactDetailQuery>();
            services.AddTransient<IContacDbContext, ContacDbContext>();

            services.AddAutoMapper(Assembly.Load("Application"));
        }
    }
}
