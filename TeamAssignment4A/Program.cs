using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TeamAssignment4A.Data;
using Microsoft.AspNetCore.Identity;
using TeamAssignment4A.Areas.Identity;
using TeamAssignment4A.Models;
using TeamAssignment4A.Models.IdentityUsers;

namespace TeamAssignment4A {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("OnLineServer") ?? throw new InvalidOperationException("Connection string 'OnLineServer' not found.");

            builder.Services.AddDbContext<WebAppDbContext>(options =>
                options.UseSqlServer(connectionString));
                            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            //builder.Services.AddDbContext<WebAppDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<WebAppDbContext>();
            

            //dbContext.Database.Migrate();
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add services to the container.
            builder.Services.AddRazorPages();
            //builder.Services.AddMvc();
            //builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseMigrationsEndPoint();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); ;
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name:"default",
            //    pattern:"{ controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}