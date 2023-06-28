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
using System.Collections.Generic;

namespace FCX_Labs.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _dataContext;


        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Person LoadById(long id)
        {
            Person p = new Person();
            p = _dataContext.Person.FirstOrDefault(x => x.id == id);
            return p;
        }
        public List<Person> LoadGrid()
        {
            List<Person> list = new List<Person>();
            foreach (var item in _dataContext.Person)
            {
                list.Add(item);
            }
            return list;
        }
        public Person Add(Person person)
        {
            person.insert_date = DateTime.Now;
            person.stats = "Ativo";
            _dataContext.Person.Add(person);
            _dataContext.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            Person p = LoadById(person.id);
            if (p != null)
            {
                p.name = person.name;
                p.email = person.email;
                p.birth = person.birth;
                p.phone = person.phone;
                p.mother_name = person.mother_name;
                p.stats = person.stats;
                p.alteration_date = DateTime.Now;
            }
            _dataContext.Person.Update(p);
            _dataContext.SaveChanges();
            return p;
        }

        public bool Delete(long id)
        {
            Person p = LoadById(id);
            if (p != null)
            {
                p.stats = "Inativo";
                // _dataContext.Remove(p);
                _dataContext.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }
    }
}