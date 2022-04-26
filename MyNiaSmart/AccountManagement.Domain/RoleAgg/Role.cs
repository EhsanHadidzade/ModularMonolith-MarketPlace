using _0_Framework.Domain;
using AccountManagement.Domain.RoleTypeAgg;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserRoleAgg;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role:BaseEntity<int>
    {
        #region Properties
        public string Name { get; private set; }
        public bool IsRemoved { get;private set; }
        #endregion

        #region Relations
        //relation with UserRole
        public List<UserRole> UserRoles{ get;private set; }

        //relation with RoleType
        public int? RoleTypeId { get;private set; }
        public RoleType RoleType { get;private set; }
        #endregion

        public Role(string name,int? roleTypeId)
        {
            Name = name;
            RoleTypeId = roleTypeId;
            IsRemoved=false;
            UserRoles = new List<UserRole>();
        }
        
        public void Edit(string name,int? roleTypeId)
        {
            Name=name;
            RoleTypeId=roleTypeId;
        }
        public void Remove()
        {
            IsRemoved=true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

    }

}
