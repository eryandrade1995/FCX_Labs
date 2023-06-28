using FCX_Labs.Models;
using System.Collections.Generic;

namespace FCX_Labs.Repository
{
    public interface IUserRepository
    {
        User SearchByLogin(string login);
        User SearchByEmailLog(string email, string login);
        List<User> Load();
        User SearchById(long id);
        User Add(User usuario);
        User Update(User usuario);
        User ModifyPass(ModifyPassModel modifyPassModel);
        bool Delete (long id);
    }
}