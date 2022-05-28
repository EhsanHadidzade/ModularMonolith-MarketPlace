using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Domain.PersonalityAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class PersonalityRepository : BaseRepository<long, Personality>, IPersonalityRepository
    {
        private readonly AccountContext _context;

        public PersonalityRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditPersonality GetDetails(long id)
        {
            return _context.Personalities.Select(x=>new EditPersonality
            {
                Id=x.Id,
                Title=x.Title,
                PersonalityTypeId=x.PersonalityTypeId,
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<PersonalityViewModel> GetList()
        {
            return _context.Personalities.Include(x=>x.PersonalityType).Select(x => new PersonalityViewModel
            {
                Id = x.Id,
                Title = x.Title,
                PersonalityTypeTitle=x.PersonalityType.Title,
                CreationDate=x.CreationDate.ToFarsi(),
                PersonalityTypeId=x.PersonalityTypeId
            }).ToList();
        }
    }
}
