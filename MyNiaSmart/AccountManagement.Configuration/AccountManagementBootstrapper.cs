using _0_MyNiaSmartQuery.Contract.User;
using _0_MyNiaSmartQuery.Query;
using AccountManagement.Application;
using AccountManagement.Application.Contract.BusinessWallet;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.PersonalityType;
using AccountManagement.Application.Contract.PersonalWallet;
using AccountManagement.Application.Contract.PersonalWalletChart;
using AccountManagement.Application.Contract.PersonalWalletOperation;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.UpAccountRequest;
using AccountManagement.Application.Contract.UpAccountRequestRejectionReason;
using AccountManagement.Application.Contract.User;
using AccountManagement.Application.Contract.UserCooperationRequest;
using AccountManagement.Application.Contract.UserPersonality;
//using AccountManagement.Application.Contract.UserPersonalityRequest;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Application.Wallet;
using AccountManagement.Domain.CooperationRequestAgg;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.PersonalityTypeAgg;
using AccountManagement.Domain.RejectionReasonAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.RoleTypeAgg;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using AccountManagement.Domain.UPAccountRequestsAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserPersonalityAgg;
//using AccountManagement.Domain.UserPersonalityRequestAgg;
using AccountManagement.Domain.UserRoleAgg;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
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

            services.AddTransient<IUserCooperationRequestApplication,UserCooperationRequestApplication>();
            services.AddTransient<IUserCooperationRequestRepository, UserCooperationRequestRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            
            services.AddTransient<IPersonalityApplication,PersonalityApplication>();
            services.AddTransient<IPersonalityRepository,PersonalityRepository>();

            services.AddTransient<IPersonalityTypeApplication, PersonalityTypeApplication>();
            services.AddTransient<IPersonalityTypeRepository, PersonalityTypeRepository>();

            services.AddTransient<IUserPersonalityApplication,UserPersonalityApplication>();
            services.AddTransient<IUserPersonalityRepository,UserPersonalityRepository>();

            //services.AddTransient<IUserPersonalityRequestApplication, UserPersonalityRequestApplication>();
            //services.AddTransient<IUserPersonalityRequestRepository, UserPersonalityRequestRepository>();

            services.AddTransient<IUPAccountRequestApplication,UpAccountRequestApplication>();
            services.AddTransient<IUPAccountRequestRepository, UpAccountRequestRepository>();

            services.AddTransient<IRejectionReasonApplication, RejectionReasonApplication>();
            services.AddTransient<IRejectionReasonRepository, RejectionReasonRepository>();

            services.AddTransient<IUpAccountRequestRejectionReasonApplication, UpAccountRequestRejectionReasonApplication>();
            services.AddTransient<IUpAccountRequestRejectionReasonRepository, UpAccountRequestRejectionReasonRepository>();

            services.AddTransient<IPersonalWalletRepository, PersonalWalletRepository>();
            services.AddTransient<IPersonalWalletApplication, PersonalWalletApplication>();

            services.AddTransient<IBusinessWalletRepository,  BusinessWalletRepository>();
            services.AddTransient<IBusinessWalletApplication, BusinessWalletApplication>();

            services.AddTransient<IPersonalWalletOperationRepository, PersonalWalletOperationRepository>();
            services.AddTransient<IPersonalWalletOperationApplication, PersonalWalletOperationApplication>();

            services.AddTransient<IPersonalWalletChartRepository, PersonalWalletChartRepository>();
            services.AddTransient<IPersonalWalletChartApplication, PersonalWalletChartApplication>();


            //client query
            services.AddTransient<IUserQuery, UserQuery>();


            services.AddDbContext<AccountContext>(item => item.UseSqlServer(connectionstring));
        }
    }
}
