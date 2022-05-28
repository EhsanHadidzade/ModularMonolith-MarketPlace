using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Application.Contract.PersonalityType;
using AccountManagement.Domain.PersonalityAgg;
using AccountManagement.Domain.PersonalityTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class PersonalityTypeRepository:BaseRepository<long,PersonalityType>,IPersonalityTypeRepository
    {
        private readonly AccountContext _context;

        public PersonalityTypeRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditPersonalityType GetDetails(long id)
        {
            return _context.PersonalityTypes.Select(x=>new EditPersonalityType
            {
                Id = x.Id,
                Title=x.Title
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<PersonalityTypeViewModel> GetList()
        {
            return _context.PersonalityTypes.Select(x => new PersonalityTypeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Personalities=MapPersonalities(x.Personalities),
            }).ToList();
        }

        private static List<PersonalityViewModel> MapPersonalities(List<Personality> personalities)
        {
           return personalities.Select(x => new PersonalityViewModel
            {
                Id = x.Id,
                PersonalityTypeId = x.PersonalityTypeId,
                Title = x.Title,

            }).ToList();
        }
    }
}
