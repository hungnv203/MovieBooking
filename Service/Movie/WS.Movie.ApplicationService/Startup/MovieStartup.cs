using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.ApplicationService.Service.Abstract;
using WS.Movie.ApplicationService.Service.Implement;
using WS.Movie.Infrastructure;
using WS.Share.Constant.Database;

namespace WS.Movie.ApplicationService.Startup
{
    public static class MovieStartup
    {
        public static void ConfigureMovie(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Movie
                            );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<IDirectorService, DirectorService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ICinemaService, CinemaService>();
            builder.Services.AddScoped<ICinemaRoomService, CinemaRoomService>();
            builder.Services.AddScoped<IShowTimeService, ShowTimeService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ISeatService, SeatService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<IDirectorService, DirectorService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ICinemaService, CinemaService>();
            builder.Services.AddScoped<ICinemaRoomService, CinemaRoomService>();
            builder.Services.AddScoped<IShowTimeService, ShowTimeService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ISeatService, SeatService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<AuthenticationService>();

            // Cấu hình Authentication và JWT
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Key"] ?? ""));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = key
                };
            });

            // Cấu hình Swagger
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            // Cấu hình JSON
            builder.Services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
        }
    }

    //builder.Services.AddScoped<IUserInforService, UserInforService2>();
}
