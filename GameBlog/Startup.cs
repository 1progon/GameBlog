using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using GameBlog.Data;
using GameBlog.Models.Users;
using GameBlog.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameBlog
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            var confBuilder = new ConfigurationBuilder()
                .AddJsonFile("passwordsConfig.json")
                .AddConfiguration(configuration);

            Configuration = confBuilder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DBConnect")
                )
            );

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddWebEncoders(
                e => e.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));

            services.AddDefaultIdentity<IdentityUser<int>>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = true;
                        options.Password.RequiredLength = 5;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireDigit = true;
                        options.User.RequireUniqueEmail = true;
                        options.Lockout.MaxFailedAccessAttempts = 3;
                    }
                )
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddMvc();
            services.AddRazorPages();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/login");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Admin area route
                endpoints.MapAreaControllerRoute(
                    "Admin",
                    "Admin",
                    "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            if (env.IsDevelopment())
                File.WriteAllText("browsersync-update.txt", DateTime.Now.ToString());
        }
    }
}