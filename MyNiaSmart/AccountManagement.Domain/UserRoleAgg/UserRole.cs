using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.UserAgg;

namespace AccountManagement.Domain.UserRoleAgg
{
    public class UserRole:BaseEntity<long>
    {
        public int RoleId { get;private set; }
        public long UserId { get; private set; }

        //Relation with user and role
        public Role Role{ get;private set; }
        public User User{ get;private set; }

        public UserRole(int roleId, long userId)
        {
            RoleId = roleId;
            UserId = userId;
        }
        public void Eit(int roleId, long userId)
        {
            RoleId = roleId;
            UserId = userId;
        }
    }


}
