using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp_Cv.Models
{
    public class Pa {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
    }
    public class Person :Pa
    {
        public string Mdp { get; set; }
        public int Age{get;set;}

        public Person() { }
        public Person(int id,string nom,string email, string mdp,int age) {
            this.Age = age;
            this.Email = email;
            this.Id = id;
            this.Mdp = mdp;
            this.Nom = nom;
        }

    }

    [Serializable]
    public class User :Pa{
        public User(int id,string nom,string email) {
            this.Id = id;
            this.Nom = nom;
            this.Email = email;
        }
    }

    public class PersonDbContext : DbContext {
        public DbSet<Person> Persons { get; set; }
    }
}