using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Hubs;
using MoviePoint.logic.Repository;
using MoviePoint.Models;
using MoviePoint.Repository;
using System.Security.Principal;

namespace MoviePoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MoviePointContext>(option =>
            {
                //option.UseSqlServer(builder.Configuration.GetConnectionString("Esraa"));
                //option.UseSqlServer(builder.Configuration.GetConnectionString("Hadeer Salah"));
                option.UseSqlServer(builder.Configuration.GetConnectionString("Ghada"));

                //option.UseSqlServer(builder.Configuration.GetConnectionString("Asmaa"));
                //option.UseSqlServer(builder.Configuration.GetConnectionString("Alaa"));


            });

           // builder.Services.AddSignalR();//register to any hub
			builder.Services.AddSignalR(options =>
			{
				options.EnableDetailedErrors = true;
			});
			builder.Services.AddCors(//built in service need register
                options =>

                    options.AddDefaultPolicy(cong => {
                        cong.AllowAnyMethod().
                        SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader()
                        .AllowCredentials();
                        //SetIsOriginAllowed((host) => {
                        //    if (host == "http://127.0.0.1:64513/")
                        //        return true;
                        //    return false;
                        //})
                    })
                );

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }
            ).AddEntityFrameworkStores<MoviePointContext>();

            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IActorMovieRepository, ActorMovieRepository>();
            builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
			builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
			

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();
            app.MapHub<MovieHub>("/MovieHub");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=home}/{id?}");

            app.Run();
        }
    }
}