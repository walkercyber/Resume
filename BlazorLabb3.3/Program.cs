using BlazorLabb3._3.Components;
using BlazorLabb3._3.Service;
using BlazorLabb3._3.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorLabb3._3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpClient("API", client =>
            {
                client.BaseAddress = new Uri(""); // Ändra till din API-URL
            });

            builder.Services.AddScoped<AdminService>();
            builder.Services.AddScoped<SkillService>();
            builder.Services.AddScoped<ProjectService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
