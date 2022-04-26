using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleTypeAgg
{
    public class RoleType:BaseEntity<int>
    {
        #region Properties
        public string RoleTypeName { get; private set; }
        public bool IsRemoved { get;private set; }
        #endregion
        #region Relations
        public List<Role> Roles{ get; private set; }
        #endregion
        public RoleType(string roleTypeName)
        {
            RoleTypeName = roleTypeName;
            IsRemoved = false;
            Roles = new List<Role>();
        }

        public void Edit(string roleTypeName)
        {
            RoleTypeName=roleTypeName;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved=false;
        }



    }
}
