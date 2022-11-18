using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    /// <summary>
    /// модель представления БД
    /// </summary>
    internal class User
    {
        public int id { get; set; }
        
        public string login { get; set; }

        public string pass { get; set; }

        public string email { get; set; }

       
        public User() { }

        public User(string login, string pass, string email)
        {
            
            this.login = login;
            this.pass = pass;
            this.email = email;
        }

        /// <summary>
        /// Переписсанный метод ToString
        /// </summary>
        /// <returns></returns>
        //public override string ToString()
        //{
        //    return "Пользователь: " + login + " Email: " + email;
        //}



    }
}
