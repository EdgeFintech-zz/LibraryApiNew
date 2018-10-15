using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Extensions;
using JsonApiDotNetCore.Models;
using LibraryApiNew.Domain.Authors;
using LibraryApiNew.Domain.Books;
using LibraryApiNew.Domain.Users;
using LibraryApiNew.Models;
using LibraryApiNew.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LibraryApiNew
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>();
            services.AddJsonApi<AppDbContext>(options =>
            {
                options.ValidateModelState = true;
            });

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT_SECRET"]));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            services.AddSingleton(signingKey);
            services.AddSingleton(creds);

            services.AddCors();

            services.AddScoped<CurrentUserService>();
            services.AddScoped<IEntityRepository<Author>, AuthorsRepository>();
            services.AddScoped<IEntityRepository<Book>, BooksRepository>();
            services.AddScoped<ResourceDefinition<User>, UserResource>();
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
                app.UseHsts();
            }

            app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseJsonApi();

            // // Uncomment the code below to generate a new JWT_SECRET value when restarting the server.
            // var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // var bytes = new byte[48];
            // crypto.GetBytes(bytes);
            // Console.WriteLine(Convert.ToBase64String(bytes));
        }
    }
}
