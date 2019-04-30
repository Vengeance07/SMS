using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public String Street { get; set; }
        public String City { get; set; }

        List<Address> list = new List<Address>();
        public List<Address> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Address add = new Address();
                add.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                add.Street = dt.Rows[i]["Street"].ToString();
                add.City = dt.Rows[i]["City"].ToString();
                list.Add(add);
            }
            return list;
        }

    }
}