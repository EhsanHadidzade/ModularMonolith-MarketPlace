using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Personality;
using AccountManagement.Domain.PersonalityAgg;
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
                Title=x.Title
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<PersonalityViewModel> GetList()
        {
            return _context.Personalities.Select(x => new PersonalityViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
