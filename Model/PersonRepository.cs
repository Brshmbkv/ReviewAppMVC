using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database.Context;

namespace WebApp.Model
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MainContex _context;
        public PersonRepository(MainContex context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllUsersExceptCurrent(string currUserId)
        {
            return _context.Persons.Where(u => u.Id != currUserId).ToList();
        }

        public IEnumerable<Person> GetAllUser()
        {
            return _context.Persons.ToList();
        }

        public Person GetUserById(string id)
        {
            return _context.Persons.ToList().Find(p => p.Id == id);
        }
    }
}
