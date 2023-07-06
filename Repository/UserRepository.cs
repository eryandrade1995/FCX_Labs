using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Specialized;
using System.ComponentModel;
using FCX_Labs.Data;
using FCX_Labs.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FCX_Labs.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User SearchByLogin(string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.login.ToUpper() == login.ToUpper());
        }

        public User SearchByEmailLog(string email, string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.email.ToUpper() == email.ToUpper() && x.login.ToUpper() == login.ToUpper());
        }

        public User SearchById(long id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.id == id);
        }

        public List<User> Load()
        {
            return _dataContext.Users
                .Include(x => x.Person)
                .ToList();
        }

        public User Add(User user)
        {
            user.insert_date = DateTime.Now;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            User u = SearchById(user.id);

            if (u != null)
            {
                u.name = user.name;
                u.email = user.email;
                u.login = user.login;
                u.profile = user.profile;
                u.alteration_date = DateTime.Now;

                _dataContext.Users.Update(u);
                _dataContext.SaveChanges();
            }
            return u;
        }

        public User ModifyPass(ModifyPassModel modifyPassModel)
        {
            User u = SearchById(modifyPassModel.id);

            if (u == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (u.password != modifyPassModel.old_pass) throw new Exception("Senha atual não confere!");

            if (u.password == modifyPassModel.new_pass) throw new Exception("Nova senha deve ser diferente da senha atual!");
            string invalid = string.Empty;
            invalid = FCX_Labs.Global.Utilities.Functions.checkPass(modifyPassModel.new_pass) != string.Empty ? FCX_Labs.Global.Utilities.Functions.checkPass(modifyPassModel.new_pass) : "";
            if (string.IsNullOrEmpty(invalid))
            {
                u.alteration_date = DateTime.Now;

                _dataContext.Users.Update(u);
                _dataContext.SaveChanges();
            }
            else
            {
                throw new Exception(invalid);
            }


            return u;
        }

        public bool Delete(long id)
        {
            User u = SearchById(id);

            if (u == null) throw new Exception("Houve um erro ao deletar cadastro!");

            _dataContext.Users.Remove(u);
            _dataContext.SaveChanges();

            return true;
        }
    }
}