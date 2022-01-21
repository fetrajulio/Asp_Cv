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
            List<Person> persons = new List<Person>();
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

                persons.Add(p);
            }
            con.Close();
            return persons.ToArray();
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
        public List<Person> getMySql(string txt) {
            List<Person> res = new List<Person>();
            string sql = "SELECT * FROM `person` WHERE `Nom` LIKE '"+txt+"' OR 'Email' LIKE '"+txt+"'";
            con.Open();
                MySqlCommand cmd = new MySqlCommand(sql,con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read()) {
                    
                    Person p = new Person(int.Parse(read["Id"].ToString()), read["Nom"].ToString(), read["Email"].ToString(), read["Mdp"].ToString(), int.Parse(read["Id"].ToString()));
                    res.Add(p);
                }
            con.Close();
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
        public void newPerson(string nom,string email,string mdp,int age) {
            string sql = "INSERT INTO `person` (`Id`, `Nom`, `Email`, `Mdp`, `Age`) VALUES (NULL, '"+nom+"', '"+email+"', '"+mdp+"', '"+age+"');";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();
            con.Close();
        }
        public Person[] Trier() {
            Person[] all = this.getAll();
            int n=all.Length;
            foreach (Person p1 in all) { 
                foreach(Person p2 in all){
                    if (p1.Age > p2.Age) {
                        
                        Person temp = new Person(p1);
                        p1.permut(p2);
                        p2.permut(temp);
                    }
                }
            }
            return all;
        }

        public void supp(int id) {
            string sql = "DELETE FROM `person` WHERE `person`.`Id` ="+id;
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();
            con.Close();
        }

        public void modif(int id,string nom,string email,string mdp,int age) {
            string sql = "UPDATE `person` SET `Id` = '"+id+"', `Nom` = '"+nom+"', `Email` = '"+email+"', `Mdp` = '"+mdp+"', `Age` = '"+age+"' WHERE `person`.`Id` = "+id+"";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader read = cmd.ExecuteReader();
            con.Close();
        }
    }

}