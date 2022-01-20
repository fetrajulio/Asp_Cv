using Asp_Cv.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;

namespace Asp_Cv.Repository
{
    public class PersonRep
    {
        PersonDbContext BaContext = new PersonDbContext();
        protected MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);

        public Person[] getAll() {
            string sql = "SELECT * FROM `person`";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql,con);
            MySqlDataReader read = cmd.ExecuteReader();
            Person[] persons = new Person[read.FieldCount];
            if (!read.HasRows) {
                read.Close();
                con.Close();
                return null;
            }
            while (read.Read()) {
                Person p = new Person();
                p.Age = int.Parse(read["Age"].ToString());
                p.Id = int.Parse(read["Id"].ToString());
                p.Mdp = read["Mdp"].ToString();
                p.Nom = read["Nom"].ToString();
                p.Email = read["Email"].ToString();

                persons[p.Id] = p;
            }
            con.Close();
            return persons;
        }
        public List<Person> get(string text) {
            Person[] all = getAll();
            List<Person> res = new List<Person>();
            foreach(Person p in all){
                if(p!=null)
                if (p.Nom == text || p.Email == text)
                    res.Add(p);  
            }
            return res;
        }
        public Person testLogin(string email,string mdp) {
         
            string sql = "SELECT * FROM `person` WHERE `Email` LIKE '"+email+ "'AND `Mdp` LIKE '" +mdp+ "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql,con);
            MySqlDataReader read = cmd.ExecuteReader();
            if (!read.HasRows) {
                read.Close();
                con.Close();
                return null;
            }
            
            while (read.Read()) {
                Person p = new Person(int.Parse(read["Id"].ToString()), read["Nom"].ToString(), read["Email"].ToString(), read["Mdp"].ToString(), int.Parse(read["Id"].ToString()));
                con.Close();
                return p;
            }
            
            
            return null;
        }
    }

}