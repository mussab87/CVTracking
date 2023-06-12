using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Infrastructure { }

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkSqlServer();
        services.AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("ServiceDBConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole>(
                o =>
                {
                    // configure identity options
                    o.Password.RequireDigit = Convert.ToBoolean(configuration.GetSection("AppSetting:PassRequireDigit").Value);
                    o.Password.RequireLowercase = Convert.ToBoolean(configuration.GetSection("AppSetting:PassRequireLowercase").Value);
                    o.Password.RequireUppercase = Convert.ToBoolean(configuration.GetSection("AppSetting:PassRequireUppercase").Value);
                    o.Password.RequireNonAlphanumeric = Convert.ToBoolean(configuration.GetSection("AppSetting:PassRequireNonAlphanumeric").Value);
                    o.Password.RequiredLength = Convert.ToInt32(configuration.GetSection("AppSetting:UserPasswordLength").Value);
                })
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(configuration.GetSection("AppSetting:UserSessionTimeOut").Value));
            options.LoginPath = "/Account/Login";
            options.SlidingExpiration = true;
        });

        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.Zero;
        });


        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IRootCompanyRepository, RootCompanyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IUserRootCompanyRepository, UserRootCompanyRepository>();
        services.AddScoped<IForeignAgentRepository, ForeignAgentRepository>();
        services.AddScoped<ICVRepository, CVRepository>();
        services.AddScoped<ICVStatusRepository, CVStatusRepository>();
        services.AddScoped<IAttachmentRepository, AttachmentRepository>();
        services.AddScoped<IPreviousEmploymentsRepository, PreviousEmploymentsRepository>();
        services.AddScoped<IReligionRepository, ReligionRepository>();
        services.AddScoped<IMartialStatusRepository, MartialStatusRepository>();
        services.AddScoped<ICVHRPool, CVHRPool>();
        services.AddScoped<ICVAttachmentRepository, CVAttachmentRepository>();

        //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        //services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}

