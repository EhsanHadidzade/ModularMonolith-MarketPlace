using _0_Framework.Domain;
using AccountManagement.Application.Contract.PersonalityType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.PersonalityTypeAgg
{
    public interface IPersonalityTypeRepository:IRepository<long,PersonalityType>
    {
        List<PersonalityTypeViewModel> GetList();
        EditPersonalityType GetDetails(long id);    
    }
}
