using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Role
{
    public class RoleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RoleTypeName { get; set; }
        public string CreationDate { get; set; }
    }
}
