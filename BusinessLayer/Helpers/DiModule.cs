using BusinessLayer.Contracts;
using BusinessLayer.Implementation;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
           

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<TodoDbContext>(options =>
                options.UseSqlServer(connectionString)
                );

            services.AddTransient<MapperProfile>();

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = true;
                




            })
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<TodoDbContext>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<TodoDbContext>();
           
                
            
                

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<TodoTask>, TodoTaskRepository>();
            services.AddScoped<IRepository<SubTodoTask>, SubTodoTaskRepository>();
            services.AddScoped<ITaskTypeRepository, TodoTaskTypeRepository>();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ITaskServices, TaskServices>();
            services.AddScoped<ITodoTaskTypeServices, TaskTypeServices>();
            services.AddScoped<ISubTaskService, SubTaskServices>();

            return services;
                
        }

    }
}
