using System.Collections.Generic;

namespace WebApp.Model
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllUser();
        IEnumerable<Person> GetAllUsersExceptCurrent(string currUserId);
        Person GetUserById(string id);
    }
}