using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.BLL.BBSAdmin;
using WebMvc.DAL.BBSAdmin;
using WebMvc.IDAL.BBSAdmin;
using WebMvc.ViewModel;
using AutoMapper;
using System.Reflection;
using Common.Standard.AutoMapper9;
using WebMvc.DemoClass.AutoMapperDemo;
using WebMvc.Components;
using WebMvc.Filter;

namespace WebMvc
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; set; }

        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //用于直接读取数据库，不走框架(该注入仅用于测试)
            //services.AddDbContext<WebMvc.Model.BBSAdmin.BBSAdminContext>(options => options.UseMySQL(Configuration.GetConnectionString("BBSAdmin_MySqlConnection")));
            //services.AddDbContext<WebMvc.Model.BBSAdmin.BBSAdminContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BBSAdminConnection")));
            //services.AddSingleton<AutoInjectFactory>();
            //services.AddAutoMapper();

            services.AddMvc(options=> {
                options.Filters.Add(new PermissionRequiredAttribute());
            }).AddControllersAsServices().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);
            //builder.RegisterType<MyType>().As<IMyType>();
            builder.RegisterType<UserTableDAL>().As<IUserTableDAL>();
            builder.RegisterType<UserTableService>().As<IUserTableService>();
            builder.RegisterType<KeywordsDAL>().As<IKeywordsDAL>();
            builder.RegisterType<KeywordsService>().As<IKeywordsService>();
            builder.RegisterType<UserAdminVM>();

            //automapper
            builder = builder.LoadAutoMapper();
            //builder.RegisterType<AutoMapperInjection>().WithParameter("_builder",builder);
            builder.RegisterType<AutoMapperProfile>();
            //builder.RegisterType<AutoMapperProfile>().OnActivating(e=> {
            //    var result = e.Context.Resolve<AutoMapperInjection>().Load();
            //    e.Instance.Mapping(result);
            //});



            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            using (var scope = this.ApplicationContainer.BeginLifetimeScope())
            {
                scope.Resolve<AutoMapperProfile>().Mapping(scope);


            }
            //Mappings.RegisterMappings();
            //app.UseStateAutoMapper();
            //app.UseAutoInject(Assembly.Load("WebMvc"));

            //var expression = app.UseAutoMapper();
            //expression.CreateMap<User, UserDto>();
            //expression.CreateMap<Head, UserDto>().ForMember(m => m.Eye, a => a.MapFrom(s => s.Eye));

            //expression.CreateMap<PhysicalAttribute, PeopleDto>()
            //    .ForMember(m => m.Eye, n => n.MapFrom(s => s.Eye))
            //    .ForMember(m => m.Mouth, n => n.MapFrom(s => s.Mouth));
            ////.ForMember(m => m.Ear, n => n.Ignore());
            //expression.CreateMap<SocialAttribute, PeopleDto>()
            //    .ForMember(m => m.Age, n => n.MapFrom(s => s.Age))
            //    .ForMember(m => m.IsMarried, n => n.MapFrom(s => s.IsMarried));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "WebApi",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );


            });

        }
    }
}
