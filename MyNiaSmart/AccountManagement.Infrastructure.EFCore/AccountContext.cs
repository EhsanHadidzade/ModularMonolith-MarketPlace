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
using AccountManagement.Domain.UserPersonalityRequestAgg;
using AccountManagement.Domain.UserRoleAgg;
using AccountManagement.Domain.WalletAgg.BusinessWalletAgg;
using AccountManagement.Domain.WalletAgg.OperationTypeAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletChartAgg;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using AccountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore
{
    public class AccountContext : DbContext
    {
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserCooperationRequest> UserCooperationRequests{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserPersonality> UserPersonalities{ get; set; }
        public DbSet<UserPersonalityRequest> UserPersonalityRequests { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<PersonalityType> PersonalityTypes{ get; set; }

        //AboutUpAccountRequests
        public DbSet<UpAccountRequest> UpAccountRequests { get; set; }
        public DbSet<RejectionReason> RejectionReasons { set; get; }
        public DbSet<UpAccountRequestRejectionReason> UpAccountRequestRejectionReasons { get; set; }

        //AboutUserWallet
        public DbSet<BusinessWallet> BusinessWallets{ get; set; }
        public DbSet<PersonalWallet> PersonalWallets { get; set; }
        public DbSet<WalletOperationType> WalletOperationTypes { get; set; }
        public DbSet<Personalwalletoperation> Personalwalletoperations { get; set; }
        public DbSet<PersonalWalletChart> PersonalWalletCharts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);

            
        }
       
    }
}
