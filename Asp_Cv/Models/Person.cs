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
        public Person(Person p1) {
            this.Age = p1.Age;
            this.Email = p1.Email;
            this.Id = p1.Id;
            this.Mdp = p1.Mdp;
            this.Nom = p1.Nom;
        }
        public void permut(Person p1) {
            this.Age = p1.Age;
            this.Email = p1.Email;
            this.Id = p1.Id;
            this.Mdp = p1.Mdp;
            this.Nom = p1.Nom;
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