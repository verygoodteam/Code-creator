using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.Areas;
using HR.Hospital.IRepository.Clinical;
using HR.Hospital.IRepository.OoperationUser;
using HR.Hospital.IRepository.OperationRooms;
using HR.Hospital.Model;
using HR.Hospital.Repository.Areas;
using HR.Hospital.Repository.Clinical;
using HR.Hospital.Repository.OoperationUser;
using HR.Hospital.Repository.OperationRooms;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace HR.Hospital.WebApi
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

            //注册跨域服务，允许所有来源
            services.AddCors(options =>
                options.AddPolicy("AllowAnyCors",
                p => p.WithOrigins().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
            );

            //注册Cookie认证服务
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //ef mysql 配置
            services.AddDbContext<hospitaldbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));

            //注册映射关系
            //手术室用户
            services.AddScoped<IOoperationUserRepository, OoperationUserRepository>();
            //临床用户
            services.AddScoped<IClinicalRepository, ClinicalRepository>();
            //专业组
            //services.AddScoped<IGroupRepository, GroupRepository>();

            //院区
            services.AddScoped<IAreaRepository, AreaRepository>();
            //手术间映射关系
            services.AddScoped<IOperationRoomRepository, OperationRoomRepository>();



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
            //允许跨域访问
            app.UseCors("AllowAnyCors");

            //启动认证服务
            //注意app.UseAuthentication方法一定要放在下面的app.UseMvc方法前面，否者后面就算调用HttpContext.SignInAsync进行用户登录后，使用
            //HttpContext.User还是会显示用户没有登录，并且HttpContext.User.Claims读取不到登录用户的任何信息。
            //这说明Asp.Net OWIN框架中MiddleWare的调用顺序会对系统功能产生很大的影响，各个MiddleWare的调用顺序一定不能反
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
