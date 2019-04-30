using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Users
    {
        [Key]
        public String Id { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }

        List<Users> list = new List<Users>();
        public List<Users> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Users use = new Users();
                use.Id =dt.Rows[i]["Id"].ToString();
                use.Email = dt.Rows[i]["Email"].ToString();
                use.PasswordHash = dt.Rows[i]["PasswordHash"].ToString();
                use.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                list.Add(use);
            }
            return list;
        }
    }
}