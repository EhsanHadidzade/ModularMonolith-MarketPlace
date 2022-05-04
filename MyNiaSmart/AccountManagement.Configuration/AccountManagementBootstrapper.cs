using _0_MyNiaSmartQuery.Contract.User;
using _0_MyNiaSmartQuery.Query;
using AccountManagement.Application;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.User;
using AccountManagement.Application.Contract.UserPersonality;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.RoleTypeAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserPersonalityAgg;
using AccountManagement.Domain.UserRoleAgg;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IRoleTypeApplication, RoleTypeApplication>();
            services.AddTransient<IRoleTypeRepository, RoleTypeRepository>();


            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserRoleApplication, UserRoleApplication>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

          
            
            services.AddTransient<IPersonalityApplication,PersonalityApplication>();
            services.AddTransient<IPersonalityRepository,PersonalityRepository>();

            services.AddTransient<IUserPersonalityApplication,UserPersonalityApplication>();
            services.AddTransient<IUserPersonalityRepository,UserPersonalityRepository>();

            //client query
            services.AddTransient<IUserQuery, UserQuery>();


            services.AddDbContext<AccountContext>(item => item.UseSqlServer(connectionstring));
        }
    }
}
