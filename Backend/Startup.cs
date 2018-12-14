using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;
using SavingsDeposits.Helpers;
using SavingsDeposits.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SavingsDeposits
{
    public class Startup
    {
        private AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        private void ConfigureJwt(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // .AddEntityFrameworkInMemoryDatabase()

                .AddDbContext<AppDataContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("SavingDepositContext")));
            services.AddAutoMapper();

            services.AddIdentityCore<User>(options => { });
            new IdentityBuilder(typeof(User), typeof(IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<User>>()
                .AddEntityFrameworkStores<AppDataContext>();
            
            var appSettingsSection = Configuration.GetSection("AppSettings");
            
            services.Configure<AppSettings>(appSettingsSection);

            _appSettings = appSettingsSection.Get<AppSettings>();
         
            ConfigureJwt(services);
            services.AddCors();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISavingsDepositService, SavingsDepositService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddSingleton<IHostedService, DailySavingsComputationService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x=>
                {
                    x.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                    JsonConvert.DefaultSettings = () => x.SerializerSettings;
                   
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDataContext context, UserManager<User> userManager)
        {
            if (env.IsDevelopment())
            {
           //     app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x=>x.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseMiddleware<ExceptionHandlingMiddleware>();
//            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            
            SeedWithData(context, userManager);
        }

        private void SeedWithData(AppDataContext context, UserManager<User> userManager)
        {
            var root = userManager.Users.FirstOrDefault(x => x.UserName == "admin");
            if (root == null)
            {
                root = new User
                {
                    Id = "myId",
                    UserName = "admin",
                    Email = "root@root.com",
                    FullName = "Great Root"
                };
                var res = userManager.CreateAsync(root, "Admin1@#").Result;
                res = userManager.AddToRoleAsync(root, "ADMIN").Result;
            }
            else
            {
                try
                {
                    context.SavingsDeposits.AddRange(TestData());
                    context.SaveChanges();
                
                    SavingsComputationService computationService = new SavingsComputationService(context);
                    for (int i = 0; i < 7; i++)
                    {
                        computationService.RunCalculationForAllUsersAsync(DateTime.Now.AddDays(i)).Wait();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }               
            }
        }
        
        private SavingsDeposit[] TestData()
        {
            SavingsDeposit deposit = new SavingsDeposit
            {
                BankName = "MyDepositBank",
                AccountNumber = 777777777,
                Owner = "myId",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7),
                InitialAmount = 100_000_000,
                TaxPercentage = 20,
                YearlyInterestPercentage = 5
            };            
            
            
            SavingsDeposit depositSmall = new SavingsDeposit
            {
                BankName = "MySmallDepositBank",
                AccountNumber = 333333,
                Owner = "myId",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7),
                InitialAmount = 1000,
                TaxPercentage = 10,
                YearlyInterestPercentage = 30
            };

            SavingsDeposit credit = new SavingsDeposit
            {
                BankName = "MyCreditBank",
                AccountNumber = 111111,
                Owner = "myId",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7),
                InitialAmount = 10_000_000,
                TaxPercentage = 0,
                YearlyInterestPercentage = -10
            };

            return new[] { deposit, credit, depositSmall};
        }
        
    }
}